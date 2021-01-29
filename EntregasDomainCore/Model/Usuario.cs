using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasDomainCore
{
    public abstract class Usuario
    {
        public string Id { get; internal set; }
        public string Nombre { get; internal set; }
    }
}
