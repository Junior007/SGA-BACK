using System;
using System.Linq;
using System.Collections.Generic;

namespace EntregasDomainCore
{
    public class Entrega
    {
        public Receptor RecibidoPor { get; internal set; }
        public Estados Estado
        {
            get
            {
                var estadosItems = Ordenes.Select(ord => ord.Items.Select(item => item.Estado));
                if (Ordenes.Any(ord => ord.EstadoDeEntrega == Estados.Pendiente))
                    return Estados.Pendiente;
                return Estados.Preparado;
            }
        }

        public ICollection<Pedido> Ordenes { get; internal set; }
        public void AgregarOrden(Pedido orden)
        {
            if (RecibidoPor != null)
                throw new Exception("La entrega ya se realizó");
            if (Ordenes == null)
                Ordenes = new List<Pedido>();
            if (Ordenes.Any(ord => ord.SolicitadoPor == orden.SolicitadoPor))
                throw new Exception("La orden es para otra entrega");
            if (Ordenes.Any(ord => ord.EsIgual(orden))) //Si no esta repetida
                throw new Exception("La orden ya existe en la entrega");
            Ordenes.Add(orden);
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
