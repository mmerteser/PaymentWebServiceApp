namespace Onix.Application.Utilities.Result
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true,200)
        {
        }

        public SuccessResult(string message) : base(true, message, 200)
        {
        }


        public SuccessResult(int status) : base(true, status)
        {
        }


        public SuccessResult(string message, int status) : base(true, message, status)
        {
        }
    }
}
