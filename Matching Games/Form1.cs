namespace MatchTheImageGame
{
    public partial class Form1 : Form
    {

        List<int> numbers = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 };
        string firstChoice;
        string secondChoice;
        int tries;
        List<PictureBox> pictures = new List<PictureBox>();
        PictureBox picA;
        PictureBox picB;
        int totalTime = 60;
        int countDownTime;
        bool gameOver = false;


        public Form1()
        {
            InitializeComponent();
            LoadPictures();
        }

        private Label lblStatus;
        private Label lblWaktu;
        private Button button1;

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblStatus = new Label();
            lblWaktu = new Label();
            button1 = new Button();
            GameTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(238, 79);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(111, 25);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Tidak Cocok";
            // 
            // lblWaktu
            // 
            lblWaktu.AutoSize = true;
            lblWaktu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWaktu.Location = new Point(222, 122);
            lblWaktu.Name = "lblWaktu";
            lblWaktu.Size = new Size(159, 25);
            lblWaktu.TabIndex = 1;
            lblWaktu.Text = "Waktu Tersisa: 60";
            lblWaktu.Click += Waktu_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(238, 12);
            button1.Name = "button1";
            button1.Size = new Size(143, 46);
            button1.TabIndex = 2;
            button1.Text = "Restart";
            button1.UseVisualStyleBackColor = true;
            button1.Click += RestartGameEvent;
            // 
            // GameTimer
            // 
            GameTimer.Interval = 1000;
            GameTimer.Tick += TimerEvent;
            // 
            // Form1
            // 
            ClientSize = new Size(425, 359);
            Controls.Add(button1);
            Controls.Add(lblWaktu);
            Controls.Add(lblStatus);
            Name = "Form1";
            ResumeLayout(false);
            PerformLayout();

        }

        private void Waktu_Click(object sender, EventArgs e)
        {

        }

        private System.Windows.Forms.Timer GameTimer;
        private System.ComponentModel.IContainer components;

        private void TimerEvent(object sender, EventArgs e)
        {
            countDownTime--;

            lblWaktu.Text = "Waktu Tersisa: " + countDownTime;

            if (countDownTime < 1)
            {
                GameOver("Waktu Habis, Kamu Kalah");

                foreach (PictureBox x in pictures)
                {
                    if (x.Tag != null)
                    {
                        x.Image = Image.FromFile("pics/" + (string)x.Tag + ".png");
                    }
                }
            }
        }

        private void RestartGameEvent(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void LoadPictures()
        {
            int leftPos = 20;
            int topPos = 20;
            int rows = 0;

            for (int i = 0; i < 12; i++)
            {
                PictureBox newPic = new PictureBox();
                newPic.Height = 50;
                newPic.Width = 50;
                newPic.BackColor = Color.LightGray;
                newPic.SizeMode = PictureBoxSizeMode.StretchImage;
                newPic.Click += NewPic_Click;
                pictures.Add(newPic);

                if (rows < 3)
                {
                    rows++;
                    newPic.Left = leftPos;
                    newPic.Top = topPos;
                    this.Controls.Add(newPic);
                    leftPos = leftPos + 60;
                }

                if (rows == 3)
                {
                    leftPos = 20;
                    topPos += 60;
                    rows = 0;
                }
            }

            RestartGame();


        }

        private void NewPic_Click(object? sender, EventArgs e)

        {

            if (gameOver)
            {
                // dont register a click if the game is over
                return;
            }

            if (firstChoice == null)
            {
                picA = sender as PictureBox;
                if (picA.Tag != null && picA.Image == null)
                {
                    picA.Image = Image.FromFile("pics/" + (String)picA.Tag + ".png");
                    firstChoice = (string)picA.Tag;
                }
            }
            else if (secondChoice == null)
            {
                picB = sender as PictureBox;

                if (picB.Tag != null && picB.Image == null)
                {
                    picB.Image = Image.FromFile("pics/" + (string)picB.Tag + ".png");
                    secondChoice = (string)picB.Tag;
                }
            }
            else
            {
                CheckPictures(picA, picB);
            }
        }

        private void RestartGame()
        {
            // randomise the original list
            var randomList = numbers.OrderBy(x => Guid.NewGuid()).ToList();
            // assign the random list to the original
            numbers = randomList;

            for (int i = 0; i < pictures.Count; i++)
            {
                pictures[i].Image = null;
                pictures[i].Tag = numbers[i].ToString();
            }

            tries = 0;
            lblStatus.Text = "Percobaan: " + tries + "x";
            lblWaktu.Text = "Time Left: " + totalTime;
            gameOver = false;

            countDownTime = totalTime;

            GameTimer.Start();
        }

        private void CheckPictures(PictureBox A, PictureBox B)
        {
            if (firstChoice == secondChoice)
            {
                A.Tag = null;
                B.Tag = null;
            }
            else
            {
                tries++;
                lblStatus.Text = "Salah" + tries + "x";
            }

            firstChoice = null;
            secondChoice = null;

            foreach (PictureBox pics in pictures.ToList())
            {
                if (pics.Tag != null)
                {
                    pics.Image = null;
                }
            }

            // now lets check if all of  th items have been solved

            if (pictures.All(o => o.Tag == pictures[0].Tag))
            {
                GameOver("Kerja Bagus, Kamu Menang!!!!");
            }
        }


        private void GameOver(string msg)
        {
            GameTimer.Stop();
            gameOver = true;
            MessageBox.Show(msg + " Tekan Restart untuk Main Lagi.");
        }
    }
}
