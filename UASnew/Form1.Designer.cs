using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project_UAS_Manajemen_Bangun_Geometri
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            grpInput = new GroupBox();
            btnHapus = new Button();
            btnSimpan = new Button();
            btnSimpanDB = new Button();
            numParam2 = new NumericUpDown();
            lblParam2 = new Label();
            numParam1 = new NumericUpDown();
            lblParam1 = new Label();
            cmbTipe = new ComboBox();
            lblTipe = new Label();
            txtNama = new TextBox();
            lblNama = new Label();
            dgvGeometri = new DataGridView();
            txtCari = new TextBox();
            lblCari = new Label();
            lblFilter = new Label();
            cmbFilterTipe = new ComboBox();
            btnPrev = new Button();
            lblHalaman = new Label();
            btnNext = new Button();
            grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numParam2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numParam1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvGeometri).BeginInit();
            SuspendLayout();
            // 
            // grpInput
            // 
            grpInput.Controls.Add(btnHapus);
            grpInput.Controls.Add(btnSimpan);
            grpInput.Controls.Add(btnSimpanDB);
            grpInput.Controls.Add(numParam2);
            grpInput.Controls.Add(lblParam2);
            grpInput.Controls.Add(numParam1);
            grpInput.Controls.Add(lblParam1);
            grpInput.Controls.Add(cmbTipe);
            grpInput.Controls.Add(lblTipe);
            grpInput.Controls.Add(txtNama);
            grpInput.Controls.Add(lblNama);
            grpInput.Location = new Point(16, 15);
            grpInput.Name = "grpInput";
            grpInput.Size = new Size(320, 420);
            grpInput.TabIndex = 3;
            grpInput.TabStop = false;
            grpInput.Text = "Input Data Geometri";
            // 
            // btnHapus
            // 
            btnHapus.BackColor = Color.LightCoral;
            btnHapus.Location = new Point(15, 290);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(280, 40);
            btnHapus.TabIndex = 0;
            btnHapus.Text = "❌ Hapus Data Terpilih";
            btnHapus.UseVisualStyleBackColor = false;
            btnHapus.Click += btnHapus_Click;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.LightGreen;
            btnSimpan.Location = new Point(15, 240);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(280, 40);
            btnSimpan.TabIndex = 1;
            btnSimpan.Text = "💾 Simpan Lokal";
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // btnSimpanDB
            // 
            btnSimpanDB.BackColor = Color.Orange;
            btnSimpanDB.Location = new Point(15, 340);
            btnSimpanDB.Name = "btnSimpanDB";
            btnSimpanDB.Size = new Size(280, 40);
            btnSimpanDB.TabIndex = 7;
            btnSimpanDB.Text = "💾 Simpan ke Database (UAS)";
            btnSimpanDB.UseVisualStyleBackColor = false;
            btnSimpanDB.Click += BtnSimpanDB_Click;
            // 
            // numParam2
            // 
            numParam2.DecimalPlaces = 1;
            numParam2.Location = new Point(165, 190);
            numParam2.Name = "numParam2";
            numParam2.Size = new Size(130, 31);
            numParam2.TabIndex = 2;
            // 
            // lblParam2
            // 
            lblParam2.Location = new Point(165, 165);
            lblParam2.Name = "lblParam2";
            lblParam2.Size = new Size(100, 23);
            lblParam2.TabIndex = 3;
            lblParam2.Text = "Input 2:";
            // 
            // numParam1
            // 
            numParam1.DecimalPlaces = 1;
            numParam1.Location = new Point(15, 190);
            numParam1.Name = "numParam1";
            numParam1.Size = new Size(130, 31);
            numParam1.TabIndex = 4;
            // 
            // lblParam1
            // 
            lblParam1.Location = new Point(15, 165);
            lblParam1.Name = "lblParam1";
            lblParam1.Size = new Size(100, 23);
            lblParam1.TabIndex = 5;
            lblParam1.Text = "Input 1:";
            // 
            // cmbTipe
            // 
            cmbTipe.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipe.Items.AddRange(new object[] { "Persegi", "Persegi Panjang", "Lingkaran" });
            cmbTipe.Location = new Point(15, 120);
            cmbTipe.Name = "cmbTipe";
            cmbTipe.Size = new Size(280, 33);
            cmbTipe.TabIndex = 6;
            cmbTipe.SelectedIndexChanged += CmbTipe_SelectedIndexChanged;
            // 
            // lblTipe
            // 
            lblTipe.Location = new Point(15, 95);
            lblTipe.Name = "lblTipe";
            lblTipe.Size = new Size(100, 23);
            lblTipe.TabIndex = 7;
            lblTipe.Text = "Tipe Bangun:";
            // 
            // txtNama
            // 
            txtNama.Location = new Point(15, 55);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(280, 31);
            txtNama.TabIndex = 8;
            // 
            // lblNama
            // 
            lblNama.Location = new Point(15, 30);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(100, 23);
            lblNama.TabIndex = 9;
            lblNama.Text = "Nama Objek:";
            // 
            // dgvGeometri
            // 
            dgvGeometri.ColumnHeadersHeight = 34;
            dgvGeometri.Location = new Point(360, 55);
            dgvGeometri.Name = "dgvGeometri";
            dgvGeometri.ReadOnly = true;
            dgvGeometri.RowHeadersWidth = 62;
            dgvGeometri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGeometri.Size = new Size(826, 216);
            dgvGeometri.TabIndex = 2;
            // 
            // txtCari
            // 
            txtCari.Location = new Point(420, 16);
            txtCari.Name = "txtCari";
            txtCari.Size = new Size(350, 31);
            txtCari.TabIndex = 1;
            txtCari.TextChanged += TxtCari_TextChanged;
            // 
            // lblCari
            // 
            lblCari.Location = new Point(360, 20);
            lblCari.Name = "lblCari";
            lblCari.Size = new Size(60, 27);
            lblCari.TabIndex = 0;
            lblCari.Text = "🔍 Cari:";
            // 
            // lblFilter
            // 
            lblFilter.Location = new Point(790, 20);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(110, 27);
            lblFilter.TabIndex = 4;
            lblFilter.Text = "Filter Tipe:";
            // 
            // cmbFilterTipe
            // 
            cmbFilterTipe.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterTipe.Items.AddRange(new object[] { "-- Semua Tipe --", "Persegi", "Persegi Panjang", "Lingkaran" });
            cmbFilterTipe.Location = new Point(895, 16);
            cmbFilterTipe.Name = "cmbFilterTipe";
            cmbFilterTipe.Size = new Size(291, 33);
            cmbFilterTipe.TabIndex = 3;
            cmbFilterTipe.SelectedIndexChanged += cmbFilterTipe_SelectedIndexChanged;
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(620, 420);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(100, 35);
            btnPrev.TabIndex = 2;
            btnPrev.Text = "< Prev";
            btnPrev.Click += btnPrev_Click;
            // 
            // lblHalaman
            // 
            lblHalaman.Location = new Point(730, 425);
            lblHalaman.Name = "lblHalaman";
            lblHalaman.Size = new Size(120, 27);
            lblHalaman.TabIndex = 1;
            lblHalaman.Text = "Halaman: 1 / 1";
            lblHalaman.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(860, 420);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(100, 35);
            btnNext.TabIndex = 0;
            btnNext.Text = "Next >";
            btnNext.Click += btnNext_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(1210, 480);
            Controls.Add(btnNext);
            Controls.Add(lblHalaman);
            Controls.Add(btnPrev);
            Controls.Add(cmbFilterTipe);
            Controls.Add(lblFilter);
            Controls.Add(lblCari);
            Controls.Add(txtCari);
            Controls.Add(dgvGeometri);
            Controls.Add(grpInput);
            Name = "Form1";
            Text = "UAS - Aplikasi Manajemen Bangun Geometri";
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numParam2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numParam1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvGeometri).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Label lblTipe;
        private System.Windows.Forms.ComboBox cmbTipe;
        private System.Windows.Forms.Label lblParam1;
        private System.Windows.Forms.NumericUpDown numParam1;
        private System.Windows.Forms.Label lblParam2;
        private System.Windows.Forms.NumericUpDown numParam2;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnSimpanDB;
        private System.Windows.Forms.DataGridView dgvGeometri;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Label lblCari;

        // Variabel Komponen Baru (Filter & Pagination)
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbFilterTipe;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblHalaman;
        private System.Windows.Forms.Button btnNext;
    }
}