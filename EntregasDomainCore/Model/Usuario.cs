using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas.Domain.Model
{
    public abstract class Usuario
    {
        public int Id { get; internal set; }
        public string Nombre { get; internal set; }
    }
}
