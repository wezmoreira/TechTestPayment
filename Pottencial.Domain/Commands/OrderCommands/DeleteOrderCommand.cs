using Flunt.Notifications;
using Pottencial.Domain.Commands.Contracts;

namespace Pottencial.Domain.Commands.OrderCommands;

public class DeleteOrderCommand : Notifiable, ICommand
{
    public Guid Id { get; set; }

    public DeleteOrderCommand()
    {
    }

    public DeleteOrderCommand(Guid id)
    {
        Id = id;
    }

    public void Validate()
    {
    }
}