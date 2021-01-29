using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryDomain.Commands
{
    public class CreateAlmacenCommand : IRequest<bool>
    {
        public string AlmacenId { get; set; }
        public string Descripcion { get;  set; }

    }
}
