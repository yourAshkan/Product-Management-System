using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Commands.Categories;
using ProductApp.Application.Commands.Categories;
using ProductApp.Application.Queries.Categories;
using System.Security.Claims;

namespace ProductApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoryController(IMediator _mediator) : ControllerBase
    {
        #region CreateCategory
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("User not found in token");

            command.UserId = int.Parse(userIdClaim.Value);

            var category = await _mediator.Send(command);
            return Ok(category);
        }
        #endregion

        #region DeleteCategory
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var userIdCliam = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdCliam))
                throw new Exception("User Not Found!");

            var currentUserId = int.Parse(userIdCliam);

            var result = await _mediator.Send(new DeleteCategoryCommand(id, currentUserId));

            if (!result)
                return BadRequest("You dont have permission to access!");

            return Ok("Category Deleted");
        }
        #endregion

        #region GetAll
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _mediator.Send(new GetAllCategoryiesQuery());
            return Ok(categories);
        }
        #endregion
    }
}