using InventoryDomain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryApplication.Interfaces;
using InventoryApplication.Models;
using AutoMapper;

namespace InventoryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlmacenesController : ControllerBase
    {
        private readonly IAlmacenesService _almacenesService;
        //IMapper _mapper;
        public AlmacenesController(IAlmacenesService almacenesService)//, IMapper mapper)
        {
            _almacenesService = almacenesService;
            //_mapper = mapper;
        }
        //
        [HttpGet]
        public ActionResult<IEnumerable<Almacen>> Get()
        {
            var almacenes = _almacenesService.GetAlmacenes();
            //_mapper.Map<IEnumerable<InventoryAPI.Models.Almacen>>(almacenes);
            return Ok(almacenes);
        }
        //
        [HttpGet("{almacenId}")]
        public ActionResult<Almacen> Get(string almacenId)
        {
            var almacen = _almacenesService.GetAlmacen(almacenId);
            //var almacenForView = _mapper.Map<InventoryAPI.Models.Almacen>(almacen);
            return Ok(almacen);
        }
        //
        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] AlmacenDTO almacenForCreate)
        {

            try
            {
                _almacenesService.Create(almacenForCreate);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut]
        [Route("{almacenId}")]
        public ActionResult Put(string almacenId, [FromBody] AlmacenDTO almacenForUpdate)
        {
            if (almacenId != almacenForUpdate.AlmacenId)
            {
                return BadRequest("distintos id");
            }
            try
            {
                _almacenesService.Update(almacenForUpdate);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("{almacenId}")]
        public ActionResult Delete(string almacenId, [FromBody] AlmacenDTO almacenForDelete)
        {
            if (almacenId != almacenForDelete.AlmacenId)
            {
                return BadRequest("distintos id");
            }
            try
            {
                _almacenesService.Delete(almacenForDelete);
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
        [Route("{almacenId}/AddUbicacion")]
        public ActionResult AddUbicacion(string almacenId, [FromBody] UbicacionDTO ubicacionForCreate)
        {
            if (almacenId != ubicacionForCreate.AlmacenId)
            {
                return BadRequest("distintos id");
            }
            try
            {
                _almacenesService.CreateUbicacion(ubicacionForCreate);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
