using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas.Domain.Model
{
    public class Pedido
    {
        /*public Pedido(Usuario solicitadoPor)
        {
            SolicitadoPor = solicitadoPor;
        }*/
        public int Id { get; internal set; }
        public int? EntregaId { get; internal set; }
        public Usuario AutorizadoPor { get; internal set; }
        public DateTime? FechaAutorizado { get; internal set; }
        //public Usuario SolicitadoPor { get; internal set; }
        public Usuario SolicitadoPor { get;  set; }
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
        public void Completar(Usuario autorizador)
        {
            if (SolicitadoPor.Id != autorizador.Id)
                throw new Exception("El pedido pertenece a otra persona");
            AutorizadoPor = autorizador;
            FechaAutorizado = DateTime.Now;
        }
        public void Autorizar(Usuario autorizador)
        {
            if (FechaCompletado != null)
                throw new Exception("Éste pedido aún se está completando");
            if (FechaAutorizado!=null)
                throw new Exception("Éste pedido ya se autorizó");

            AutorizadoPor = autorizador;
            FechaAutorizado = DateTime.Now;

        }
        internal bool EsIgual(Pedido orden)
        {
            return Id == orden.Id;
        }
    }

}

