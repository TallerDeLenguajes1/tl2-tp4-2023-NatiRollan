using System;
using System.Collections.Generic;
namespace WebApi;

public class Cadeteria
{
    //Campos
    private string? nombre;
    private string? telefono;
    private List<Cadete> listadoCadetes;
    private List<Pedido> listadoPedidos;
    private static Cadeteria instance;
    private AccesoADatosPedidos accesoPedidos = new AccesoADatosPedidos();

    //Propiedades
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }


    public static Cadeteria GetInstance()
    {
        if (instance == null)
        {
            AccesoADatosCadeteria helpCadeteria = new AccesoADatosCadeteria();
            instance = helpCadeteria.Obtener();
            AccesoADatosCadetes helpCadetes = new AccesoADatosCadetes();
            instance.ListadoCadetes = helpCadetes.Obtener();
        }

        return instance;
    }

    //Constructores
    public Cadeteria()
    {
        listadoCadetes = new List<Cadete>();
        listadoPedidos = new List<Pedido>();
    }

    public Cadeteria(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
        listadoCadetes = new List<Cadete>();
        listadoPedidos = new List<Pedido>();
    }

    //Metodos
    public List<Pedido> GetPedidos()
    {
        return accesoPedidos.Obtener();
    }

    public List<Cadete> GetCadetes()
    {
        return ListadoCadetes;
    }

    public Informe GetInforme()
    {
        Informe info = new Informe(ListadoCadetes, ListadoPedidos, instance);
        return info;
    }

    public bool AgregarPedido(Pedido pedidoNuevo)
    {
        ListadoPedidos.Add(pedidoNuevo);
        pedidoNuevo.Nro = ListadoPedidos.Count();
        accesoPedidos.Guardar(ListadoPedidos);

        if (ListadoPedidos.FirstOrDefault(p => p.Nro == pedidoNuevo.Nro) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AsignarCadeteAPedido(int nroPedido, int idCadete)
    {
        if (ListadoCadetes != null)
        {
            Cadete? cadEncontrado = ListadoCadetes.FirstOrDefault(cadete => cadete.Id == idCadete);
            Pedido? pedEncontrado = ListadoPedidos.FirstOrDefault(ped => ped.Nro == nroPedido);
            if (cadEncontrado != null && pedEncontrado != null)
            {
                pedEncontrado.IdCadete = cadEncontrado.Id;
                accesoPedidos.Guardar(ListadoPedidos);
                return true;
            } else
            {
                return false;
            }
        } else
        {
            return false;
        }
    }

    public bool CambiarEstadoPedido(int nroPedido, int estado)
    {
        Pedido? pedido = ListadoPedidos.FirstOrDefault(ped => ped.Nro == nroPedido);
        if (pedido != null)
        {
            if (estado == 1)
            {
                pedido.Estado = PedidoEstado.Entregado;
                accesoPedidos.Guardar(ListadoPedidos);
                return true;
            }
            else
            {
                pedido.Estado = PedidoEstado.Cancelado;
                accesoPedidos.Guardar(ListadoPedidos);
                return true;
            }         
        } else
        {
            return false;
        }
    }

    public bool ReasignarPedido(int nroPedido, int idC)
    {
        Cadete? cadEncontrado = ListadoCadetes.FirstOrDefault(cadete => cadete.Id == idC);
        if (cadEncontrado != null)
        {
            ListadoPedidos = accesoPedidos.Obtener();
            Pedido? pedidoE = ListadoPedidos.FirstOrDefault(ped => ped.Nro == nroPedido);
            if (pedidoE.IdCadete != -9999)  //verifico si el pedido ya tiene asignado un cadete
            {
                pedidoE.IdCadete = -9999;
            }
            pedidoE.IdCadete = cadEncontrado.Id;  // asigno el nuevo cadete al pedido
            accesoPedidos.Guardar(ListadoPedidos);
            return true;
        } else
        {
            return false;
        }
    }

    public float JornalACobrar(int idCadete)
    {
        var pedidosEntregados = ListadoPedidos.Where(pedido => pedido.Estado == PedidoEstado.Entregado);
        if (pedidosEntregados != null)
        {
            int pedidosCadete = pedidosEntregados.Count(ped => ped.IdCadete == idCadete);
            if (pedidosCadete != 0)
            {
                return pedidosCadete * 500;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }

    public Pedido BuscarPedido(int idP)
    {
        Pedido? pedidoBuscado = listadoPedidos.FirstOrDefault(p => p.Nro == idP);
        return pedidoBuscado;
    }

    /*public void MostrarInforme()
    {
        Console.WriteLine($"=========== Informe de {Nombre} ===============");
        Console.WriteLine($"Número de cadetes: {ListadoCadetes.Count()}");

        float totalGanado = 0;
        foreach (Cadete cadete in ListadoCadetes)
        {
            var pedidosEntregados = ListadoPedidos.Where(pedido => pedido.Estado == PedidoEstado.Entregado);
            int pedidosCadete = pedidosEntregados.Count(ped => ped.Cadete.Id == cadete.Id);
            totalGanado += JornalACobrar(cadete.Id);

            Console.WriteLine($"Cadete: {cadete.Nombre}");
            Console.WriteLine($"- Pedidos Entregados: {pedidosCadete}");
            Console.WriteLine($"- Monto ganado: ${JornalACobrar(cadete.Id)}");
            Console.WriteLine("---------------------------------------------");
        }

        Console.WriteLine($"Total Ganado: ${totalGanado}");
    }*/

}