using Decorator.Application.Models;

namespace Decorator.Infrastructure.Deliveries;

public interface IDeliveryService
{
    void Deliver(OrderInputModel model);
}