using System;
namespace WebApi;

public class Cliente
{
    //Campos
    private string? nombre;
    private string? direccion;
    private string? telefono;
    private string? datosReferenciaDireccion;

    //Propiedades
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Direccion { get => direccion; set => direccion = value; }
    public string? Telefono { get => telefono; set => telefono = value; }
    public string? DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }

    //Costructor
    public Cliente (string nombre, string direccion, string telefono, string datosReferenciaDireccion)
    {
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        DatosReferenciaDireccion = datosReferenciaDireccion;
    }
}