using Decorator.Application.Models;

namespace Decorator.Infrastructure.Payments;

public interface IPaymentService
{
    object Process(OrderInputModel model);
}