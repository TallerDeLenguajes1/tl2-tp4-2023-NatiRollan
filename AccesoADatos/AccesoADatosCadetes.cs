using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
namespace WebApi;

public class AccesoADatosCadetes
{
    public List<Cadete> Obtener()
    {
        if (File.Exists("Cadetes.json"))
        {
            string? jsonstring = File.ReadAllText("Cadetes.json");
            List<Cadete>? ListaCadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonstring);

            return ListaCadetes;
        }
        else
        {
            return null;
        }
    }
}
