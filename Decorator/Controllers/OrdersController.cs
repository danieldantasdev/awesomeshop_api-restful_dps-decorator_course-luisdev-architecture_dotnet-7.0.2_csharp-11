using Decorator.Application.Models;
using Decorator.Infrastructure;
using Decorator.Infrastructure.Payments;
using Microsoft.AspNetCore.Mvc;

namespace Decorator.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IPaymentServiceFactory _paymentServiceFactory;

    public OrdersController(
        IPaymentServiceFactory paymentServiceFactory)
    {
        _paymentServiceFactory = paymentServiceFactory;
    }

    [HttpPost("simpler")]
    public IActionResult SimplerPost(
        [FromServices] IPaymentServiceFactory paymentServiceFactory,
        OrderInputModel model
    )
    {
        var paymentService = paymentServiceFactory.GetService(model.PaymentInfo.PaymentMethod);

        // Precisamos adicionar novos comportamentos ao "paymentService.Process", mas não
        // queremos alterar sua implementação
        var paymentResult = paymentService.Process(model);

        return NoContent();
    }

    [HttpPost]
    public IActionResult Post(
        [FromServices] InternationalOrderAbstractFactory internationalOrderAbstractFactory,
        [FromServices] NationalOrderAbstractFactory nationalOrderAbstractFactory,
        OrderInputModel model
    )
    {
        IOrderAbstractFactory orderAbstractFactory;

        if (model.IsInternational != null && model.IsInternational.Value)
            orderAbstractFactory = internationalOrderAbstractFactory;
        else
            orderAbstractFactory = nationalOrderAbstractFactory;

        var paymentResult = orderAbstractFactory
            .GetPaymentService(model.PaymentInfo.PaymentMethod)
            .Process(model);

        orderAbstractFactory
            .GetDeliveryService()
            .Deliver(model);

        return NoContent();
    }
}