using MediatR;

namespace InventoryDomain.Commands
{
    public class DeleteItemCommand : IRequest<bool>
    {
        public string ItemId { get; set; }

 
    }
}