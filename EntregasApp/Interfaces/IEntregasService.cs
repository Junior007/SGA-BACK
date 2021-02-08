using Entregas.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas.Application.Interfaces
{
    public interface IEntregasService
    {
        void CrearPedido(PedidoForCreate pedidoForCreate);
    }
}
        /*public void NuevoPedido();

        public void AgregarItem();
        public void NuevaEntrega();
        public void AgregarPedido();

    }
}
        */