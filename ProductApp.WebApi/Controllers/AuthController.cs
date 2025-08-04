using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductApp.Domain.Users.Entities;
using ProductApp.Application.Dtos.UserDtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(UserManager<User> userManager,IConfiguration config, SignInManager<IdentityUser<int>> signInManager,IMapper _mapper) : ControllerBase
    {
        [HttpPost("SignIn")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = _mapper.Map<User>(dto);

            var result = await userManager.CreateAsync(user,dto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok("User registered successfully");
        }
        private string GenerateJwtToken(IdentityUser<int> user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: config["JWT:Issuer"],
                audience: config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await userManager.FindByNameAsync(dto.Email);

            if (user == null)
                return BadRequest("Invalid Email or password");

            var result = await signInManager.CheckPasswordSignInAsync(user, dto.Password,false);
            if (!result.Succeeded)
                return Unauthorized("Invalid Email or password");

            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }
    }
}
