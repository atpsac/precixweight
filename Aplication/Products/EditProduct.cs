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
    public class EditProduct
    {

        public class UpdateProduct : IRequest
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductDescription { get; set; }
            public string ProductState { get; set; }
        }

        public class Handler : IRequestHandler<UpdateProduct>
        {

            private readonly PrecixWeightDbContext _DbContext;

            public Handler (PrecixWeightDbContext DbContext)
            {
                _DbContext = DbContext;
            }

            public async Task<Unit> Handle(UpdateProduct request, CancellationToken cancellationToken)
            {
                var product = await _DbContext.Product.FindAsync(request.ProductId);
                if ( product == null ) 
                {
                    throw new Exception("El producto no existe");
                }
                product.ProductName = request.ProductName ?? product.ProductName;
                product.ProductDescription = request.ProductDescription ?? product.ProductDescription;
                product.ProductState = request.ProductState ?? product.ProductState;
                var result = await _DbContext.SaveChangesAsync();

                if (result > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se guardaron los cambios");

            }
        }
    }
}
