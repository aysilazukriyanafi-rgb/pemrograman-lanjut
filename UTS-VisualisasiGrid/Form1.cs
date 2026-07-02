using System;
using System.Drawing;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace project_UTS_Visualisasi_grid_and_pixel_editor
{
    public partial class Form1 : Form
    {
        
        private int[,] gridArray = new int[20, 20]; 
        private bool isCameraActive = false;        
        private VideoCapture capture;               
        private System.Windows.Forms.Timer cameraTimer;               

        public Form1()
        {
            InitializeComponent();
            SetupCameraTimer();
            AutoScroll = false;
            DoubleBuffered = true;

            typeof(Panel).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance)
                ?.SetValue(canvasPanel, true, null);
        }

        private void SetupCameraTimer()
        {
            cameraTimer = new System.Windows.Forms.Timer();
            cameraTimer.Interval = 100;
            cameraTimer.Tick += CameraTimer_Tick;
        }

        
        private void BtnToggleKamera_Click(object sender, EventArgs e)
        {
            if (!isCameraActive)
            {
                capture = new VideoCapture(0); 
                if (capture.IsOpened())
                {
                    isCameraActive = true;
                    cameraTimer.Start();
                    btnToggleKamera.Text = "🛑 Matikan Scanner";
                    btnToggleKamera.BackColor = Color.LightGreen;
                }
                else
                {
                    MessageBox.Show("Sistem mendeteksi kamera tidak aktif atau sedang digunakan aplikasi lain!");
                }
            }
            else
            {
                isCameraActive = false;
                cameraTimer.Stop();
                if (capture != null) { capture.Release(); capture.Dispose(); }
                btnToggleKamera.Text = "📷 Aktifkan Scanner Kamera";
                btnToggleKamera.BackColor = Color.LightGray;
                picPreview.Image = null; 
            }
        }

       
        private void CameraTimer_Tick(object sender, EventArgs e)
        {
            if (capture == null || !capture.IsOpened()) return;

            using (Mat frame = new Mat())
            {
                capture.Read(frame); 
                if (frame.Empty()) return;

               
                using (Mat gray = new Mat())
                using (Mat binary = new Mat())
                {
                    Cv2.CvtColor(frame, gray, ColorConversionCodes.BGR2GRAY);
                    Cv2.Threshold(gray, binary, 100, 255, ThresholdTypes.BinaryInv | ThresholdTypes.Otsu);

                    int cellWidth = binary.Width / 20;
                    int cellHeight = binary.Height / 20;

                    for (int baris = 0; baris < 20; baris++)
                    {
                        for (int kolom = 0; kolom < 20; kolom++)
                        {
                            byte pixelValue = binary.At<byte>(baris * cellHeight + (cellHeight / 2), kolom * cellWidth + (cellWidth / 2));
                            gridArray[baris, kolom] = (pixelValue == 255) ? 1 : 0;
                        }
                    }
                }

                
                if (picPreview.Image != null) picPreview.Image.Dispose();
                picPreview.Image = BitmapConverter.ToBitmap(frame);
            }

            canvasPanel.Invalidate(); 
        }

        private void CanvasPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (isCameraActive) return;

            int ukuranKotakFix = 25;
            int kolom = e.X / ukuranKotakFix;
            int baris = e.Y / ukuranKotakFix;

            if (kolom > 19) kolom = 19;
            if (baris > 19) baris = 19;

            if (baris >= 0 && baris < 20 && kolom >= 0 && kolom < 20)
            {
                gridArray[baris, kolom] = (gridArray[baris, kolom] == 0) ? 1 : 0;
                canvasPanel.Refresh();
            }
        }

        private void BtnHitungLuas_Click(object sender, EventArgs e)
        {
            int totalSelAktif = 0;
            for (int baris = 0; baris < 20; baris++)
            {
                for (int kolom = 0; kolom < 20; kolom++)
                {
                    if (gridArray[baris, kolom] == 1) totalSelAktif++;
                }
            }

            double nilaiSkala = Convert.ToDouble(numUnitSize.Value);
            double hitungLuasLuas = totalSelAktif * (nilaiSkala * nilaiSkala);
            lblHasilLuas.Text = $"Luas Area: {hitungLuasLuas} cm²\r\n({totalSelAktif} sel aktif)";
        }

        private void CanvasPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int ukuranKotakFix = 25;

            for (int baris = 0; baris < 20; baris++)
            {
                for (int kolom = 0; kolom < 20; kolom++)
                {
                    Brush warnaKuas = (gridArray[baris, kolom] == 1) ? Brushes.Blue : Brushes.White;
                    g.FillRectangle(warnaKuas, kolom * ukuranKotakFix, baris * ukuranKotakFix, ukuranKotakFix, ukuranKotakFix);
                    g.DrawRectangle(Pens.Black, kolom * ukuranKotakFix, baris * ukuranKotakFix, ukuranKotakFix, ukuranKotakFix);
                }
            }
        }

    
        private void BtnExport_Click(object sender, EventArgs e)
        {
            txtExportOutput.Clear();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int baris = 0; baris < 20; baris++)
            {
                for (int kolom = 0; kolom < 20; kolom++)
                {
                    sb.Append(gridArray[baris, kolom] + " ");
                }
                sb.AppendLine();
            }
            txtExportOutput.Text = sb.ToString();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Array.Clear(gridArray, 0, gridArray.Length);
            lblHasilLuas.Text = "Luas Area: 0 cm²\r\n(0 sel aktif)";
            txtExportOutput.Clear();
            canvasPanel.Invalidate();
        }
    }
}