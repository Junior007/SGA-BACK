using InventoryDomain.Commands;
using InventoryDomain.Interfaces;
using InventoryDomain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryDomain.CommandHandlers
{
    public class SetStockHandler : IRequestHandler<SetStockCommand, bool>
    {
        private readonly IInventoryRepository _inventoryRepository;
        public SetStockHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
//
        public Task<bool> Handle(SetStockCommand request, CancellationToken cancellationToken)
        {
            Stock stock = new Stock { ItemId = request.ItemId, UbicacionId = request.UbicacionId, AlmacenId = request.AlmacenId, Cantidad=request.Cantidad };
            Stock stockActual = _inventoryRepository.GetStock(stock);

            if (stockActual == null && stock.Cantidad>0)
                _inventoryRepository.CreateStock(stock);
            else if (stock.Cantidad <= 0)
            {
                _inventoryRepository.DeleteStock(stockActual);
            }
            else
            {
                stockActual.Cantidad = stock.Cantidad;
                _inventoryRepository.UpdateStock(stockActual);
            }
            _inventoryRepository.SaveChanges();
            return Task.FromResult(true);
        }
    }
}
