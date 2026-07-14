using System;
using System.Data;
using System.Windows.Forms;
using Project_UAS_Manajemen_Bangun_Geometri.Application;
using Project_UAS_Manajemen_Bangun_Geometri.Domain;
using Project_UAS_Manajemen_Bangun_Geometri.Domain.Entities;
using Project_UAS_Manajemen_Bangun_Geometri.Infrastructure;

namespace Project_UAS_Manajemen_Bangun_Geometri
{
    public partial class Form1 : Form
    {
        private int halamanSekarang = 1;
        private int dataPerHalaman = 5;
        private int totalHalaman = 1;

        private readonly IBangunGeometriRepository _repository;
        private readonly GeometriService _geometriService;

        public Form1()
        {
            InitializeComponent();

            
            _repository = new LocalRepository();
            _geometriService = new GeometriService(_repository);

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

        private void TampilData()
        {
            string filterTipe = cmbFilterTipe.SelectedItem?.ToString() ?? "-- Semua Tipe --";
            string cari = txtCari.Text;

            int totalData = _geometriService.DapatkanTotalData(filterTipe, cari);

            totalHalaman = (int)Math.Ceiling((double)totalData / dataPerHalaman);
            if (totalHalaman < 1) totalHalaman = 1;
            if (halamanSekarang > totalHalaman) halamanSekarang = totalHalaman;

            btnPrev.Enabled = (halamanSekarang > 1);
            btnNext.Enabled = (halamanSekarang < totalHalaman);
            lblHalaman.Text = $"Halaman: {halamanSekarang} / {totalHalaman}";

            int offset = (halamanSekarang - 1) * dataPerHalaman;

            try
            {
                DataTable dt = _geometriService.DapatkanGridData(filterTipe, cari, dataPerHalaman, offset);
                dgvGeometri.DataSource = null;
                dgvGeometri.AutoGenerateColumns = true;
                dgvGeometri.DataSource = dt;
                dgvGeometri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data!\nDetail: " + ex.Message, "Error Load Data");
            }
        }

        private void cmbFilterTipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            halamanSekarang = 1;
            TampilData();
        }

        private void TxtCari_TextChanged(object sender, EventArgs e)
        {
            halamanSekarang = 1;
            TampilData();
        }

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

        private void BtnSimpanDB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text) || cmbTipe.SelectedIndex == -1)
            {
                MessageBox.Show("Lengkapi Nama Objek dan Tipe Bangun terlebih dahulu!", "Peringatan UAS");
                return;
            }

            string nama = txtNama.Text;
            string tipe = cmbTipe.SelectedItem.ToString();
            double p1 = Convert.ToDouble(numParam1.Value);
            double p2 = Convert.ToDouble(numParam2.Value);

            try
            {
                _geometriService.SimpanKeDatabase(tipe, nama, p1, p2);
                MessageBox.Show($"Data Bangun '{nama}' ({tipe}) berhasil diarsipkan ke Database!", "Sukses UAS");
                TampilData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal terhubung ke database!\nDetail: " + ex.Message, "Error Database");
            }
        }

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
                        try
                        {
                            _geometriService.HapusData(idTerpilih);
                            MessageBox.Show("Data berhasil dihapus permanen dari MySQL!", "Sukses");
                            TampilData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Gagal menghapus data!\nDetail: " + ex.Message, "Error");
                        }
                    }
                }
            }
        }

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

            BangunGeometri bangun = _geometriService.BuatDanSimpanLokal(tipe, nama, p1, p2);

            if (bangun == null) return;

            DataTable dt = dgvGeometri.DataSource as DataTable;
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = DBNull.Value;
                dr["Nama Objek"] = bangun.NamaObjek;
                dr["Tipe Bangun"] = bangun.TipeBangun;
                dr["Input 1"] = p1;
                dr["Input 2"] = (tipe == "Persegi Panjang") ? (object)p2 : DBNull.Value;
                dr["Luas"] = Math.Round(bangun.HitungLuas(), 2);
                dr["Keliling"] = Math.Round(bangun.HitungKeliling(), 2);
                dr["Waktu Simpan"] = DateTime.Now;

                dt.Rows.InsertAt(dr, 0);
                MessageBox.Show($"Data '{nama}' berhasil disimpan via Interface & Grid Lokal!", "Sukses Lokal");
            }
        }
    }
}