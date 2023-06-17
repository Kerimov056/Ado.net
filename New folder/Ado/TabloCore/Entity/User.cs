namespace TabloCore.Entity;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public User(int _Id, string _Name, string _Surname, string _PhoneNumber, string _Email)
    {
        Id = _Id;
        Name = _Name;
        Surname = _Surname;
        PhoneNumber = _PhoneNumber;
        Email = _Email;
    }
}
