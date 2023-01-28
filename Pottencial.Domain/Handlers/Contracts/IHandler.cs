using Pottencial.Domain.Commands;
using Pottencial.Domain.Commands.Contracts;

namespace Pottencial.Domain.Handlers.Contracts;

public interface IHandler<T> where T : ICommand
{
    Task<GenericCommandResult> Handle(T command);

}