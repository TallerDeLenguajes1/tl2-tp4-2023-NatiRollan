using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CadeteriaController : ControllerBase
{
    private Cadeteria cadeteria;
    private readonly ILogger<CadeteriaController> _logger;

    public CadeteriaController(ILogger<CadeteriaController> logger)
    {
        _logger = logger;
        cadeteria = Cadeteria.GetInstance();
    }

    [HttpGet("GetCadeteria")]
    public ActionResult<string> GetCadeteria()
    {
        return Ok(cadeteria);
    }

    [HttpGet("GetPedidos")]
    public ActionResult<List<Pedido>> GetPedido()
    {
        List<Pedido> Pedidos = cadeteria.GetPedidos();
        return Ok(Pedidos);
    }

    [HttpGet("GetCadetes")]
    public ActionResult<List<Cadete>> GetCadete()
    {
        List<Cadete> Cadetes = cadeteria.GetCadetes();
        return Ok(Cadetes);
    }

    [HttpGet("GetInforme")]
    public ActionResult<Informe> GetInforme()
    {
        Informe info = cadeteria.GetInforme();
        return Ok(info);
    }

    [HttpGet("GetCadete")]
    public ActionResult<Cadete> GetCadete(int idCadete)
    {
        Cadete cadeteBuscado = cadeteria.GetCadete(idCadete);

        if (cadeteBuscado != null)
        {
            return Ok(cadeteBuscado);
        } else
        {
            return NotFound();
        }
    }

    [HttpGet("GetPedido")]
    public ActionResult<Pedido> GetPedido(int idPedido)
    {
        Pedido pedidoBuscado = cadeteria.BuscarPedido(idPedido);

        if (pedidoBuscado != null)
        {
            return Ok(pedidoBuscado);
        } else
        {
            return NotFound();
        }
    }

    [HttpPost("AgregarPedido")]
    public ActionResult<Pedido> AgregarPedido(Pedido nuevoPedido)
    {
        cadeteria.AgregarPedido(nuevoPedido);
        return Ok(nuevoPedido);
    }

    [HttpPost("AgregarCadete")]
    public ActionResult<Cadete> AddCadete(Cadete cadete)
    {
        bool control = cadeteria.AgregarCadete(cadete);
        if (control)
        {
            return Ok(cadete);
        } else
        {
            return BadRequest();
        }
    }

    [HttpPut("AsignarCadeteAPedido")]
    public ActionResult<Pedido> AsignarCadeteAPedido(int nroPedido, int idCadete)
    {
        cadeteria.AsignarCadeteAPedido(nroPedido, idCadete);
        Pedido pedidoAsignado = cadeteria.BuscarPedido(nroPedido);
        return Ok(pedidoAsignado);
    }

    [HttpPut("CambiarEstadoPedido")]
    public ActionResult<Pedido> CambiarEstadoPedido(int nroPedido, int estado)
    {
        cadeteria.CambiarEstadoPedido(nroPedido, estado);
        Pedido pedidoCambiado = cadeteria.BuscarPedido(nroPedido);
        return Ok(pedidoCambiado);
    }

    [HttpPut("CambiarCadetePedido")]
    public ActionResult<Pedido> ReasignarPedido(int nroPedido, int idC)
    {
        cadeteria.ReasignarPedido(nroPedido, idC);
        Pedido pedidoReasignado = cadeteria.BuscarPedido(nroPedido);
        return Ok(pedidoReasignado);
    }

}