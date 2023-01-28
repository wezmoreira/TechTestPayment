using Flunt.Notifications;
using Pottencial.Domain.Commands;
using Pottencial.Domain.Commands.Contracts;
using Pottencial.Domain.Commands.OrderCommands;
using Pottencial.Domain.Entities;
using Pottencial.Domain.Enums;
using Pottencial.Domain.Handlers.Contracts;
using Pottencial.Domain.Repositories;
using Pottencial.Domain.Util;

namespace Pottencial.Domain.Handlers;

public class OrderHandler : 
    Notifiable,
    IHandler<CreateOrderCommand>,
    IHandler<PatchStatusOrderCommand>,
    IHandler<DeleteOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IItemRepository _itemRepository;
    private readonly ISellerRepository _sellerRepository;

    public OrderHandler(IOrderRepository orderRepository, IItemRepository itemRepository, ISellerRepository sellerRepository)
    {
        _orderRepository = orderRepository;
        _itemRepository = itemRepository;
        _sellerRepository = sellerRepository;
    }
    
    public async Task<GenericCommandResult> Handle(CreateOrderCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Algo deu errado", command.Notifications);

        var seller = await _sellerRepository.GetById(command.SellerId);
        if (seller == null)
            return new GenericCommandResult(false, "O vendedor não existe!", null);

        List<Item> listItem = new List<Item>();
        double total = 0;

        foreach (var items in command.Items)
        {
            var item = await _itemRepository.GetBySkuid(items.Skuid);
            if (item == null)
                return new GenericCommandResult(false, "Item não existe!", item);

            if (item.Amount < items.Amount)
                return new GenericCommandResult(false, "Quantidade insuficiente", item);
            item.UpdateAmount(items.Amount);
            
            total += items.Amount * item.Price;
            listItem.Add(item);
        }

        var order = new Order(seller, total, listItem);
        
        await _orderRepository.Create(order);

        return new GenericCommandResult(true, "Pedido criado com sucesso!", order);
    }

    public async Task<GenericCommandResult> Handle(PatchStatusOrderCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Algo deu erado!", command.Notifications);

        var order = await _orderRepository.GetById(command.Id);
        
        var statusUpdated = OrderStatusUtil.StatusOrder(command.Status, order.Status);
        if (statusUpdated == EStatusOrder.ERRO)
            return new GenericCommandResult(false, "O status do enum não é compativel", null);
        
        order.PatchStatus(statusUpdated);
        
        return new GenericCommandResult(true, "O status do Pedido foi atualizado com sucesso!", order);
    }

    public async Task<GenericCommandResult> Handle(DeleteOrderCommand command)
    {
        var order = await _orderRepository.GetById(command.Id);
        
        await _orderRepository.Delete(order);

        return new GenericCommandResult(true, "O pedido foi deletado com sucesso!", null);
    }
    
    public async Task<GenericCommandResult> Handle(Guid command)
    {
        var seller = await _orderRepository.GetById(command);
        if (seller == null)
            return new GenericCommandResult(false, "O Pedido não existe!", null);

        return new GenericCommandResult(true, "Pedido recuperado com sucesso!", seller);
    }
}