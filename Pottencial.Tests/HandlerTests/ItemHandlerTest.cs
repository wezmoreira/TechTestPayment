using Pottencial.Domain.Commands;
using Pottencial.Domain.Commands.ItemCommands;
using Pottencial.Domain.Entities;
using Pottencial.Domain.Handlers;
using Pottencial.Tests.Repositories;

namespace Pottencial.Tests.HandlerTests;

[TestClass]
public class ItemHandlerTest
{
    private readonly CreateItemCommand _validCreateItemCommand = new CreateItemCommand("Mouse", 150.0, 10);
    private readonly CreateItemCommand _invalidNameItemCommand = new CreateItemCommand("M", 150.0, 10);
    private readonly CreateItemCommand _invalidPriceItemCommand = new CreateItemCommand("Mouse", 0, 10);
    private readonly CreateItemCommand _invalidAmountItemCommand = new CreateItemCommand("Mouse", 150.0, 0);
    private readonly UpdateItemCommand _invalidUpdateItemCommand = new UpdateItemCommand(new Guid(),"Mouse", 150.0, 0);
    private readonly ItemHandler _handler = new ItemHandler(new FakeItemRepository());
    
    public ItemHandlerTest()
    {
    }
    
    [TestMethod]
    public void DadoUmItemValidoDeveTerSucessoAoCriar()
    {
        var result = _handler.Handle(_validCreateItemCommand);
        Assert.AreEqual(result.Result.Success, true);
    }
    
    [TestMethod]
    public void DadoUmItemComNomeInvalidoDeveFalharAoTentarCriar()
    {
        var result = _handler.Handle(_invalidNameItemCommand);
        Assert.AreEqual(result.Result.Success, false);
    }
    
    [TestMethod]
    public void DadoUmItemComPriceInvalidoDeveFalharAoTentarCriar()
    {
        var result = _handler.Handle(_invalidPriceItemCommand);
        Assert.AreEqual(result.Result.Success, false);
    }
    
    [TestMethod]
    public void DadoUmItemComAmountInvalidoDeveFalharAoTentarCriar()
    {
        var result = _handler.Handle(_invalidAmountItemCommand);
        Assert.AreEqual(result.Result.Success, false);
    }
    
    [TestMethod]
    public void DadoUmItemComGuidInvalidoDeveFalharAoTentarAtualizar()
    {
        var result = _handler.Handle(_invalidUpdateItemCommand);
        Assert.AreEqual(result.Result.Success, false);
    }
    
         
    [TestMethod]
    public void DadoUmUpdateValidoDeveTerSucessoAoAtualizar()
    {
        var updateItem = new UpdateItemCommand(new Guid(), "Gabinete atualizado", 70, 20);
        var result = _handler.Handle(updateItem);
        Assert.AreEqual(result.Result.Success, true);
    }
    
    [TestMethod]
    public void DadoUmUpdateInvalidoDeveFalharAoAtualizar()
    {
        var updateItem = new UpdateItemCommand(new Guid(), "Gabinete atualizado", 0, 20);
        var result = _handler.Handle(updateItem);
        Assert.AreEqual(result.Result.Success, false);
    }
}