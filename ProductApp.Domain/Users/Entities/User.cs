using Microsoft.AspNetCore.Identity;

namespace ProductApp.Domain.Users.Entities;

public class User : IdentityUser<int>
{
    public User()
    {
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string NationalCode { get; set; }
    public string Email { get; set; }
}
