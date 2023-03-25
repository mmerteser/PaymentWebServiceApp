using MediatR;
using Onix.Application.Utilities.Result;

namespace Onix.Application.Features.Queries.Customer
{
    public class GetCustomersQueryRequest : IRequest<Result>
    {
        public string SearchKey { get; set; }
    }
}
