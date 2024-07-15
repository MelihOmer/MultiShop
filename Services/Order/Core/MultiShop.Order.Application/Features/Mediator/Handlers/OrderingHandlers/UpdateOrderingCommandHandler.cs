using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingComments;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repos;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repos)
        {
            _repos = repos;
        }

        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var ordering = await _repos.GetByIdAsync(request.OrderingId);
            ordering.OrderDate = request.OrderDate;
            ordering.TotalPrice = request.TotalPrice;
            ordering.UserId = request.UserId;
            await _repos.UpdateAsync(ordering);
        }
    }
}
