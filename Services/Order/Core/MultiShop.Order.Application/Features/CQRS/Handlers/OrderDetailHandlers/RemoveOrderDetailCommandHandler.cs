using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repos;

        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repos)
        {
            _repos = repos;
        }
        public async Task Handle(RemoveOrderDetailCommand removeOrderDetailCommand)
        {
            var value =await _repos.GetByIdAsync(removeOrderDetailCommand.Id);
            await _repos.DeleteAsync(value);
        }
    }
}
