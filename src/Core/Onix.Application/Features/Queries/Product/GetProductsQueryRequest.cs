using MediatR;
using Onix.Application.Utilities.Result;

namespace Onix.Application.Features.Queries.Product
{
    public class GetProductsQueryRequest : IRequest<Result>
    {
        public string SearchKey { get; set; }
    }
}
