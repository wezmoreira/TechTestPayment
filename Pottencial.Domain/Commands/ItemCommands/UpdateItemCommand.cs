using Flunt.Notifications;
using Flunt.Validations;
using Pottencial.Domain.Commands.Contracts;

namespace Pottencial.Domain.Commands.ItemCommands;

public class UpdateItemCommand : Notifiable, ICommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Amount { get; set; }

    public UpdateItemCommand()
    {
    }

    public UpdateItemCommand(Guid id, string name, double price, int amount)
    {
        Id = id;
        Name = name;
        Price = price;
        Amount = amount;
    }

    public void Validate()
    {
        AddNotifications(new Contract()
            .Requires()
            .HasMinLen(Name, 3, "Name", "O nome precisa ter mais do que 3 caracteres.")
            .IsGreaterThan(Price, 0, "Price", "O preço não pode ser zero.")
            .IsGreaterOrEqualsThan(Amount, 1, "Amount", "A quantidade minima pra cadastrar é 1."));
    }
}