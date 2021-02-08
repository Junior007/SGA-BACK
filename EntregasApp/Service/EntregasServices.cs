using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entregas.Application.Interfaces;
using Entregas.Application.Model;
using Entregas.Domain.Interface;

namespace Entregas.Application.Service
{
    public class EntregasServices : IEntregasService
    {
        private readonly IEntregasRepository _entregasRepository;
        public EntregasServices(IEntregasRepository entregasRepository)
        {

            _entregasRepository = entregasRepository;
        }

        public void CrearPedido(PedidoForCreate pedidoForCreate)
        {
            Domain.Model.Usuario solicitadoPor = _entregasRepository.ObtenerUsuario(pedidoForCreate.UsuarioId);
            Domain.Model.Pedido pedido = new Domain.Model.Pedido { SolicitadoPor = solicitadoPor };
            _entregasRepository.CrearPedido(pedido);
            _entregasRepository.SaveChanges();
        }
    }
}
