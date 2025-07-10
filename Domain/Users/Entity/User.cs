namespace NadinSoftTask.Domain.Users.Entity;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string PhoneNumber { get; private set; }
    public string? EmailAddress { get; private set; }
}
