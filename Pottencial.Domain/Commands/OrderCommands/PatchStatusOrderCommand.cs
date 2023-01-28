using Flunt.Notifications;
using Flunt.Validations;
using Pottencial.Domain.Commands.Contracts;
using Pottencial.Domain.Enums;

namespace Pottencial.Domain.Commands.OrderCommands;

public class PatchStatusOrderCommand : Notifiable, ICommand
{
    public Guid Id { get; set; }
    public EStatusOrder Status { get; set; }

    public PatchStatusOrderCommand()
    {
    }

    public PatchStatusOrderCommand(Guid id, EStatusOrder status)
    {
        Id = id;
        Status = status;
    }

    public void Validate()
    {
        AddNotifications(new Contract()
            .Requires()
            .IsNotNull(Status, "Status", "Deve conter um Status valido!"));
    }
}