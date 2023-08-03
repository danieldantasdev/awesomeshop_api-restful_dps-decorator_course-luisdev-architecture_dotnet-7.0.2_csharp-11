using Decorator.Application.Models;

namespace Decorator.Infrastructure.Payments;

public class CreditCardService : IPaymentService
{
    public object Process(OrderInputModel model)
    {
        return "Transação aprovada";
    }
}