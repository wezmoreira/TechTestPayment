namespace Pottencial.Domain.Entities;

public class Seller : Entity
{
    public string Name { get; private set; }
    public string Cpf { get; private set; }
    public string Phone { get; private set; }
    public string Email { get; private set; }
    public IList<Order>? Orders { get; set; }
    
    public Seller(string name, string cpf, string phone, string email)
    {
        Name = name;
        Cpf = cpf;
        Phone = phone;
        Email = email;
    }

    public void Update(string name, string cpf, string phone, string email)
    {
        Name = name;
        Cpf = cpf;
        Phone = phone;
        Email = email;
    }
}