using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Commands;
using ProductApp.Application.Queries;
using System.Linq.Expressions;
using System.Security.Claims;

namespace ProductApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoryController(IMediator _mediator) : ControllerBase
    {
        #region Create
        [HttpPost("Create")]
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

        #region GetAll
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var category = _mediator.Send(new GetAllCategoryiesQuery());
            return Ok(category);
        } 
    }
	#endregion
}