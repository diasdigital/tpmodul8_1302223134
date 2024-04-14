using tpmodul8_1302223134;

AppConfig configApp = new AppConfig();

configApp.UbahSatuan();

Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {configApp.config.satuan_suhu} : ");
double suhu = Convert.ToDouble(Console.ReadLine());

Console.Write($"Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? : ");
int lama_demam = int.Parse(Console.ReadLine());

if (((configApp.config.satuan_suhu == "celcius" && suhu >= 36.5 && suhu <= 37.5) ||
            (configApp.config.satuan_suhu == "fahrenheit" && suhu >= 97.7 && suhu <= 99.5)) &&
            lama_demam < configApp.config.batas_hari_demam)
{
    Console.WriteLine(configApp.config.pesan_diterima);
}
else
{
    Console.WriteLine(configApp.config.pesan_ditolak);
}