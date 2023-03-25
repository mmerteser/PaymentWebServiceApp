namespace Onix.Common.IntegratedApplications.Models.NebimV3.ResponseModels
{
    public class NebimV3ConnectResponse : NebimV3BaseResponse
    {
        public int ModelType { get; set; }
        public string Status { get; set; }
        public int StatusCode { get; set; }
        public string Token { get; set; }
    }
}
