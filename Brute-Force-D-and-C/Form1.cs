using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Project_Brute_Force_vs_Divide_and_Conquer
{
    public partial class Form1 : Form
    {
        string[] hari = {
            "Hari 1", "Hari 2", "Hari 3", "Hari 4", "Hari 5",
            "Hari 6", "Hari 7", "Hari 8", "Hari 9", "Hari 10",
            "Hari 11", "Hari 12", "Hari 13", "Hari 14", "Hari 15"
        };

        int[] dataSahamAwal = {
            12, -15, 20, -5, 30,
            -10, 45, -60, 25, 10,
            -15, 35, -20, 15, -5
        };

        string[] namaHari;
        int[] fluktuasiSaham;

       
        List<int[]> stepKuning = new List<int[]>();
        List<int> stepMerah = new List<int>();
        List<int[]> stepHijau = new List<int[]>();
        List<string> stepKeterangan = new List<string>();

        int currentStep = 0;
        System.Windows.Forms.Timer timerAuto = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
            InitData();
            SetupTimer();
        }

        // ================= INIT DATA =================
        private void InitData()
        {
            namaHari = (string[])hari.Clone();
            fluktuasiSaham = (int[])dataSahamAwal.Clone();

            if (dgvData != null)
            {
                dgvData.Rows.Clear();
                for (int i = 0; i < namaHari.Length; i++)
                {
                    dgvData.Rows.Add(namaHari[i], fluktuasiSaham[i]);
                }
            }

            txtKeterangan.Text = "Silakan pilih Algoritma terlebih dahulu untuk memulai visualisasi.";
            if (lblLangkah != null) lblLangkah.Text = "Langkah: 0 / 0";
        }

        private void SetupTimer()
        {
            timerAuto.Interval = 700;
            timerAuto.Tick += (s, e) =>
            {
                NextStep();
            };
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timerAuto.Stop();
            currentStep = 0;
            stepKuning.Clear();
            stepHijau.Clear();
            stepMerah.Clear();
            stepKeterangan.Clear();

            InitData();
            ClearColor();

            if (rbBruteForce.Checked)
                GenerateBruteForceSteps();
            else if (rbDivideConquer.Checked)
                GenerateDivideConquerSteps();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            timerAuto.Stop();
            NextStep();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            timerAuto.Stop();

            if (currentStep <= 1)
            {
                currentStep = 0;
                ClearColor();
                txtKeterangan.Text = "Kembali ke langkah awal.";
                if (lblLangkah != null) lblLangkah.Text = $"Langkah: {currentStep} / {stepKeterangan.Count}";
                return;
            }

            currentStep -= 2;
            NextStep();
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            if (stepKeterangan.Count == 0)
            {
                MessageBox.Show("Pilih salah satu algoritma terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            timerAuto.Start();
        }

        private void NextStep()
        {
            if (currentStep >= stepKeterangan.Count)
            {
                timerAuto.Stop();
                MessageBox.Show("Visualisasi selesai!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ClearColor();

            // Safe Check menggunakan sinkronisasi index beralur pasti
            if (currentStep < stepKuning.Count)
            {
                foreach (int i in stepKuning[currentStep])
                {
                    if (i >= 0 && i < dgvData.Rows.Count)
                        dgvData.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }

            if (currentStep < stepHijau.Count)
            {
                foreach (int i in stepHijau[currentStep])
                {
                    if (i >= 0 && i < dgvData.Rows.Count)
                        dgvData.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }

            if (currentStep < stepMerah.Count && stepMerah[currentStep] != -1)
            {
                int midIdx = stepMerah[currentStep];
                if (midIdx >= 0 && midIdx < dgvData.Rows.Count)
                    dgvData.Rows[midIdx].DefaultCellStyle.BackColor = Color.Red;
            }

            txtKeterangan.Text = stepKeterangan[currentStep];
            currentStep++;

            if (lblLangkah != null)
                lblLangkah.Text = $"Langkah: {currentStep} / {stepKeterangan.Count}";
        }

        private void ClearColor()
        {
            if (dgvData == null) return;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void GenerateBruteForceSteps()
        {
            stepKuning.Clear();
            stepHijau.Clear();
            stepMerah.Clear();
            stepKeterangan.Clear();

            int maxSum = int.MinValue;
            List<int> bestRange = new List<int>();

            for (int i = 0; i < fluktuasiSaham.Length; i++)
            {
                for (int j = i; j < fluktuasiSaham.Length; j++)
                {
                    int sum = 0;
                    List<int> range = new List<int>();
                    for (int k = i; k <= j; k++)
                    {
                        sum += fluktuasiSaham[k];
                        range.Add(k);
                    }

                    stepKuning.Add(range.ToArray());
                    stepMerah.Add(-1);

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        bestRange = new List<int>(range);
                        stepKeterangan.Add($"[Brute Force] Subarray baru ditemukan dari index {i} s/d {j} dengan Maksimum Profit = {maxSum}");
                    }
                    else
                    {
                        stepKeterangan.Add($"[Brute Force] Memeriksa subarray rentang {i} s/d {j}, total sum = {sum}");
                    }

                    stepHijau.Add(bestRange.ToArray());
                }
            }
            if (lblLangkah != null) lblLangkah.Text = $"Langkah: 0 / {stepKeterangan.Count}";
        }

        private void GenerateDivideConquerSteps()
        {
            stepKuning.Clear();
            stepHijau.Clear();
            stepMerah.Clear();
            stepKeterangan.Clear();

            int[] globalMaxSum = { int.MinValue };
            List<int> globalBestRange = new List<int>();

            DnCStepVisual(0, fluktuasiSaham.Length - 1, globalMaxSum, globalBestRange);

            if (lblLangkah != null) lblLangkah.Text = $"Langkah: 0 / {stepKeterangan.Count}";
        }

        private int DnCStepVisual(int low, int high, int[] globalMaxSum, List<int> globalBestRange)
        {
            // --- 1. LANGKAH DIVIDE ---
            int mid = (low + high) / 2;

            if (low < high)
            {
                List<int> range = new List<int>();
                for (int i = low; i <= high; i++) range.Add(i);

                stepKuning.Add(range.ToArray());
                stepMerah.Add(mid);
                stepHijau.Add(globalBestRange.ToArray());

                stepKeterangan.Add($"[D&C Divide] Membagi array dari index {low}-{high} menjadi {low}-{mid} dan {mid + 1}-{high}");
            }

            // --- 2. LANGKAH BASE CASE ---
            if (low == high)
            {
                if (fluktuasiSaham[low] > globalMaxSum[0])
                {
                    globalMaxSum[0] = fluktuasiSaham[low];
                    globalBestRange.Clear();
                    globalBestRange.Add(low);
                }

                stepKuning.Add(new int[] { low });
                stepMerah.Add(-1);
                stepHijau.Add(globalBestRange.ToArray());

                stepKeterangan.Add($"[D&C Base Case] Base case tercapai di indeks {low}, Nilai = {fluktuasiSaham[low]} | Maksimum Global = {globalMaxSum[0]}");

                return fluktuasiSaham[low];
            }

            // --- 3. LANGKAH CONQUER (REKURSIF) ---
            int leftMax = DnCStepVisual(low, mid, globalMaxSum, globalBestRange);
            int rightMax = DnCStepVisual(mid + 1, high, globalMaxSum, globalBestRange);

            // --- 4. LANGKAH COMBINE (CROSSING) ---
            int crossMax = MaxCrossingVisual(low, mid, high, globalMaxSum, globalBestRange);

            return Math.Max(Math.Max(leftMax, rightMax), crossMax);
        }
        private int MaxCrossingVisual(int low, int mid, int high, int[] globalMaxSum, List<int> globalBestRange)
        {
            int leftSum = int.MinValue;
            int sum = 0;
            int maxLeftIdx = mid;

            for (int i = mid; i >= low; i--)
            {
                sum += fluktuasiSaham[i];
                if (sum > leftSum)
                {
                    leftSum = sum;
                    maxLeftIdx = i;
                }
            }

            int rightSum = int.MinValue;
            sum = 0;
            int maxRightIdx = mid + 1;

            for (int i = mid + 1; i <= high; i++)
            {
                sum += fluktuasiSaham[i];
                if (sum > rightSum)
                {
                    rightSum = sum;
                    maxRightIdx = i;
                }
            }

            int totalCross = leftSum + rightSum;

            List<int> crossRange = new List<int>();
            for (int k = maxLeftIdx; k <= maxRightIdx; k++) crossRange.Add(k);

            stepKuning.Add(crossRange.ToArray());
            stepMerah.Add(mid);

            if (totalCross > globalMaxSum[0])
            {
                globalMaxSum[0] = totalCross;
                globalBestRange.Clear();
                for (int k = maxLeftIdx; k <= maxRightIdx; k++) globalBestRange.Add(k);

                stepKeterangan.Add($"[D&C Combine] Profit maksimum BARU menyeberangi Mid ditemukan pada rentang {maxLeftIdx} s/d {maxRightIdx} dengan nilai = {totalCross}");
            }
            else
            {
                stepKeterangan.Add($"[D&C Combine] Memeriksa kombinasi persilangan rentang {maxLeftIdx} s/d {maxRightIdx}. Nilai kombinasi = {totalCross} (Tidak lebih besar dari maksimum global)");
            }

            stepHijau.Add(globalBestRange.ToArray());
            return totalCross;
        }

        private void rbBruteForce_CheckedChanged(object sender, EventArgs e)
        {
            if (fluktuasiSaham == null) return;

            if (rbBruteForce.Checked)
            {
                timerAuto.Stop();
                ClearColor();
                GenerateBruteForceSteps();
                currentStep = 0;
                txtKeterangan.Text = "Algoritma Brute Force dipilih. Tekan 'Next' atau 'Auto' untuk melihat visualisasi.";
            }
        }

        private void rbDivideConquer_CheckedChanged(object sender, EventArgs e)
        {
            if (fluktuasiSaham == null) return;

            if (rbDivideConquer.Checked)
            {
                timerAuto.Stop();
                ClearColor();
                GenerateDivideConquerSteps();
                currentStep = 0;
                txtKeterangan.Text = "Algoritma Divide & Conquer dipilih. Tekan 'Next' atau 'Auto' untuk melihat visualisasi.";
            }
        }

     //BENCHMARK BACKEND
        private void btnBenchmark_Click(object sender, EventArgs e)
        {
            int n = 10000;
            int[] dataBrute = new int[n];
            int[] dataDnC = new int[n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                int nilaiAcak = rnd.Next(-100, 100);
                dataBrute[i] = nilaiAcak;
                dataDnC[i] = nilaiAcak;
            }

            Stopwatch sw = new Stopwatch();

            // 1. Eksekusi Murni Brute Force di Belakang Layar
            sw.Start();
            PureBruteForce(dataBrute);
            sw.Stop();
            long bruteTime = sw.ElapsedMilliseconds;

            // 2. Eksekusi Murni Divide & Conquer di Belakang Layar
            sw.Restart();
            PureDivideAndConquer(dataDnC, 0, dataDnC.Length - 1);
            sw.Stop();
            long dncTime = sw.ElapsedMilliseconds;

            // 3. Menampilkan Hasil ke Form
            lblUkuranData.Text = $"Ukuran Data : {n}";
            lblBruteTime.Text = $"Brute Force : {bruteTime} ms";
            lblDncTime.Text = $"Divide & Conquer : {dncTime} ms";

            if (dncTime == 0)
            {
                double ratio = (double)bruteTime / 1;
                lblPerbandingan.Text = $"Perbandingan : Divide & Conquer ±{ratio:F2}x lebih cepat (Mendekati 0 ms)";
            }
            else
            {
                double ratio = (double)bruteTime / dncTime;
                lblPerbandingan.Text = $"Perbandingan : {ratio:F2}x lebih cepat";
            }
        }

        private int PureBruteForce(int[] arr)
        {
            int max = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                int sum = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    sum += arr[j];
                    if (sum > max) max = sum;
                }
            }
            return max;
        }

        private int PureDivideAndConquer(int[] arr, int left, int right)
        {
            if (left == right) return arr[left];

            int mid = (left + right) / 2;
            int leftMax = PureDivideAndConquer(arr, left, mid);
            int rightMax = PureDivideAndConquer(arr, mid + 1, right);
            int crossMax = PureMaxCrossing(arr, left, mid, right);

            return Math.Max(Math.Max(leftMax, rightMax), crossMax);
        }

        private int PureMaxCrossing(int[] arr, int left, int mid, int right)
        {
            int sum = 0;
            int leftSum = int.MinValue;
            for (int i = mid; i >= left; i--)
            {
                sum += arr[i];
                if (sum > leftSum) leftSum = sum;
            }

            sum = 0;
            int rightSum = int.MinValue;
            for (int i = mid + 1; i <= right; i++)
            {
                sum += arr[i];
                if (sum > rightSum) rightSum = sum;
            }
            return leftSum + rightSum;
        }
    }
}