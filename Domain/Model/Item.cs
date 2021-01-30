using System;
using System.Collections.Generic;

#nullable disable

namespace Inventory.Domain.Model
{
    public partial class Item
    {
        public Item()
        {
            Stocks = new HashSet<Stock>();
        }

        public string ItemId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
