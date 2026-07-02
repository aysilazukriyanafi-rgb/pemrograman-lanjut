using System;

namespace Project_UAS_Manajemen_Bangun_Geometri
{
    
    public abstract class BangunGeometri
    {
        public int Id { get; set; }
        public string NamaObjek { get; set; }
        public string TipeBangun { get; set; }

        public abstract double HitungLuas();
        public abstract double HitungKeliling();
        public abstract string DapatkanDimensiTeks();
    }

    
    public class Persegi : BangunGeometri
    {
        public double Sisi { get; set; }

        public Persegi(string nama, double sisi)
        {
            NamaObjek = nama;
            TipeBangun = "Persegi";
            Sisi = sisi;
        }

        public override double HitungLuas() => Sisi * Sisi;
        public override double HitungKeliling() => 4 * Sisi;
        public override string DapatkanDimensiTeks() => $"Sisi={Sisi}";
    }

    
    public class PersegiPanjang : BangunGeometri
    {
        public double Panjang { get; set; }
        public double Lebar { get; set; }

        public PersegiPanjang(string nama, double panjang, double lebar)
        {
            NamaObjek = nama;
            TipeBangun = "Persegi Panjang";
            Panjang = panjang;
            Lebar = lebar;
        }

        public override double HitungLuas() => Panjang * Lebar;
        public override double HitungKeliling() => 2 * (Panjang + Lebar);
        public override string DapatkanDimensiTeks() => $"P={Panjang}, L={Lebar}";
    }

    
    public class Lingkaran : BangunGeometri
    {
        public double JariJari { get; set; }

        public Lingkaran(string nama, double jariJari)
        {
            NamaObjek = nama;
            TipeBangun = "Lingkaran";
            JariJari = jariJari;
        }

        public override double HitungLuas() => Math.PI * JariJari * JariJari;
        public override double HitungKeliling() => 2 * Math.PI * JariJari;
        public override string DapatkanDimensiTeks() => $"r={JariJari}";
    }
}