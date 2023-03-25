namespace Onix.Application.Common.Result
{
    public interface IResult
    {
        string Message { get; }
        bool Success { get; }
        int Status { get; }
    }
}
