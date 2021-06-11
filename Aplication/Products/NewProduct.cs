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
    public class NewProduct
    {
        public class InsertProduct : IRequest 
        {
            public string ProductName { get; set; }
            public string ProductDescription { get; set; }
            public string ProductState { get; set; }
        }

        public class Handler : IRequestHandler<InsertProduct>
        {

            private readonly PrecixWeightDbContext _DbContext;

            public Handler(PrecixWeightDbContext DbContext) 
            {
                _DbContext = DbContext;
            }

            public async Task<Unit> Handle(InsertProduct request, CancellationToken cancellationToken)
            {
                var product = new Product
                {
                    ProductName = request.ProductName,
                    ProductDescription = request.ProductDescription,
                    ProductState = request.ProductState
                };

                _DbContext.Product.Add(product);
                var response = await _DbContext.SaveChangesAsync();

                if (response > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo crear el nuevo producto");

            }
        }
    }
}
