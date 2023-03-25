namespace Onix.Application.Utilities.Result
{
    public sealed class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data) : base(data, false, 500)
        {
        }
        public ErrorDataResult(T data, string message) : base(data, false, message, 500)
        {
        }
        public ErrorDataResult(T data, int status) : base(data, false, status)
        {
        }
        public ErrorDataResult(T data, string message, int status) : base(data, false, message, status)
        {
        }
    }
}
