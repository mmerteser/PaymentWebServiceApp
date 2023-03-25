namespace Onix.Common.IntegratedApplications.Models.NebimV3.ResponseModels
{
    public class NebimV3BaseResponse
    {
        public string ErrorSource { get; set; }
        public string ExceptionMessage { get; set; }
        public int ModelType { get; set; }
        public string StackTrace { get; set; }
        public int StatusCode { get; set; }
    }
}
