using InventoryDomain.Interfaces;
using InventoryApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MediatR;
using InventoryApplication.Models;
using InventoryDomain.Commands;
using InventoryDomain.Model;

namespace InventoryApplication.Service
{
    public class AlmacenesService : IAlmacenesService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMediator _mediator;
        public AlmacenesService(IInventoryRepository inventoryRepository, IMediator mediator)
        {
            _mediator = mediator;
            _inventoryRepository = inventoryRepository;
        }

        public void Create(AlmacenDTO almacenForCreate)
        {
            CreateAlmacenCommand createAlmacenCommand = new CreateAlmacenCommand { AlmacenId = almacenForCreate.AlmacenId, Descripcion = almacenForCreate.Descripcion };
            var result = _mediator.Send(createAlmacenCommand);
        }
        public void Update(AlmacenDTO almacenForUpdate)
        {
            UpdateAlmacenCommand updateAlmacenCommand = new UpdateAlmacenCommand(almacenForUpdate.AlmacenId, almacenForUpdate.Descripcion);
            var result = _mediator.Send(updateAlmacenCommand);
        }
        public void Delete(AlmacenDTO almacenForDelete)
        {
            DeleteAlmacenCommand createAlmacenCommand = new DeleteAlmacenCommand { AlmacenId = almacenForDelete.AlmacenId };
            var result = _mediator.Send(createAlmacenCommand);
        }

        Almacen IAlmacenesService.GetAlmacen(string almacenId)
        {
            return _inventoryRepository.GetAlmacen(almacenId); ;
        }

        IEnumerable<Almacen> IAlmacenesService.GetAlmacenes()
        {
            return _inventoryRepository.GetAlmacenes();
        }

        public void CreateUbicacion(UbicacionDTO ubicacionForCreate)
        {
            CreateUbicacionCommand createUbicacionCommand = new CreateUbicacionCommand { AlmacenId = ubicacionForCreate.AlmacenId, UbicacionId = ubicacionForCreate.UbicacionId, Descripcion = ubicacionForCreate.Descripcion };
            var result = _mediator.Send(createUbicacionCommand);
        }
    }
}


