using Onix.Application.Utilities.Result;
using Onix.Common.IntegratedApplications.Models.NebimV3.ResponseModels;

namespace Onix.Application.Abstractions.Services.IntegratedApplicationServices
{
    public interface INebimV3Service : IIntegratedApplicationService
    {
        Task<IDataResult<NebimV3ConnectResponse>> Connect();
    }
}
