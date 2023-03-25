using MediatR;
using Onix.Application.Utilities.Result;

namespace Onix.Application.Features.Queries.Product
{
    public class GetProductFromBarcodeQueryRequest : IRequest<Result>
    {
        public string Barcode { get; set; }
    }
}
