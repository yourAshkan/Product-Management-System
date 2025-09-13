namespace ProductApp.Domain.Users.Entities;

public class User
{
    public User()
    {
    }
    public int Id { get; set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string UserName { get; private set; }
    public string Password { get; private set; }
    public string PhoneNumber { get; private set; }
    public string NationalCode { get; private set; }
    public string Email { get; private set; }
}
