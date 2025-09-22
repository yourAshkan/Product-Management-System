using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Infrastructure.DataBaseContext;

namespace ProductApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController(AppDbContext _context) : ControllerBase
    {
        #region IncreaseStock
        [HttpPost("IncreaseStock/productid")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> IncreaseStock(int productid, [FromQuery] int amount)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productid);
            if (product == null)
                return NotFound("Product Not Found!");

            try
            {
                product.IncreaseCount(amount);
                await _context.SaveChangesAsync();
                return Ok(new { message = $"Stock increased by {amount}", product.Count });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region DecreaseStock
        [HttpPost("DecreaseStock/productid")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DecreaseStock(int productid, [FromQuery] int amount)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productid);
            if (product == null)
                return NotFound("Product Not Found!");

            if (!product.HasEnoughStock(amount))
                return BadRequest("Not enough stock to decrease.");

            try
            {
                product.DecreaseCount(amount);
                await _context.SaveChangesAsync();
                return Ok(new { message = $"Stock decreased by {amount}", product.Count });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region GetStock
        [HttpGet("GetStock/productid")]
        [Authorize(Roles ="Admin,User")]
        public async Task<IActionResult> GetStock(int productid)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productid);
            if (product == null)
                return NotFound("Product Not Found!");

            return Ok(new { product.Id, product.Title, product.Count });
        } 
        #endregion
    }
}
