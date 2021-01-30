using MediatR;

namespace Inventory.Domain.Commands
{
    public class CreateItemCommand : IRequest<bool>
    {
        public string ItemId { get; set; }
        public string Descripcion { get; set; }
    }
}