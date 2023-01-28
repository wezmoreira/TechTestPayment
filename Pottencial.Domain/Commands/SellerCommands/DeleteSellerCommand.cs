using Flunt.Notifications;
using Pottencial.Domain.Commands.Contracts;

namespace Pottencial.Domain.Commands.SellerCommands;

public class DeleteSellerCommand : Notifiable, ICommand
{
    public Guid Id { get; set; }
    
    public void Validate()
    {
    }
}