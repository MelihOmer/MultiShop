using MediatR;

namespace MultiShop.Order.Application.Features.Mediator.Commands.OrderingComments
{
    public class RemoveOrderingCommand : IRequest
    {
        public int Id { get; set; }
        public RemoveOrderingCommand(int id)
        {
            Id = id;
        }
    }
}
