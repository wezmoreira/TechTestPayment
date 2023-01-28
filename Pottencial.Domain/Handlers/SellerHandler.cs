using Flunt.Notifications;
using Pottencial.Domain.Commands;
using Pottencial.Domain.Commands.Contracts;
using Pottencial.Domain.Commands.SellerCommands;
using Pottencial.Domain.Entities;
using Pottencial.Domain.Handlers.Contracts;
using Pottencial.Domain.Repositories;

namespace Pottencial.Domain.Handlers;

public class SellerHandler : 
    Notifiable,
    IHandler<CreateSellerCommand>,
    IHandler<UpdateSellerCommand>,
    IHandler<DeleteSellerCommand>
{
    private readonly ISellerRepository _repository;

    public SellerHandler(ISellerRepository repository)
    {
        _repository = repository;
    }
    
    
    public async Task<GenericCommandResult> Handle(CreateSellerCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Algo deu errado!", command.Notifications);

        var seller = new Seller(command.Name, command.Cpf, command.Phone, command.Email);
        
        await _repository.Create(seller);

        return new GenericCommandResult(true, "Vendedor criado com sucesso!", seller);
    }

    public async Task<GenericCommandResult> Handle(UpdateSellerCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Algo deu errado!", command.Notifications);

        var seller = await _repository.GetById(command.Id);
        if (seller == null)
            return new GenericCommandResult(false, "O vendedor não existe!", null);

        seller.Update(command.Name, command.Cpf, command.Phone, command.Email);
        
        await _repository.Update(seller);

        return new GenericCommandResult(true, "Vendedor atualizado com sucesso!", seller);
    }
    
    public async Task<GenericCommandResult> Handle(Guid command)
    {
        try
        {
            var seller = await _repository.GetById(command);
            if (seller == null)
                return new GenericCommandResult(false, "O vendedor não existe!", null);

            return new GenericCommandResult(true, "Vendedor atualizado com sucesso!", seller);
        }
        catch
        {
            return new GenericCommandResult(false, "O vendedor não existe! XPTO2", null);
        }
    }

    public async Task<GenericCommandResult> Handle(DeleteSellerCommand command)
    {
        var seller = await _repository.GetById(command.Id);
        if (seller == null)
            return new GenericCommandResult(false, "O vendedor não existe!", null);
        
        await _repository.Delete(seller);

        return new GenericCommandResult(true, "Vendedor deletado com sucesso!", null);
    }
}