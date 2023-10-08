using System;
using System.IO;
using System.Text.Json;
namespace WebApi;

public class AccesoADatosCadeteria
{
    public Cadeteria Obtener()
    {
        if (File.Exists("Cadeteria.json"))
        {
            string? jsonstring = File.ReadAllText("Cadeteria.json");
            Cadeteria? miCadeteria = JsonSerializer.Deserialize<Cadeteria>(jsonstring);
            return miCadeteria;
        }
        else
        {
            return null;
        }
    }
}
