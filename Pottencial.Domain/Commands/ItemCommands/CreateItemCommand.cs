using Flunt.Notifications;
using Flunt.Validations;
using Pottencial.Domain.Commands.Contracts;

namespace Pottencial.Domain.Commands.ItemCommands;

public class CreateItemCommand : Notifiable, ICommand
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Amount { get; set; }

    public CreateItemCommand()
    {
    }

    public CreateItemCommand(string name, double price, int amount)
    {
        Name = name;
        Price = price;
        Amount = amount;
    }

    public void Validate()
    {
        AddNotifications(new Contract()
            .Requires()
            .HasMinLen(Name, 2, "Name", "O nome precisa ter mais do que 2 caracteres.")
            .IsGreaterThan(Price, 0, "Price", "O preço não pode ser zero.")
            .IsGreaterOrEqualsThan(Amount, 1, "Amount", "A quantidade minima pra cadastrar é 1."));
    }
}