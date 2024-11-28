using System.IO;
using Newtonsoft.Json.Linq;

public static class DatabaseConfig
{
    public static string GetConnectionString()
    {
        var json = File.ReadAllText("appsettings.json");
        var jObject = JObject.Parse(json);
        return jObject["ConnectionStrings"]["MySQL"].ToString();
    }
}
