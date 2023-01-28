using Flunt.Notifications;
using Flunt.Validations;
using Pottencial.Domain.Commands.Contracts;
using Pottencial.Domain.Entities.ValueObjects;

namespace Pottencial.Domain.Commands.OrderCommands;

public class CreateOrderCommand : Notifiable, ICommand
{
    public Guid SellerId { get; set; }
    public List<ItemVO> Items { get; set; } //= new List<ItemVO>();

    public CreateOrderCommand()
    {
    }
    
    public CreateOrderCommand(Guid sellerId, List<ItemVO> items)
    {
        SellerId = sellerId;
        Items = items;
    }

    public void Validate()
    {
        AddNotifications(new Contract()
            .Requires()
            .IsNotNull(SellerId, "SellerId", "Deve Conter um vendedor!")
            .IsNotNull(Items, "Items", "Deve conter pelo menos um item!"));
    }
}