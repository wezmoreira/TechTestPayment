using Flunt.Notifications;
using Pottencial.Domain.Commands.Contracts;

namespace Pottencial.Domain.Commands.ItemCommands;

public class DeleteItemCommand : Notifiable, ICommand
{
    public Guid Id { get; set; }

    public DeleteItemCommand()
    {
    }

    public DeleteItemCommand(Guid id)
    {
        Id = id;
    }

    public void Validate()
    {
    }
}