using Entregas.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas.Domain.Interface
{
    public interface IEntregasRepository
    {
        public int SaveChanges();
        void CrearPedido(Pedido pedido);
        Usuario ObtenerUsuario(int usuarioId);
    }
}
