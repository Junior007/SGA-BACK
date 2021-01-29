using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasDomainCore
{
    public class Pedido
    {
        public Int64 Id { get; internal set; }
        public Autorizador AutorizadoPor { get; internal set; }
        public DateTime? FechaAutorizado { get; internal set; }
        public Receptor SolicitadoPor { get; internal set; }
        public DateTime? FechaCompletado { get; internal set; }
        public Estados EstadoDeEntrega
        {
            get
            {
                if (Items.Any(item => item.Estado == Estados.Pendiente))
                    return Estados.Pendiente;
                return Estados.Preparado;
            }
        }
        public ICollection<Item> Items { get; internal set; }
        public void AgregarItem(Item item)
        {
            if (AutorizadoPor != null)
                throw new Exception("La orden ya está autorizada");
            if (Items.Any(i => i.EsIgual(item)))
                throw new Exception("El item ya existe en la entrega");
            Items.Add(item);
        }
        public void Completar(Autorizador usuario)
        {
            if (SolicitadoPor.Id != usuario.Id)
                throw new Exception("El pedido pertenece a otra persona");
            AutorizadoPor = usuario;
            FechaAutorizado = DateTime.Now;
        }
        public void Autorizar(Autorizador usuario)
        {
            if (FechaCompletado != null)
                throw new Exception("Éste pedido aún se está completando");
            if (FechaAutorizado!=null)
                throw new Exception("Éste pedido ya se autorizó");

            AutorizadoPor = usuario;
            FechaAutorizado = DateTime.Now;

        }
        internal bool EsIgual(Pedido orden)
        {
            return Id == orden.Id;
        }
    }

}

