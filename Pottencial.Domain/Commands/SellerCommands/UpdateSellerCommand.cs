using Flunt.Notifications;
using Flunt.Validations;
using Pottencial.Domain.Commands.Contracts;

namespace Pottencial.Domain.Commands.SellerCommands;

public class UpdateSellerCommand : Notifiable, ICommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public UpdateSellerCommand(Guid id, string name, string cpf, string phone, string email)
    {
        Id = id;
        Name = name;
        Cpf = cpf;
        Phone = phone;
        Email = email;
    }

    public void Validate()
    {
        AddNotifications(new Contract()
            .Requires()
            .HasMinLen(Name, 3, "Name", "O nome deve ter pelo menos 3 caracteres.")
            .HasMinLen(Cpf, 11, "Cpf", "O Cpf deve ser válido, 11 digitios e nao deve conter acentuação")
            .HasMaxLen(Cpf, 11, "Cpf", "O Cpf deve ser válido, 11 digitios e nao deve conter acentuação")
        );
    }
}