using System;
namespace WebApi;

enum PedidoEstado
{
    Pendiente,
    Entregado,
    Cancelado
}

public class Pedido
{
    //campos
    private int nro;
    private string? observacion;
    private Cliente cliente;
    private PedidoEstado estado;
    private Cadete cadete;

    //propiedades
    public int Nro { get => nro; set => nro = value; }
    public string? Observacion { get => observacion; set => observacion = value; }
    internal Cliente Cliente { get => cliente; set => cliente = value; }
    internal PedidoEstado Estado { get => estado; set => estado = value; }
    public Cadete Cadete { get => cadete; set => cadete = value; }

    //constructor
    public Pedido (int nro, string obs, string nombre, string direccion, string telefono, string datosReferenciaDireccion)
    {
        Nro = nro;
        Observacion = observacion;
        Estado = PedidoEstado.Pendiente;
        Cliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
        Cadete = null;
    }

    //metodos
    public string VerDireccionCliente()
    {
        return Cliente.Direccion;
    }

    public string VerDatosCliente()
    {
        return Cliente.Nombre + ", " + Cliente.Telefono;
    }
}