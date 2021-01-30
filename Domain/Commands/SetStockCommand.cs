using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Commands
{
    public class SetStockCommand : IRequest<bool>
    {
        public string ItemId { get; set; }
        public string UbicacionId { get; set; }
        public string AlmacenId { get; set; }
        public decimal Cantidad { get; set; }
    }
}
