using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductApp.Application.Dtos.UserDtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ProductApp.Infrastructure.Identity;

namespace ProductApp.Presentations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(UserManager<ApplicationUser> userManager,IConfiguration config, SignInManager<ApplicationUser> signInManager,IMapper _mapper) : ControllerBase
    {
        #region SignIn
        [HttpPost("SignIn")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = _mapper.Map<ApplicationUser>(dto);

            var result = await userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }
        #endregion

        #region LogIn

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await userManager.FindByNameAsync(dto.Email);

            if (user == null)
                return BadRequest("Invalid Email or password");

            var result = await signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (!result.Succeeded)
                return Unauthorized("Invalid Email or password");

            var token = GenerateJwtToken(user);
            return Ok(new { token });
        } 
        #endregion

        #region GenerateJWT
        private string GenerateJwtToken(IdentityUser<int> user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: config["JWT:Issuer"],
                audience: config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        } 
        #endregion
    }
}
