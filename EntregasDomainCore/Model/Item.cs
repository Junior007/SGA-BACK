using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas.Domain.Model
{
    public class Item
    {
        public int Id { get; internal set; }
        public int? PedidoId { get; internal set; }
        public string Descripcion { get; internal set; }
        public Estados Estado { get; internal set; }
        public int Cantidad { get; internal set; }
        public void Seleccionar()
        {
            if (Estado != Estados.Pendiente)
                throw new Exception("La entrega esté en preparación");
            this.Estado = Estados.Preparado;
        }
        public void Preparar()
        {
            if (Estado != Estados.Preparado)
                throw new Exception("La entrega esté en preparación");
            this.Estado = Estados.Preparado;
        }

        internal bool EsIgual(Item item)
        {
            return Id == item.Id;
        }
    }
}
