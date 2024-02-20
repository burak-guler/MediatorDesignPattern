using DesignPattern.Mediator.Core.Context;
using DesignPattern.Mediator.MediatorPattern.Results;
using DesignPattern.Mediator.MediatorPattern.Queries;
using MediatR;

namespace DesignPattern.Mediator.MediatorPattern.Handlers
{
    //IRequestHandler<GetProductByIDQueryHandler, GetProductByIDQueryResult>
    //istek ve yanıt parametereleri
    public class GetProductByIDQueryHandler : IRequestHandler<GetProductByIDQuery, GetProductByIDQueryResult>
    {
        private readonly Context _context;

        public GetProductByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetProductByIDQueryResult> Handle(GetProductByIDQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Products.FindAsync(request.Id);
            return new GetProductByIDQueryResult
            {
                ProductID = values.ProductID,
                ProductName = values.ProductName,
                ProductStock = values.ProductStock,
            };
        }
    }
}
