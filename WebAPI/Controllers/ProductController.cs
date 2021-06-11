using Aplication.Products;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>>GetProducts()
        {
            return await _mediator.Send(new ListProduct.ListProducts());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProductDetail(int id)
        {
            return await _mediator.Send(new ListProductId.ProductId { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateNewProduct(NewProduct.InsertProduct data)
        {
            return await _mediator.Send(data);
        } 
      
    }
}
