using System;
using System.Collections.Generic;

#nullable disable

namespace Inventory.Domain.Model
{
    public partial class Stock
    {
        public string ItemId { get; set; }
        public string UbicacionId { get; set; }
        public string AlmacenId { get; set; }
        public decimal Cantidad { get; set; }

        public virtual Item Item { get; set; }
        public virtual Ubicacion Ubicacione { get; set; }
    }
}
