using MediatR;

namespace Inventory.Domain.Commands
{
    public class DeleteItemCommand : IRequest<bool>
    {
        public string ItemId { get; set; }

 
    }
}