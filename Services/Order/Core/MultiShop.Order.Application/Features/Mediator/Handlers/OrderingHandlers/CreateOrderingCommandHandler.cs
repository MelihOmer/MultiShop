using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingComments;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repos;

        public CreateOrderingCommandHandler(IRepository<Ordering> repos)
        {
            _repos = repos;
        }

        public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {
            Ordering ordering = new()
            {
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
                UserId = request.UserId
            };
            await _repos.CreateAsync(ordering);
        }
    }
}
