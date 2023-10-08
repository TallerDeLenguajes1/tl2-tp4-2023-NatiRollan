using System;
namespace WebApi;

public enum PedidoEstado
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
    private int idCadete;

    //propiedades
    public int Nro { get => nro; set => nro = value; }
    public string? Observacion { get => observacion; set => observacion = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public PedidoEstado Estado { get => estado; set => estado = value; }
    public int IdCadete { get => idCadete; set => idCadete = value; }


    //constructor
    public Pedido()
    {

    }
    
    public Pedido (int nro, string obs, string nombre, string direccion, string telefono, string datosReferenciaDireccion)
    {
        Nro = nro;
        Observacion = observacion;
        Estado = PedidoEstado.Pendiente;
        Cliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
        IdCadete = -9999;       
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