using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingComments;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommand>
    {
        private readonly IRepository<Ordering> _repos;

        public RemoveOrderingCommandHandler(IRepository<Ordering> repos)
        {
            _repos = repos;
        }

        public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
        {
            Ordering ordering =await _repos.GetByIdAsync(request.Id);
            await _repos.DeleteAsync(ordering);
        }
    }
}
