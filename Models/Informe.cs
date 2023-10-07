using System;
using System.Collections.Generic;
namespace WebApi;

public class Informe
{
    //Campos
    private float totalGanado;
    private float montoCadete;
    private int ctdadEnviosCadete;

    //Propiedades
    public float TotalGanado { get => totalGanado; set => totalGanado = value; }
    public float MontoCadete { get => montoCadete; set => montoCadete = value; }
    public int CtdadEnviosCadete { get => ctdadEnviosCadete; set => ctdadEnviosCadete = value; }

    //Constructor
    public Informe(List<Cadete> listaCadete, List<Pedido> listaPedido, Cadeteria cadeteria)
    {
        MontoCadete =0;
        CtdadEnviosCadete =0;
        TotalGanado =0;

        Console.WriteLine($"=========== Informe de {cadeteria.Nombre} ===============");
        Console.WriteLine($"Número de cadetes: {listaCadete.Count()}");

        foreach (Cadete cadete in listaCadete)
        {
            var pedidosEntregados = listaPedido.Where(pedido => pedido.Estado == PedidoEstado.Entregado);
            ctdadEnviosCadete = pedidosEntregados.Count(ped => ped.IdCadete == cadete.Id);
            TotalGanado += cadeteria.JornalACobrar(cadete.Id);
            MontoCadete = cadeteria.JornalACobrar(cadete.Id);

            Console.WriteLine($"Cadete: {cadete.Nombre}");
            Console.WriteLine($"- Pedidos Entregados: {CtdadEnviosCadete}");
            Console.WriteLine($"- Monto ganado: ${MontoCadete}");
            Console.WriteLine("---------------------------------------------");
        }

        Console.WriteLine($"Total Ganado: ${TotalGanado}");
    }

}