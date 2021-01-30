using Inventory.Domain.Commands;
using Inventory.Domain.Interfaces;
using Inventory.Domain.Model;
using MediatR;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Domain.CommandHandlers
{
    public class CreateItemHandler : IRequestHandler<CreateItemCommand, bool>
    {
        private readonly IInventoryRepository _inventoryRepository;
        public CreateItemHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public Task<bool> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            Item item = new Item {ItemId=request.ItemId, Descripcion=request.Descripcion };


            _inventoryRepository.CreateItem(item);
            _inventoryRepository.SaveChanges();
            return Task.FromResult(true);
        }

    }
}
