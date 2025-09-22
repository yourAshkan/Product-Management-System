using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Commands.Products;
using ProductApp.Application.Queries.Products;

namespace ProductApp.Presentations.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IMediator _mediator) : ControllerBase
    {
        #region CreateProduct
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
                return Unauthorized();

            command.SetUserId(int.Parse(userIdClaim));

            var product = await _mediator.Send(command);
            return Ok(product);
        }
        #endregion

        #region UpdateProduct
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id, EditProductCommnad commnad)
        {
            commnad.ProductId = id;

            var product = await _mediator.Send(commnad);
            if (!product)
                return NotFound();
            
            return Ok("Product Updated!");
        }
        #endregion

        #region DeleteProduct
        [HttpDelete("DeleteProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var userIdCliam = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdCliam))
                throw new Exception("User ID Not Found!");

            var currentUserId = int.Parse(userIdCliam);

            var result = await _mediator.Send(new DeleteProductCommand(id, currentUserId));

            if (!result)
                return BadRequest("You dont have permission to access!");

            return Ok("Product Deleted");
        }
        #endregion

        #region GetAll
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var product = await _mediator.Send(new GetAllProductsQuery());
            return Ok(product);
        }
        #endregion

        #region GetById
        [HttpGet("ById")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _mediator.Send(new GetProductById(id));
            if (product == null)
                return NotFound();

            return Ok(product);
        }
        #endregion
    }
}
