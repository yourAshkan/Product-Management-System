using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NadinSoftTask.Application.Commands;
using NadinSoftTask.Application.Queries;

namespace NadinSoftTask.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IMediator _medi) : ControllerBase
    {
        [HttpPost]
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
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _medi.Send(new GetProductById(id));
            if(product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
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
        public async Task<IActionResult> Delete(int id , [FromQuery] int currentUserId)
        {
            var result = await _medi.Send(new DeleteProductCommand
            {
                CurrentUserId = currentUserId,
                ProductId = id
            });

            if (!result)
                return BadRequest("You dont have permission to access!");

            return NoContent();
        }
    }
}
