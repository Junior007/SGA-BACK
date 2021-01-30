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
    public class CreateUbicacionHandler : IRequestHandler<CreateUbicacionCommand, bool>
    {
        private readonly IInventoryRepository _inventoryRepository;
        public CreateUbicacionHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public Task<bool> Handle(CreateUbicacionCommand request, CancellationToken cancellationToken)
        {
            Ubicacion ubicacion = new Ubicacion { AlmacenId = request.AlmacenId, UbicacionId = request.UbicacionId, Descripcion =request.Descripcion };


            _inventoryRepository.CreateUbicacion(ubicacion);
            _inventoryRepository.SaveChanges();
            return Task.FromResult(true);
        }

    }
}
