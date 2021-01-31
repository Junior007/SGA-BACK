using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entregas.Application.Interfaces;
using Entregas.Data.Interface;

namespace Entregas.Application.Service
{
    public class EntregasServices : IEntregasService
    {
        private readonly IEntregasRepository _entregasRepository;
        public EntregasServices(IEntregasRepository entregasRepository)
        {

            _entregasRepository = entregasRepository;
        }
    }
}
