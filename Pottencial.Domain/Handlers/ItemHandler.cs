using Flunt.Notifications;
using Pottencial.Domain.Commands;
using Pottencial.Domain.Commands.Contracts;
using Pottencial.Domain.Commands.ItemCommands;
using Pottencial.Domain.Entities;
using Pottencial.Domain.Handlers.Contracts;
using Pottencial.Domain.Repositories;

namespace Pottencial.Domain.Handlers;

public class ItemHandler : 
    Notifiable,
    IHandler<CreateItemCommand>,
    IHandler<UpdateItemCommand>,
    IHandler<DeleteItemCommand>
{
    private readonly IItemRepository _repository;

    public ItemHandler(IItemRepository repository)
    {
        _repository = repository;
    }
    
    
    public async Task<GenericCommandResult> Handle(CreateItemCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Algo deu errado", command.Notifications);

        var item = new Item(command.Name, command.Price, command.Amount);
        
        await _repository.Create(item);

        return new GenericCommandResult(true, "Item criado com sucesso!", item);
    }


    public async Task<GenericCommandResult> Handle(UpdateItemCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Algo deu errado!", command.Notifications);

        var item = await _repository.GetById(command.Id);
        
        item.UpdateItem(command.Name, command.Price, command.Amount);
        
        await _repository.Update(item);

        return new GenericCommandResult(true, "Item atualizado com sucesso!", item);
    }
    
    
    public async Task<GenericCommandResult> Handle(DeleteItemCommand command)
    {
        var item = await _repository.GetById(command.Id);

        await _repository.Delete(item);

        return new GenericCommandResult(true, "Item deletado com sucesso!", null);
    }
    
    
    public async Task<GenericCommandResult> Handle(Guid command)
    {
        var item = await _repository.GetById(command);
        if (item == null)
            return new GenericCommandResult(false, "O Item não existe!", null);
        
        return new GenericCommandResult(true, "Item recuperado com sucesso!", item);
    }
    
    public async Task<GenericCommandResult> Handle(string command)
    {
        var item = await _repository.GetBySkuid(command);
        if (item == null)
            return new GenericCommandResult(false, "O Item não existe!", null);

        return new GenericCommandResult(true, "Item recuperado com sucesso!", item);
    }
}