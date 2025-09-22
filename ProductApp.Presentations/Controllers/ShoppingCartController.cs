using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Cart.Entities;
using ProductApp.Infrastructure.DataBaseContext;

namespace ProductApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin,User")]
    public class ShoppingCartController(AppDbContext _context) : ControllerBase
    {
        #region AddToCart
        [HttpPost("Add")]
        public async Task<IActionResult> AddToCart(int productid, [FromQuery] int quentity)
        {
            var userClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userClaim))
                return Unauthorized();

            var userId = int.Parse(userClaim);

            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productid);
            if (product == null || !product.IsAvailable || product.Count < quentity)
                return BadRequest("Product not available or insufficient stock.");

            var cart = await _context.ShoppingCarts
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (cart == null)
            {
                cart = new ShoppingCart { UserId = userId };
                await _context.ShoppingCarts.AddAsync(cart);
            }

            var cartItem = cart.Items.FirstOrDefault(x => x.ProductId == productid);
            if (cartItem != null)
                cartItem.Quentity += quentity;
            else
            {
                cart.Items.Add(new CartItem
                {
                    ProductId = productid,
                    Quentity = quentity
                });
            }

            product.Count -= quentity;

            await _context.SaveChangesAsync();
            return Ok(cart);
        }
        #endregion

        #region RemoveFromCart
        [HttpPost("Remove")]
        public async Task<IActionResult> RemoveFromCart(int productid, [FromQuery] int quentity)
        {
            var userClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userClaim))
                return Unauthorized();

            var userId = int.Parse(userClaim);

            var cart = await _context.ShoppingCarts
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (cart == null)
                return NotFound("Cart not Found!");

            var cartItem = cart.Items.FirstOrDefault(x => x.ProductId == productid);
            if (cartItem == null)
                return NotFound("Product Not In Cart!");

            var product = cartItem.Product;

            if (quentity >= cartItem.Quentity)
            {
                cart.Items.Remove(cartItem);
                product.Count += cartItem.Quentity;
            }
            else
            {
                cartItem.Quentity -= quentity;
                product.Count -= quentity;
            }

            await _context.SaveChangesAsync();
            return Ok(cart);
        }
        #endregion

        #region GetCart
        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            var userClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userClaim))
                return Unauthorized();

            var userId = int.Parse(userClaim);

            var cart = await _context.ShoppingCarts
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (cart == null)
                return NotFound("Cart Not Found!");

            var result = new
            {
                cart.Id,
                cart.Items,
                TotalPrice = cart.TotalPrice
            };

            return Ok(result);
        } 
        #endregion
    }
}
