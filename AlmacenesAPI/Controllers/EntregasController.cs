using Entregas.Application.Interfaces;
using Entregas.Application.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionTablasAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class EntregasController : ControllerBase
    {
        private readonly IEntregasService _entregasService;
        //IMapper _mapper;
        public EntregasController(IEntregasService entregasService)//, IMapper mapper)
        {
            _entregasService = entregasService;
            //_mapper = mapper;
        }
        [Route("pedidos")]
        [HttpPost]
        public ActionResult PostPedido([FromBody] PedidoForCreate pedidoForCreate)
        {

            try
            {
                _entregasService.CrearPedido(pedidoForCreate);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
/*
[HttpGet]
public ActionResult<IEnumerable<Entrega>> Get()
{
    var entregas = _entregasService.Entregas();
    //_mapper.Map<IEnumerable<InventoryAPI.Models.Entrega>>(entregas);
    return Ok(entregas);
}

//
[HttpGet("{entregaId}")]
public ActionResult<Entrega> Get(string entregaId)
{
    var entrega = _entregasService.GetEntrega(entregaId);
    //var entregaForView = _mapper.Map<InventoryAPI.Models.Entrega>(entrega);
    return Ok(entrega);
}
//
// POST api/values
[HttpPost]
public ActionResult Post([FromBody] EntregaDTO entregaForCreate)
{

    try
    {
        _entregasService.Create(entregaForCreate);
        return Ok();
    }
    catch (Exception ex)
    {

        return BadRequest(ex.Message);
    }
}

// PUT api/values/5
[HttpPut]
[Route("{entregaId}")]
public ActionResult Put(string entregaId, [FromBody] EntregaDTO entregaForUpdate)
{
    if (entregaId != entregaForUpdate.EntregaId)
    {
        return BadRequest("distintos id");
    }
    try
    {
        _entregasService.Update(entregaForUpdate);
        return Ok();
    }
    catch (Exception ex)
    {

        return BadRequest(ex.Message);
    }

}

// DELETE api/values/5
[HttpDelete]
[Route("{entregaId}")]
public ActionResult Delete(string entregaId, [FromBody] EntregaDTO entregaForDelete)
{
    if (entregaId != entregaForDelete.EntregaId)
    {
        return BadRequest("distintos id");
    }
    try
    {
        _entregasService.Delete(entregaForDelete);
        return Ok();
    }
    catch (Exception ex)
    {

        return BadRequest(ex.Message);
    }
}
//Ubicaciones
// POST api/values
[HttpPost]
[Route("{entregaId}/AddUbicacion")]
public ActionResult AddUbicacion(string entregaId, [FromBody] UbicacionDTO ubicacionForCreate)
{
    if (entregaId != ubicacionForCreate.EntregaId)
    {
        return BadRequest("distintos id");
    }
    try
    {
        _entregasService.CreateUbicacion(ubicacionForCreate);
        return Ok();
    }
    catch (Exception ex)
    {

        return BadRequest(ex.Message);
    }
}






*/

