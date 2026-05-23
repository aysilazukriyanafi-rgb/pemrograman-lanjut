namespace Project_Brute_Force_vs_Divide_and_Conquer
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox txtKeterangan;
        private System.Windows.Forms.Label lblLangkah;

        private System.Windows.Forms.GroupBox groupAlgoritma;
        private System.Windows.Forms.RadioButton rbBruteForce;
        private System.Windows.Forms.RadioButton rbDivideConquer;

        private System.Windows.Forms.GroupBox groupBenchmark;
        private System.Windows.Forms.Button btnBenchmark;
        private System.Windows.Forms.Label lblUkuranData;
        private System.Windows.Forms.Label lblBruteTime;
        private System.Windows.Forms.Label lblDncTime;
        private System.Windows.Forms.Label lblPerbandingan;

        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Button btnReset;

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dgvData = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            txtKeterangan = new TextBox();
            lblLangkah = new Label();
            groupAlgoritma = new GroupBox();
            rbBruteForce = new RadioButton();
            rbDivideConquer = new RadioButton();
            groupBenchmark = new GroupBox();
            btnBenchmark = new Button();
            lblUkuranData = new Label();
            lblBruteTime = new Label();
            lblDncTime = new Label();
            lblPerbandingan = new Label();
            btnPrev = new Button();
            btnNext = new Button();
            btnAuto = new Button();
            btnReset = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            groupAlgoritma.SuspendLayout();
            groupBenchmark.SuspendLayout();
            SuspendLayout();
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvData.ColumnHeadersHeight = 34;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            dgvData.Location = new Point(20, 20);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersVisible = false;
            dgvData.RowHeadersWidth = 62;
            dgvData.Size = new Size(600, 305);
            dgvData.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Hari";
            dataGridViewTextBoxColumn1.MinimumWidth = 8;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Nilai";
            dataGridViewTextBoxColumn2.MinimumWidth = 8;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // txtKeterangan
            // 
            txtKeterangan.Location = new Point(20, 369);
            txtKeterangan.Multiline = true;
            txtKeterangan.Name = "txtKeterangan";
            txtKeterangan.ReadOnly = true;
            txtKeterangan.Size = new Size(600, 75);
            txtKeterangan.TabIndex = 2;
            // 
            // lblLangkah
            // 
            lblLangkah.Location = new Point(20, 328);
            lblLangkah.Name = "lblLangkah";
            lblLangkah.Size = new Size(600, 32);
            lblLangkah.TabIndex = 1;
            lblLangkah.Text = "Langkah";
            // 
            // groupAlgoritma
            // 
            groupAlgoritma.Controls.Add(rbBruteForce);
            groupAlgoritma.Controls.Add(rbDivideConquer);
            groupAlgoritma.Location = new Point(650, 20);
            groupAlgoritma.Name = "groupAlgoritma";
            groupAlgoritma.Size = new Size(300, 100);
            groupAlgoritma.TabIndex = 3;
            groupAlgoritma.TabStop = false;
            groupAlgoritma.Text = "Algoritma";
            // 
            // rbBruteForce
            // 
            rbBruteForce.Checked = true;
            rbBruteForce.Location = new Point(20, 30);
            rbBruteForce.Name = "rbBruteForce";
            rbBruteForce.Size = new Size(164, 24);
            rbBruteForce.TabIndex = 0;
            rbBruteForce.TabStop = true;
            rbBruteForce.Text = "Brute Force";
            rbBruteForce.CheckedChanged += rbBruteForce_CheckedChanged;
            // 
            // rbDivideConquer
            // 
            rbDivideConquer.Location = new Point(20, 60);
            rbDivideConquer.Name = "rbDivideConquer";
            rbDivideConquer.Size = new Size(201, 34);
            rbDivideConquer.TabIndex = 1;
            rbDivideConquer.Text = "Divide && Conquer";
            rbDivideConquer.CheckedChanged += rbDivideConquer_CheckedChanged;
            // 
            // groupBenchmark
            // 
            groupBenchmark.Controls.Add(btnBenchmark);
            groupBenchmark.Controls.Add(lblUkuranData);
            groupBenchmark.Controls.Add(lblBruteTime);
            groupBenchmark.Controls.Add(lblDncTime);
            groupBenchmark.Controls.Add(lblPerbandingan);
            groupBenchmark.Location = new Point(650, 140);
            groupBenchmark.Name = "groupBenchmark";
            groupBenchmark.Size = new Size(300, 220);
            groupBenchmark.TabIndex = 4;
            groupBenchmark.TabStop = false;
            groupBenchmark.Text = "Benchmark";
            // 
            // btnBenchmark
            // 
            btnBenchmark.Location = new Point(20, 30);
            btnBenchmark.Name = "btnBenchmark";
            btnBenchmark.Size = new Size(250, 30);
            btnBenchmark.TabIndex = 0;
            btnBenchmark.Text = "Jalankan Benchmark";
            btnBenchmark.Click += btnBenchmark_Click;
            // 
            // lblUkuranData
            // 
            lblUkuranData.Location = new Point(20, 70);
            lblUkuranData.Name = "lblUkuranData";
            lblUkuranData.Size = new Size(327, 30);
            lblUkuranData.TabIndex = 1;
            lblUkuranData.Text = "Ukuran Data : -";
            // 
            // lblBruteTime
            // 
            lblBruteTime.Location = new Point(20, 100);
            lblBruteTime.Name = "lblBruteTime";
            lblBruteTime.Size = new Size(280, 30);
            lblBruteTime.TabIndex = 2;
            lblBruteTime.Text = "Brute Force : -";
            // 
            // lblDncTime
            // 
            lblDncTime.Location = new Point(20, 130);
            lblDncTime.Name = "lblDncTime";
            lblDncTime.Size = new Size(327, 30);
            lblDncTime.TabIndex = 3;
            lblDncTime.Text = "Divide && Conquer : -";
            // 
            // lblPerbandingan
            // 
            lblPerbandingan.Location = new Point(20, 160);
            lblPerbandingan.Name = "lblPerbandingan";
            lblPerbandingan.Size = new Size(327, 57);
            lblPerbandingan.TabIndex = 4;
            lblPerbandingan.Text = "Perbandingan : -";
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(200, 500);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(80, 30);
            btnPrev.TabIndex = 5;
            btnPrev.Text = "< Prev";
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(300, 500);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(80, 30);
            btnNext.TabIndex = 6;
            btnNext.Text = "Next >";
            btnNext.Click += btnNext_Click;
            // 
            // btnAuto
            // 
            btnAuto.Location = new Point(400, 500);
            btnAuto.Name = "btnAuto";
            btnAuto.Size = new Size(80, 30);
            btnAuto.TabIndex = 7;
            btnAuto.Text = "Auto";
            btnAuto.Click += btnAuto_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(500, 500);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(80, 30);
            btnReset.TabIndex = 8;
            btnReset.Text = "Reset";
            btnReset.Click += btnReset_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(1000, 600);
            Controls.Add(dgvData);
            Controls.Add(lblLangkah);
            Controls.Add(txtKeterangan);
            Controls.Add(groupAlgoritma);
            Controls.Add(groupBenchmark);
            Controls.Add(btnPrev);
            Controls.Add(btnNext);
            Controls.Add(btnAuto);
            Controls.Add(btnReset);
            Name = "Form1";
            Text = "Maximum Subarray Visualization";
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            groupAlgoritma.ResumeLayout(false);
            groupBenchmark.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Timer timer1;
    }
}