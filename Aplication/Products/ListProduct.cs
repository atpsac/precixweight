using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Products
{
    public class ListProduct
    {
        public class ListProducts : IRequest<List<Product>> { }

        public class Handler : IRequestHandler<ListProducts, List<Product>>
        {
            private readonly PrecixWeightDbContext _DbContext;

            public Handler(PrecixWeightDbContext Dbcontext)
            {
                _DbContext = Dbcontext;
            }

            public async Task<List<Product>> Handle(ListProducts request, CancellationToken cancellationToken)
            {
                var products = await _DbContext.Product.ToListAsync();
                return products;
            }
        }

    }
}
