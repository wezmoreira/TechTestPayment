using Pottencial.Domain.Commands;
using Pottencial.Domain.Commands.ItemCommands;
using Pottencial.Domain.Commands.OrderCommands;
using Pottencial.Domain.Entities;
using Pottencial.Domain.Entities.ValueObjects;
using Pottencial.Domain.Enums;
using Pottencial.Domain.Handlers;
using Pottencial.Tests.Repositories;

namespace Pottencial.Tests.HandlerTests;

[TestClass]
public class OrderHandlerTest
{
    private readonly OrderHandler _handler =
        new OrderHandler(new FakeOrderRepository(), new FakeItemRepository(), new FakeSellerRepository());
    
    private readonly CreateOrderCommand _validOrderCommand = new CreateOrderCommand(new Guid(), new List<ItemVO>());
    private readonly CreateOrderCommand _invalidOrderCommand = new CreateOrderCommand(new Guid(), null);

    public OrderHandlerTest()
    {
    }
    
    [TestMethod]
    public void DadoUmPedidoValidoDeveTerSucessoAoCriar()
    {
        var result = _handler.Handle(_validOrderCommand);
        Assert.AreEqual(result.Result.Success, true);
    }
    
    [TestMethod]
    public void DadoUmPedidoInvalidoDeveFalharAoTentarCriar()
    {
        var result = _handler.Handle(_invalidOrderCommand);
        Assert.AreEqual(result.Result.Success, false);
    }
    
    [TestMethod]
    public void DadoUmPatchValidoDeveTerSucessoAoAtualizar()
    {
        var seller = new Seller("Wesley", "11122233344", "44999999999", "wesley@gmail.com");
        var listItem = new List<Item>();
        var order = new Order(seller, 100, listItem);
        
        var patchOrder = new PatchStatusOrderCommand(order.Id, EStatusOrder.PAGAMENTO_APROVADO);
        
        var result = _handler.Handle(patchOrder);
        Assert.AreEqual(result.Result.Success, true);

    }
    
    [TestMethod]
    public void DadoUmPatchInvalidoDeveFalharAoAtualizar()
    {
        var seller = new Seller("Wesley", "11122233344", "44999999999", "wesley@gmail.com");
        var listItem = new List<Item>();
        var order = new Order(seller, 100, listItem);
        
        var patchOrder = new PatchStatusOrderCommand(order.Id, EStatusOrder.ENVIADO_PARA_TRANSPORTADORA);
        
        var result = _handler.Handle(patchOrder);
        Assert.AreEqual(result.Result.Success, false);
    }
    
}