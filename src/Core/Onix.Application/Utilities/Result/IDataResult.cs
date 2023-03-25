using Onix.Application.Common.Result;

namespace Onix.Application.Utilities.Result
{
    public interface IDataResult<T> : IResult
    {
        public T Data { get; }
    }
}
