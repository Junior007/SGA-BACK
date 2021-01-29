using InventoryDomain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryApplication.Interfaces;
using InventoryApplication.Models;

namespace InventoryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsService _itemsService;
        public ItemsController(IItemsService itemsService)
        {
            _itemsService = itemsService;
        }
        //
        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get()
        {
            return Ok(_itemsService.GetItems());
        }
        //
        [HttpGet("{itemId}")]
        public ActionResult<Item> Get(string itemId)
        {
            return Ok(_itemsService.GetItem(itemId));
        }
        //
        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] ItemDTO itemForCreate)
        {
            
            try
            {
                _itemsService.Create(itemForCreate);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut]
        [Route("{itemId}")]
        public ActionResult Put(string itemId, [FromBody] ItemDTO itemForUpdate)
        {
            if (itemId != itemForUpdate.ItemId)
            {
                return BadRequest("distintos id");
            }
            try
            {
                _itemsService.Update(itemForUpdate);
                return Ok();
            }catch(Exception ex){

                return BadRequest(ex.Message);
            }

        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("{itemId}")]
        public ActionResult Delete(string itemId, [FromBody] ItemDTO ItemForDelete)
        {
            if (itemId != ItemForDelete.ItemId)
            {
                return BadRequest("distintos id");
            }
            try
            {
                _itemsService.Delete(ItemForDelete);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        //
        [HttpPost]
        [Route("{itemId}/{ubicacionId}/{almacenId}/SetStock")]
        public ActionResult SetStock(string itemId, string ubicacionId, string almacenId, [FromBody] StockDTO stockDTO)
        {
            if ((almacenId != stockDTO.AlmacenId || ubicacionId != stockDTO.UbicacionId || itemId != stockDTO.ItemId)&& stockDTO.Cantidad<0)
            {
                return BadRequest("distintos id");
            }
            try
            {
                _itemsService.SetStock(stockDTO);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
