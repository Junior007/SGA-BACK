using Inventory.Domain.Interfaces;
using Inventory.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MediatR;
using Inventory.Application.Models;
using Inventory.Domain.Commands;
using Inventory.Domain.Model;

namespace Inventory.Application.Service
{
    public class ItemsService : IItemsService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMediator _mediator;
        public ItemsService(IInventoryRepository inventoryRepository, IMediator mediator)
        {
            _mediator = mediator;
            _inventoryRepository = inventoryRepository;
        }
        void IItemsService.Create(ItemDTO itemForCreate)
        {
            CreateItemCommand createItemCommand = new CreateItemCommand { ItemId = itemForCreate.ItemId, Descripcion = itemForCreate.Descripcion };
            var result = _mediator.Send(createItemCommand);
        }

        void IItemsService.Update(ItemDTO itemForUpdate)
        {
            UpdateItemCommand updateItemCommand = new UpdateItemCommand(itemForUpdate.ItemId, itemForUpdate.Descripcion);
            var result = _mediator.Send(updateItemCommand);
        }

        void IItemsService.Delete(ItemDTO itemForDelete)
        {
            DeleteItemCommand createItemCommand = new DeleteItemCommand { ItemId = itemForDelete.ItemId };
            var result = _mediator.Send(createItemCommand);
        }

        Item IItemsService.GetItem(string itemId)
        {
            return _inventoryRepository.GetItem(itemId); ;
        }

        IEnumerable<Item> IItemsService.GetItems()
        {
            return _inventoryRepository.GetItems();
        }

        public void SetStock(StockDTO stockDTO)
        {
            SetStockCommand setStockCommand = new SetStockCommand { ItemId = stockDTO.ItemId, UbicacionId = stockDTO.UbicacionId, AlmacenId = stockDTO.AlmacenId, Cantidad=stockDTO.Cantidad };
            var result = _mediator.Send(setStockCommand);
        }
    }
}


