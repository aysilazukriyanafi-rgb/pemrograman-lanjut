using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project_UAS_Manajemen_Bangun_Geometri
{
    public partial class Form1 : Form
    {
        // Koneksi untuk MySQL XAMPP lokal
        private string connString = "server=localhost;database=db_geometri_uas;uid=root;pwd=;";

        // VARIABEL PAGINATION & FILTER
        private int halamanSekarang = 1;
        private int dataPerHalaman = 5; // Anda bisa mengubah angka ini (misal: 10 atau 20) sesuai kebutuhan
        private int totalHalaman = 1;

        public Form1()
        {
            InitializeComponent();
            // Hapus atau komentari baris di bawah ini:
            // InitializeFilterAndPaginationDesign(); 

            // Set default pilihan filter ke "-- Semua Tipe --"
            if (cmbFilterTipe.Items.Count > 0) cmbFilterTipe.SelectedIndex = 0;
            if (cmbTipe.Items.Count > 0) cmbTipe.SelectedIndex = 0;

            TampilData();
        }

        private void CmbTipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipe.SelectedItem == null) return;

            string tipeTerpilih = cmbTipe.SelectedItem.ToString();

            if (tipeTerpilih == "Persegi")
            {
                lblParam1.Text = "Ukuran Sisi (cm):";
                lblParam2.Visible = false;
                numParam2.Visible = false;
            }
            else if (tipeTerpilih == "Persegi Panjang")
            {
                lblParam1.Text = "Panjang (cm):";
                lblParam2.Text = "Lebar (cm):";
                lblParam2.Visible = true;
                numParam2.Visible = true;
            }
            else if (tipeTerpilih == "Lingkaran")
            {
                lblParam1.Text = "Jari-jari (cm):";
                lblParam2.Visible = false;
                numParam2.Visible = false;
            }
        }

        // --- CORE LOGIC: TAMPIL DATA DENGAN FILTER & PAGINATION ---
        private void TampilData()
        {
            // 1. Hitung Total Data Terlebih Dahulu Berdasarkan Filter
            int totalData = DapatkanTotalData();

            // 2. Hitung Total Halaman yang Tersedia
            totalHalaman = (int)Math.Ceiling((double)totalData / dataPerHalaman);
            if (totalHalaman < 1) totalHalaman = 1;

            // Antisipasi jika halaman sekarang melampaui batas setelah filter diubah
            if (halamanSekarang > totalHalaman) halamanSekarang = totalHalaman;

            // 3. Atur Aktif/Nonaktif Tombol Navigasi Halaman
            btnPrev.Enabled = (halamanSekarang > 1);
            btnNext.Enabled = (halamanSekarang < totalHalaman);
            lblHalaman.Text = $"Halaman: {halamanSekarang} / {totalHalaman}";

            // 4. Hitung Offset (Titik Mulai Ambil Data untuk MySQL)
            int offset = (halamanSekarang - 1) * dataPerHalaman;

            // 5. Susun Query Dinamis dengan klausa WHERE dan LIMIT OFFSET
            string query = "SELECT id AS 'ID', nama_objek AS 'Nama Objek', tipe_bangun AS 'Tipe Bangun', " +
                           "param1 AS 'Input 1', param2 AS 'Input 2', luas AS 'Luas', keliling AS 'Keliling', " +
                           "waktu_simpan AS 'Waktu Simpan' FROM tbl_geometri WHERE 1=1 ";

            string filterTipe = cmbFilterTipe.SelectedItem?.ToString() ?? "-- Semua Tipe --";
            if (filterTipe != "-- Semua Tipe --")
            {
                query += "AND tipe_bangun = @filterTipe ";
            }

            if (!string.IsNullOrWhiteSpace(txtCari.Text))
            {
                query += "AND nama_objek LIKE @cari ";
            }

            query += "ORDER BY id DESC LIMIT @limit OFFSET @offset";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (filterTipe != "-- Semua Tipe --") cmd.Parameters.AddWithValue("@filterTipe", filterTipe);
                        if (!string.IsNullOrWhiteSpace(txtCari.Text)) cmd.Parameters.AddWithValue("@cari", "%" + txtCari.Text + "%");

                        cmd.Parameters.AddWithValue("@limit", dataPerHalaman);
                        cmd.Parameters.AddWithValue("@offset", offset);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            dgvGeometri.DataSource = null;
                            dgvGeometri.AutoGenerateColumns = true;
                            dgvGeometri.DataSource = dt;
                            dgvGeometri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data!\nDetail: " + ex.Message, "Error Load Data");
                }
            }
        }

        // Fungsi bantu untuk menghitung total baris di database (agar pagination akurat)
        private int DapatkanTotalData()
        {
            int total = 0;
            string query = "SELECT COUNT(*) FROM tbl_geometri WHERE 1=1 ";

            string filterTipe = cmbFilterTipe.SelectedItem?.ToString() ?? "-- Semua Tipe --";
            if (filterTipe != "-- Semua Tipe --") query += "AND tipe_bangun = @filterTipe ";
            if (!string.IsNullOrWhiteSpace(txtCari.Text)) query += "AND nama_objek LIKE @cari ";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (filterTipe != "-- Semua Tipe --") cmd.Parameters.AddWithValue("@filterTipe", filterTipe);
                        if (!string.IsNullOrWhiteSpace(txtCari.Text)) cmd.Parameters.AddWithValue("@cari", "%" + txtCari.Text + "%");
                        total = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch { total = 0; }
            }
            return total;
        }

        // --- EVENT TRIGGER FILTER & PENCARIAN ---
        private void cmbFilterTipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            halamanSekarang = 1; // Reset ke halaman pertama setiap ganti filter
            TampilData();
        }

        private void TxtCari_TextChanged(object sender, EventArgs e)
        {
            halamanSekarang = 1; // Reset ke halaman pertama setiap mengetik pencarian baru
            TampilData();
        }

        // --- EVENT NAVIGATION PAGINATION ---
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (halamanSekarang > 1)
            {
                halamanSekarang--;
                TampilData();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (halamanSekarang < totalHalaman)
            {
                halamanSekarang++;
                TampilData();
            }
        }

        // --- TOMBOL SIMPAN KE DATABASE (MYSQL) ---
        private void BtnSimpanDB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text))
            {
                MessageBox.Show("Nama Objek tidak boleh kosong!", "Peringatan UAS");
                return;
            }
            if (cmbTipe.SelectedIndex == -1)
            {
                MessageBox.Show("Silakan pilih Tipe Bangun Geometri terlebih dahulu!", "Peringatan UAS");
                return;
            }

            string nama = txtNama.Text;
            string tipe = cmbTipe.SelectedItem.ToString();
            double p1 = Convert.ToDouble(numParam1.Value);
            double p2 = Convert.ToDouble(numParam2.Value);
            double luas = 0;
            double keliling = 0;

            if (tipe == "Persegi") { luas = p1 * p1; keliling = 4 * p1; }
            else if (tipe == "Persegi Panjang") { luas = p1 * p2; keliling = 2 * (p1 + p2); }
            else if (tipe == "Lingkaran") { luas = Math.PI * p1 * p1; keliling = 2 * Math.PI * p1; }

            string query = "INSERT INTO tbl_geometri (nama_objek, tipe_bangun, param1, param2, luas, keliling) " +
                           "VALUES (@nama, @tipe, @p1, @p2, @luas, @keliling)";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@tipe", tipe);
                        cmd.Parameters.AddWithValue("@p1", p1);
                        cmd.Parameters.AddWithValue("@p2", (tipe == "Persegi Panjang") ? (object)p2 : DBNull.Value);
                        cmd.Parameters.AddWithValue("@luas", Math.Round(luas, 2));
                        cmd.Parameters.AddWithValue("@keliling", Math.Round(keliling, 2));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"Data Bangun '{nama}' ({tipe}) berhasil diarsipkan!", "Sukses UAS");
                        TampilData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal terhubung ke database!\nDetail: " + ex.Message, "Error Database");
                }
            }
        }

        // --- TOMBOL HAPUS DATA ---
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvGeometri.CurrentRow == null)
            {
                MessageBox.Show("Pilih baris data pada tabel yang ingin dihapus terlebih dahulu!", "Peringatan");
                return;
            }

            DataRowView currentWordRow = dgvGeometri.CurrentRow.DataBoundItem as DataRowView;
            if (currentWordRow != null)
            {
                DataRow dr = currentWordRow.Row;
                object idValue = dr["ID"];

                if (idValue == DBNull.Value || idValue == null)
                {
                    dr.Delete();
                    MessageBox.Show("Data lokal berhasil dibersihkan!", "Sukses Hapus");
                }
                else
                {
                    string idTerpilih = idValue.ToString();
                    DialogResult dialog = MessageBox.Show($"Apakah Anda yakin ingin menghapus permanen data ID: {idTerpilih}?", "Konfirmasi Hapus", MessageBoxButtons.YesNo);

                    if (dialog == DialogResult.Yes)
                    {
                        string query = "DELETE FROM tbl_geometri WHERE id = @id";
                        using (MySqlConnection conn = new MySqlConnection(connString))
                        {
                            try
                            {
                                conn.Open();
                                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                                {
                                    cmd.Parameters.AddWithValue("@id", idTerpilih);
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Data berhasil dihapus permanen dari MySQL!", "Sukses");
                                    TampilData();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Gagal menghapus data!\nDetail: " + ex.Message, "Error");
                            }
                        }
                    }
                }
            }
        }

        // --- TOMBOL SIMPAN LOKAL ---
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text) || cmbTipe.SelectedIndex == -1)
            {
                MessageBox.Show("Lengkapi Nama Objek dan Tipe Bangun terlebih dahulu!", "Peringatan Lokal");
                return;
            }

            string nama = txtNama.Text;
            string tipe = cmbTipe.SelectedItem.ToString();
            double p1 = Convert.ToDouble(numParam1.Value);
            double p2 = Convert.ToDouble(numParam2.Value);
            double luas = 0;
            double keliling = 0;

            if (tipe == "Persegi") { luas = p1 * p1; keliling = 4 * p1; }
            else if (tipe == "Persegi Panjang") { luas = p1 * p2; keliling = 2 * (p1 + p2); }
            else if (tipe == "Lingkaran") { luas = Math.PI * p1 * p1; keliling = 2 * Math.PI * p1; }

            DataTable dt = dgvGeometri.DataSource as DataTable;
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = DBNull.Value;
                dr["Nama Objek"] = nama;
                dr["Tipe Bangun"] = tipe;
                dr["Input 1"] = p1;
                dr["Input 2"] = (tipe == "Persegi Panjang") ? (object)p2 : DBNull.Value;
                dr["Luas"] = Math.Round(luas, 2);
                dr["Keliling"] = Math.Round(keliling, 2);
                dr["Waktu Simpan"] = DateTime.Now;

                dt.Rows.InsertAt(dr, 0);
                MessageBox.Show($"Data '{nama}' berhasil disimpan ke Grid Lokal!", "Sukses Lokal");
            }
        }
    }
}