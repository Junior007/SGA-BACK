﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Commands
{
    public class CreateUbicacionCommand : IRequest<bool>
    {
        public string AlmacenId { get; set; }
        public string UbicacionId { get; set; }
        public string Descripcion { get;  set; }

    }
}
