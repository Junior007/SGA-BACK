﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Commands
{
    public class DeleteAlmacenCommand : IRequest<bool>
    {
        public string AlmacenId { get; set; }

    }
}
