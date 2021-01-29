using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryDomain.Commands
{
    public class UpdateAlmacenCommand : IRequest<bool>
    {
        public UpdateAlmacenCommand(string almacenId, string descripcion)
        {
            AlmacenId = almacenId;
            Descripcion = descripcion;
        }
        public string AlmacenId { get; internal set; }
        public string Descripcion { get;  internal set; }

    }
}
