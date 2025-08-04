using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Commands;
using ProductApp.Application.Queries;

namespace ProductApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IMediator _medi) : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var product = await _medi.Send(command);
            return Ok(product);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var product = await _medi.Send(new GetAllProductsQuery());
            return Ok(product);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _medi.Send(new GetProductById(id));
            if(product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, EditProductCommnad commnad)
        {
            if (id != commnad.ProductId)
                return BadRequest("Product ID Mismatch!");

            var product = await _medi.Send(commnad);
            if (!product)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var currentUserId = Convert.ToInt32(HttpContext.User.Identities);
            var result = await _medi.Send(new DeleteProductCommand(id, currentUserId));

            if (!result)
                return BadRequest("You dont have permission to access!");

            return NoContent();
        }
    }
}
