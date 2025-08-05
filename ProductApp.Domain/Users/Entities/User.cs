namespace ProductApp.Domain.Users.Entities;

public class User
{
    public User()
    {
    }
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string NationalCode { get; set; }
    public string Email { get; set; }
}
