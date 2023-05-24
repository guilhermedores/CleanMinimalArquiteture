public class Customer : Entity
{
    public Customer(string? name, string? email, DateTime birthDate)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        BirthDate = birthDate;
    }

    public string? Name { get; set; }
    public string? Email { get; set; }
    public DateTime BirthDate { get; set; }
        
}
