using Decorator.Application.Models;

namespace Decorator.Infrastructure.Integrations;

public interface ICoreCrmIntegrationService
{
    void Sync(OrderInputModel model);
}