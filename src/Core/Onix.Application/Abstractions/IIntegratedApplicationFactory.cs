using Onix.Application.Abstractions.Services.IntegratedApplicationServices;
using Onix.Application.Enums;

namespace Onix.Application.Abstractions
{
    public interface IIntegratedApplicationFactory
    {
        IIntegratedApplicationService GetApplicationService(IntegratedApplication application);
    }
}
