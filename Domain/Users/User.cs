namespace NadinSoftTask.Domain.Users;

public class User(string firstName,string LastName,string nationalCode,string phoneNumber,string emailAddress)
{
    public int Id { get; set; }
    public string FirstName { get; private set; } = firstName;
    public string LastName { get; private set; } = LastName;
    public string NationalCode { get; private set; } = nationalCode;
    public string PhoneNumber { get; private set; } = phoneNumber;
    public string? EmailAddress { get; private set; } = emailAddress;
}
