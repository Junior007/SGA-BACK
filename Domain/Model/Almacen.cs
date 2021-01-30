using System;
using System.Collections.Generic;


namespace Inventory.Domain.Model
{
    public partial class Almacen
    {
        public Almacen()
        {
            Ubicaciones = new HashSet<Ubicacion>();
        }

        public string AlmacenId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Ubicacion> Ubicaciones { get; set; }
    }
}
