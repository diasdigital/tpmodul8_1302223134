using System.Text.Json;

namespace tpmodul8_1302223134;

public class CovidConfig
{
    public String satuan_suhu { get; set; }
    public int batas_hari_demam { get; set; }
    public String pesan_ditolak { get; set; }
    public String pesan_diterima { get; set; }
}

public class AppConfig
{
    public CovidConfig config;
    private const String file_path = "../../../covid_config.json";

    private void ReadConfigFile()
    {
        String configJsonData = File.ReadAllText(file_path);
        config = JsonSerializer.Deserialize<CovidConfig>(configJsonData);
    }

    private void WriteNewConfigFile()
    {
        JsonSerializerOptions option = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        String jsonString = JsonSerializer.Serialize(config, option);
        File.WriteAllText(file_path, jsonString);
    }

    private void SetDefault()
    {
        config = new CovidConfig();

        config.satuan_suhu = "celcius";
        config.batas_hari_demam = 14;
        config.pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        config.pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
    }

    public AppConfig()
    {
        try
        {
            ReadConfigFile();
        }
        catch
        {
            SetDefault();
            WriteNewConfigFile();
        }
    }
    public void UbahSatuan()
    {
        config.satuan_suhu = (config.satuan_suhu == "celcius") ? "fahrenheit" : "celcius";

        WriteNewConfigFile();
    }
}
