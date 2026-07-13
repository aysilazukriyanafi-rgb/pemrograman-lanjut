using System;
using System.Windows.Forms;

namespace NewAppCalculator
{
    public partial class Form1 : Form
    {

        decimal bil1;
        int opr;
        bool opr_selesai = false;

        public Form1()
        {
            InitializeComponent();
        }


        private void btnAngka_Click(object sender, EventArgs e)
        {
            Button tombol = (Button)sender;
            if (txtDisplay.Text == "0" || opr_selesai)
            {
                txtDisplay.Text = tombol.Text;
                opr_selesai = false;
            }
            else
            {
                txtDisplay.Text += tombol.Text;
            }
        }



        private void btnKali_Click_1(object sender, EventArgs e) { SetOperator(1, "x"); }
        private void btnBagi_Click_1(object sender, EventArgs e) { SetOperator(2, "/"); }
        private void btnTbh_Click_1(object sender, EventArgs e) { SetOperator(3, "+"); }
        private void btnKrg_Click_1(object sender, EventArgs e) { SetOperator(4, "-"); }


        private void SetOperator(int kode, string simbol)
        {
            bil1 = Convert.ToDecimal(txtDisplay.Text);
            txtDisplay2.Text = simbol;
            txtDisplay.Text = "0";
            opr = kode;
            opr_selesai = true;
        }


        private void btnSamaDengan_Click(object sender, EventArgs e)
        {
            decimal bil2 = Convert.ToDecimal(txtDisplay.Text);
            decimal hasil = 0;

            switch (opr)
            {
                case 1: hasil = bil1 * bil2; break;
                case 2: hasil = bil1 / bil2; break;
                case 3: hasil = bil1 + bil2; break;
                case 4: hasil = bil1 - bil2; break;
            }
            txtDisplay.Text = hasil.ToString();
            txtDisplay2.Text = "";
            opr_selesai = true;
        }


        private void btnAC_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            txtDisplay2.Text = "";
            bil1 = 0;
            opr = 0;
        }


        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 0 && txtDisplay.Text != "0")
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
            if (txtDisplay.Text == "") { txtDisplay.Text = "0"; }
        }

        private void btnKoma_Click_1(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.Contains(",")) { txtDisplay.Text += ","; }
        }
    }
}