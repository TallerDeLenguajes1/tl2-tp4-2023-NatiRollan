using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
namespace WebApi;

public class AccesoADatosPedidos
{
    public List<Pedido> Obtener()
    {
        if (File.Exists("Pedidos.json"))
        {
            string? jsonstring = File.ReadAllText("Pedidos.json");
            List<Pedido>? ListaPedidos = JsonSerializer.Deserialize<List<Pedido>>(jsonstring);

            return ListaPedidos;
        }
        else
        {
            return null;
        }
    }

    public void Guardar(List<Pedido> pedidos)
    {
        string listadoPedidosJson = JsonSerializer.Serialize(pedidos);
        File.WriteAllText("Pedidos.json", listadoPedidosJson);
    }
}