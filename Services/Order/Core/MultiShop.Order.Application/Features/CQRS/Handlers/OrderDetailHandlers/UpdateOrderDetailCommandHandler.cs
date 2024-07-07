using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repos;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repos)
        {
            _repos = repos;
        }
        public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            var values = await _repos.GetByIdAsync(updateOrderDetailCommand.OrderDetailId);
            values.OrderingId = updateOrderDetailCommand.OrderingId;
            values.ProductId = updateOrderDetailCommand.ProductId;
            values.ProductName = updateOrderDetailCommand.ProductName;
            values.ProductPrice = updateOrderDetailCommand.ProductPrice;
            values.ProductTotalPrice = updateOrderDetailCommand.ProductTotalPrice;
            values.ProductAmount = updateOrderDetailCommand.ProductAmount;
            await _repos.UpdateAsync(values);
        }
    }
}
