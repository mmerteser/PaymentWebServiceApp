using Onix.Application.Abstractions;
using Onix.Application.Abstractions.Services.IntegratedApplicationServices;
using Onix.Application.Enums;
using Onix.Integration.NebimV3;

namespace Onix.Integration.Factory
{
    public class IntegratedApplicationFactory : IIntegratedApplicationFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public IntegratedApplicationFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IIntegratedApplicationService GetApplicationService(IntegratedApplication application)
        {

            switch (application)
            {
                case IntegratedApplication.NebimV3:
                    return (IIntegratedApplicationService)_serviceProvider.GetService(typeof(NebimV3Service));
                default:
                    return (IIntegratedApplicationService)_serviceProvider.GetService(typeof(NebimV3Service));
                    break;
            }
        }


    }
}
