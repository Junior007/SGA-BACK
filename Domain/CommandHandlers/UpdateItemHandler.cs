using InventoryDomain.Commands;
using InventoryDomain.Interfaces;
using InventoryDomain.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryDomain.CommandHandlers
{
    public class UpdateItemHandler : IRequestHandler<UpdateItemCommand, bool>
    {
        private readonly IInventoryRepository _inventoryRepository;
        public UpdateItemHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public Task<bool> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            Item item = new Item {ItemId=request.ItemId, Descripcion=request.Descripcion };


            _inventoryRepository.UpdateItem(item);
            _inventoryRepository.SaveChanges();
            return Task.FromResult(true);
        }

    }
}
