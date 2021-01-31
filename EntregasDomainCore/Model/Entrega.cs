using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entregas.Domain.Model
{
    public class Entrega
    {
        public int Id { get; internal set; }
        public Receptor RecibidoPor { get; internal set; }
        public Estados Estado
        {
            get
            {
                var estadosItems = Pedidos.Select(ord => ord.Items.Select(item => item.Estado));
                if (Pedidos.Any(ord => ord.EstadoDeEntrega == Estados.Pendiente))
                    return Estados.Pendiente;
                return Estados.Preparado;
            }
        }

        public ICollection<Pedido> Pedidos { get; internal set; }
        public void AgregarOrden(Pedido orden)
        {
            if (RecibidoPor != null)
                throw new Exception("La entrega ya se realizó");
            if (Pedidos == null)
                Pedidos = new List<Pedido>();
            if (Pedidos.Any(ord => ord.SolicitadoPor == orden.SolicitadoPor))
                throw new Exception("La orden es para otra entrega");
            if (Pedidos.Any(ord => ord.EsIgual(orden))) //Si no esta repetida
                throw new Exception("La orden ya existe en la entrega");
            Pedidos.Add(orden);
        }

        public void Entregar(Receptor receptor)
        {
            if (RecibidoPor != null)
                throw new Exception("La entrega ya se realizó");
            if (Estado == Estados.Preparado)
                this.RecibidoPor = receptor;

        }
    }
}
