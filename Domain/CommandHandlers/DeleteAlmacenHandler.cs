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
    public class DeleteAlmacenHandler : IRequestHandler<DeleteAlmacenCommand, bool>
    {
        private readonly IInventoryRepository _inventoryRepository;
        public DeleteAlmacenHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public Task<bool> Handle(DeleteAlmacenCommand request, CancellationToken cancellationToken)
        {
            Almacen almacen = new Almacen {AlmacenId=request.AlmacenId };


            _inventoryRepository.DeleteAlmacen(almacen);
            _inventoryRepository.SaveChanges();
            return Task.FromResult(true);
        }

    }
}
