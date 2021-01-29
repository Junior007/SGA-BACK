using MediatR;

namespace InventoryDomain.Commands
{
    public class UpdateItemCommand : IRequest<bool>
    {
        public string ItemId { get; internal set; }
        public string Descripcion { get; internal set; }

        public UpdateItemCommand(string itemId, string descripcion)
        {
            this.ItemId = itemId;
            this.Descripcion = descripcion;
        }
    }
}