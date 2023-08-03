using Decorator.Core.Enums;
using Decorator.Infrastructure.Deliveries;
using Decorator.Infrastructure.Payments;

namespace Decorator.Infrastructure;

public interface IOrderAbstractFactory
{
    IPaymentService GetPaymentService(PaymentMethod method);
    IDeliveryService GetDeliveryService();
}