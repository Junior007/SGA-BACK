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
    public class CreateAlmacenHandler : IRequestHandler<CreateAlmacenCommand, bool>
    {
        private readonly IInventoryRepository _inventoryRepository;
        public CreateAlmacenHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public Task<bool> Handle(CreateAlmacenCommand request, CancellationToken cancellationToken)
        {
            Almacen almacen = new Almacen {AlmacenId=request.AlmacenId, Descripcion=request.Descripcion };


            _inventoryRepository.CreateAlmacen(almacen);
            _inventoryRepository.SaveChanges();
            return Task.FromResult(true);
        }

    }
}
