using Decorator.Application.Models;
using Decorator.Infrastructure.Integrations;

namespace Decorator.Infrastructure.Payments.Decorators;

public class PaymentServiceDecorator : IPaymentService
{
    private IPaymentService _paymentService;
    private readonly ICoreCrmIntegrationService _crmService;

    public PaymentServiceDecorator(IPaymentService paymentService, ICoreCrmIntegrationService crmService)
    {
        _paymentService = paymentService;
        _crmService = crmService;
    }

    public object Process(OrderInputModel model)
    {
        var result = _paymentService.Process(model);

        _crmService.Sync(model);

        return result;
    }
}