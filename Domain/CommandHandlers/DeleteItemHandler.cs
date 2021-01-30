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
    public class DeleteItemHandler : IRequestHandler<DeleteItemCommand, bool>
    {
        private readonly IInventoryRepository _inventoryRepository;
        public DeleteItemHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public Task<bool> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            Item item = new Item {ItemId=request.ItemId };


            _inventoryRepository.DeleteItem(item);
            _inventoryRepository.SaveChanges();
            return Task.FromResult(true);
        }

    }
}
