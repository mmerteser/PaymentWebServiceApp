namespace Onix.Application.Utilities.Result
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false)
        {
        }

        public ErrorResult(int status) : base(false, status)
        {
        }

        public ErrorResult(string message) : base(false, message, 500)
        {
        }

        public ErrorResult(string message, int status) : base(false, message, status)
        {
        }
    }
}
