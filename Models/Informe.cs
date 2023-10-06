using System;
using System.Collections.Generic;
namespace WebApi;

public class Informe
{
    //Campos
    private float totalGanado=0;
    private float montoCadete;
    private int ctdadEnviosCadete;

    //Propiedades
    public float MontoTotal { get => totalGanado; set => totalGanado = value; }
    public float MontoCadete { get => montoCadete; set => montoCadete = value; }
    public int CtdadEnviosCadete { get => ctdadEnviosCadete; set => ctdadEnviosCadete = value; }

    //Constructor
    public Informe(List<Cadete> listaCadete, List<Pedido> listaPedido, Cadeteria cadeteria)
    {
        Console.WriteLine($"=========== Informe de {cadeteria.Nombre} ===============");
        Console.WriteLine($"Número de cadetes: {listaCadete.Count()}");

        foreach (Cadete cadete in listaCadete)
        {
            var pedidosEntregados = listaPedido.Where(pedido => pedido.Estado == PedidoEstado.Entregado);
            int pedidosCadete = pedidosEntregados.Count(ped => ped.Cadete.Id == cadete.Id);
            totalGanado += cadeteria.JornalACobrar(cadete.Id);

            Console.WriteLine($"Cadete: {cadete.Nombre}");
            Console.WriteLine($"- Pedidos Entregados: {pedidosCadete}");
            Console.WriteLine($"- Monto ganado: ${cadeteria.JornalACobrar(cadete.Id)}");
            Console.WriteLine("---------------------------------------------");
        }

        Console.WriteLine($"Total Ganado: ${totalGanado}");
    }

}