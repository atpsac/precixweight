using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplication.Products
{
    public class ListProductId
    {
        public class ProductId : IRequest<Product>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<ProductId, Product>
        {
            private readonly PrecixWeightDbContext _DbContext;

            public Handler (PrecixWeightDbContext DbContext)
            {
                _DbContext = DbContext;
            }

            public async Task<Product> Handle(ProductId request, CancellationToken cancellationToken)
            {
                var product = await _DbContext.Product.FindAsync(request.Id);
                return product;
            }
        }
    }
}
