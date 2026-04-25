using System;
using TP_MOD9_103022400064;

namespace TP_MOD9_103022400064
{
    class Program
    {
        static void Main(string[] args)
        {
            CovidConfig covidConfig = new CovidConfig();

            // Jalankan pertama kali dengan satuan default
            JalankanAplikasi(covidConfig);

            Console.WriteLine("\n--- Mengubah Satuan Suhu ---");
            covidConfig.UbahSatuan();
            JalankanAplikasi(covidConfig);
        }

        static void JalankanAplikasi(CovidConfig configObj)
        {
            Config currentConf = configObj.conf;

            Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {currentConf.satuan_suhu}: ");
            double suhu = double.Parse(Console.ReadLine());

            Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman? ");
            int hari = int.Parse(Console.ReadLine());

            bool suhuValid = false;
            if (currentConf.satuan_suhu == "celcius")
            {
                if (suhu >= 36.5 && suhu <= 37.5) suhuValid = true;
            }
            else if (currentConf.satuan_suhu == "fahrenheit")
            {
                if (suhu >= 97.7 && suhu <= 99.5) suhuValid = true;
            }

            bool hariValid = hari < currentConf.batas_hari_deman;

            if (suhuValid && hariValid)
            {
                Console.WriteLine(currentConf.pesan_diterima);
            }
            else
            {
                Console.WriteLine(currentConf.pesan_ditolak);
            }
        }
    }
}