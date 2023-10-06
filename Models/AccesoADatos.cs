using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace WebApi;

public class AccesoADatos
{
    public virtual List<Cadete> LeerArchivoCadete(string nombreDeArchivo)
    {
        return null;
    }

    public virtual Cadeteria LeerArchivoCadeteria(string nombreDeArchivo)
    {
        return null;
    }
}

public class AccesoCSV : AccesoADatos
{
    public override List<Cadete> LeerArchivoCadete(string nombreDeArchivo)
    {
        List<Cadete> ListaCadetes = new List<Cadete>();
        string linea = "";

        if (File.Exists(nombreDeArchivo))
        {
            FileStream archivo = new FileStream(nombreDeArchivo, FileMode.Open);
            StreamReader strReader = new StreamReader(archivo);

            while ((linea = strReader.ReadLine()) != null)
            {
                string[] fila = linea.Split(",").ToArray();
                Cadete cadete = new Cadete(int.Parse(fila[0]), fila[1], fila[2], fila[3]);
                ListaCadetes.Add(cadete);
            }
            strReader.Close();
            return ListaCadetes;
        }
        else
        {
            return null;
        }
    }

    public override Cadeteria LeerArchivoCadeteria(string nombreDeArchivo)
    {
        Cadeteria? miCadeteria = null;
        string linea = "";

        if (File.Exists(nombreDeArchivo))
        {
            FileStream archivo = new FileStream(nombreDeArchivo, FileMode.Open);
            StreamReader strReader = new StreamReader(archivo);

            while ((linea = strReader.ReadLine()) != null)
            {
                string[] fila = linea.Split(",").ToArray();
                miCadeteria = new Cadeteria(fila[0], fila[1]);
            }
            strReader.Close();
        }
        else
        {
            return null;
        }
        return miCadeteria;
    }
}

public class AccesoJSON: AccesoADatos
{
    public override List<Cadete> LeerArchivoCadete(string nombreDeArchivo)
    {
        if (File.Exists(nombreDeArchivo))
        {
            string? jsonstring = File.ReadAllText(nombreDeArchivo);
            List<Cadete>? ListaCadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonstring);

            return ListaCadetes;
        } else
        {
            return null;
        }
    }

    public override Cadeteria LeerArchivoCadeteria(string nombreDeArchivo)
    {
        if (File.Exists(nombreDeArchivo))
        {
            string? jsonstring = File.ReadAllText(nombreDeArchivo);
            Cadeteria? miCadeteria = JsonSerializer.Deserialize<Cadeteria>(jsonstring);
            return miCadeteria;
        } else
        {
            return null;
        }
    }
}