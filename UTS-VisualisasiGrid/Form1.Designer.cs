namespace project_UTS_Visualisasi_grid_and_pixel_editor
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
            canvasPanel = new Panel();
            ctrlGroup = new GroupBox();
            lblUnit = new Label();
            numUnitSize = new NumericUpDown();
            btnHitungLuas = new Button();
            lblHasilLuas = new Label();
            btnExport = new Button();
            txtExportOutput = new TextBox();
            btnReset = new Button();
            btnToggleKamera = new Button();
            picPreview = new PictureBox();
            ctrlGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numUnitSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            SuspendLayout();
            // 
            // canvasPanel
            // 
            canvasPanel.BackColor = Color.White;
            canvasPanel.BorderStyle = BorderStyle.FixedSingle;
            canvasPanel.Location = new Point(20, 15);
            canvasPanel.Margin = new Padding(4);
            canvasPanel.Name = "canvasPanel";
            canvasPanel.Size = new Size(501, 501);
            canvasPanel.TabIndex = 0;
            canvasPanel.Paint += CanvasPanel_Paint;
            canvasPanel.MouseDown += CanvasPanel_MouseDown;
            // 
            // ctrlGroup
            // 
            ctrlGroup.Controls.Add(lblUnit);
            ctrlGroup.Controls.Add(numUnitSize);
            ctrlGroup.Controls.Add(btnHitungLuas);
            ctrlGroup.Controls.Add(lblHasilLuas);
            ctrlGroup.Controls.Add(btnExport);
            ctrlGroup.Controls.Add(txtExportOutput);
            ctrlGroup.Controls.Add(btnReset);
            ctrlGroup.Controls.Add(btnToggleKamera);
            ctrlGroup.Location = new Point(539, 15);
            ctrlGroup.Margin = new Padding(4);
            ctrlGroup.Name = "ctrlGroup";
            ctrlGroup.Padding = new Padding(4);
            ctrlGroup.Size = new Size(360, 458);
            ctrlGroup.TabIndex = 1;
            ctrlGroup.TabStop = false;
            ctrlGroup.Text = "Panel Kontrol & Aksi";
            // 
            // lblUnit
            // 
            lblUnit.Location = new Point(15, 25);
            lblUnit.Margin = new Padding(4, 0, 4, 0);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(200, 25);
            lblUnit.TabIndex = 0;
            lblUnit.Text = "Ukuran Sel Nyata (cm):";
            // 
            // numUnitSize
            // 
            numUnitSize.Location = new Point(15, 55);
            numUnitSize.Margin = new Padding(4);
            numUnitSize.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numUnitSize.Name = "numUnitSize";
            numUnitSize.Size = new Size(120, 31);
            numUnitSize.TabIndex = 1;
            numUnitSize.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // btnHitungLuas
            // 
            btnHitungLuas.BackColor = Color.LightGreen;
            btnHitungLuas.Location = new Point(15, 95);
            btnHitungLuas.Margin = new Padding(4);
            btnHitungLuas.Name = "btnHitungLuas";
            btnHitungLuas.Size = new Size(330, 45);
            btnHitungLuas.TabIndex = 2;
            btnHitungLuas.Text = "🔍 Hitung Luas Area";
            btnHitungLuas.UseVisualStyleBackColor = false;
            btnHitungLuas.Click += BtnHitungLuas_Click;
            // 
            // lblHasilLuas
            // 
            lblHasilLuas.Font = new Font("Arial", 10F, FontStyle.Bold);
            lblHasilLuas.Location = new Point(15, 150);
            lblHasilLuas.Margin = new Padding(4, 0, 4, 0);
            lblHasilLuas.Name = "lblHasilLuas";
            lblHasilLuas.Size = new Size(330, 45);
            lblHasilLuas.TabIndex = 3;
            lblHasilLuas.Text = "Luas Area: 0 cm²\r\n(0 sel aktif)";
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.LightSkyBlue;
            btnExport.Location = new Point(15, 205);
            btnExport.Margin = new Padding(4);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(330, 45);
            btnExport.TabIndex = 4;
            btnExport.Text = "💾 Export Nilai Grid";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += BtnExport_Click;
            // 
            // txtExportOutput
            // 
            txtExportOutput.Font = new Font("Consolas", 7.5F);
            txtExportOutput.Location = new Point(15, 260);
            txtExportOutput.Margin = new Padding(4);
            txtExportOutput.Multiline = true;
            txtExportOutput.Name = "txtExportOutput";
            txtExportOutput.ReadOnly = true;
            txtExportOutput.ScrollBars = ScrollBars.Both;
            txtExportOutput.Size = new Size(330, 90);
            txtExportOutput.TabIndex = 5;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(15, 360);
            btnReset.Margin = new Padding(4);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(330, 40);
            btnReset.TabIndex = 6;
            btnReset.Text = "🔄 Reset Grid";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += BtnReset_Click;
            // 
            // btnToggleKamera
            // 
            btnToggleKamera.BackColor = Color.LightGray;
            btnToggleKamera.Location = new Point(15, 410);
            btnToggleKamera.Name = "btnToggleKamera";
            btnToggleKamera.Size = new Size(330, 40);
            btnToggleKamera.TabIndex = 7;
            btnToggleKamera.Text = "📷 Aktifkan Scanner Kamera";
            btnToggleKamera.UseVisualStyleBackColor = false;
            btnToggleKamera.Click += BtnToggleKamera_Click;
            // 
            // picPreview
            // 
            picPreview.BorderStyle = BorderStyle.FixedSingle;
            picPreview.Location = new Point(572, 480);
            picPreview.Name = "picPreview";
            picPreview.Size = new Size(277, 153);
            picPreview.SizeMode = PictureBoxSizeMode.StretchImage;
            picPreview.TabIndex = 7;
            picPreview.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(923, 784);
            Controls.Add(ctrlGroup);
            Controls.Add(canvasPanel);
            Controls.Add(picPreview);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UTS - Visualisasi Grid & Pixel Editor";
            ctrlGroup.ResumeLayout(false);
            ctrlGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numUnitSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel canvasPanel;
        private System.Windows.Forms.GroupBox ctrlGroup;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.NumericUpDown numUnitSize;
        private System.Windows.Forms.Button btnHitungLuas;
        private System.Windows.Forms.Label lblHasilLuas;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtExportOutput;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnToggleKamera;
        private System.Windows.Forms.PictureBox picPreview;
    }
}