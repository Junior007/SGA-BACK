using InventoryDomain.Commands;
using InventoryDomain.Interfaces;
using InventoryDomain.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryDomain.CommandHandlers
{
    public class UpdateAlmacenHandler : IRequestHandler<UpdateAlmacenCommand, bool>
    {
        private readonly IInventoryRepository _inventoryRepository;
        public UpdateAlmacenHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public Task<bool> Handle(UpdateAlmacenCommand request, CancellationToken cancellationToken)
        {
            Almacen almacen = new Almacen {AlmacenId=request.AlmacenId, Descripcion=request.Descripcion };


            _inventoryRepository.UpdateAlmacen(almacen);
            _inventoryRepository.SaveChanges();
            return Task.FromResult(true);
        }

    }
}
