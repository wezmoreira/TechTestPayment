using Pottencial.Domain.Commands;
using Pottencial.Domain.Commands.OrderCommands;
using Pottencial.Domain.Commands.SellerCommands;
using Pottencial.Domain.Entities;
using Pottencial.Domain.Enums;
using Pottencial.Domain.Handlers;
using Pottencial.Tests.Repositories;

namespace Pottencial.Tests.HandlerTests;

[TestClass]
public class SellerHandlerTest
{
    private readonly CreateSellerCommand _validSellerCommand = new CreateSellerCommand("Wesley", "11122233344", "44999999999", "wesley@gmail.com");
    private readonly CreateSellerCommand _invalidNameSellerCommand = new CreateSellerCommand("We", "11122233344", "44999999999", "wesley@gmail.com");
    private readonly CreateSellerCommand _invalidCpfSellerCommand = new CreateSellerCommand("Wesley", "111", "44999999999", "wesley@gmail.com");

    private readonly UpdateSellerCommand _invalidUpdateSellerCommand =
        new UpdateSellerCommand(new Guid(), "Wesley", "111", "44999999999", "wesley@gmail.com");
    private readonly SellerHandler _handler = new SellerHandler(new FakeSellerRepository());

    public SellerHandlerTest()
    {
    }
    
    [TestMethod]
    public void DadoUmSellerValidoDeveCriarComSucesso()
    {
        var result = _handler.Handle(_validSellerCommand);
        Assert.AreEqual(result.Result.Success, true);
    }
    
    [TestMethod]
    public void DadoUmSellerComNomeInvalidoDeveFalhar()
    {
        var result = _handler.Handle(_invalidNameSellerCommand);
        Assert.AreEqual(result.Result.Success, false);
    }
    
    [TestMethod]
    public void DadoUmSellerComCpfInvalidoDeveFalhar()
    {
        var result = _handler.Handle(_invalidCpfSellerCommand);
        Assert.AreEqual(result.Result.Success, false);
    }
    
    [TestMethod]
    public void DadoUmItemComGuidInvalidoDeveFalharAoTentarAtualizar()
    {
        var result = _handler.Handle(_invalidUpdateSellerCommand);
        Assert.AreEqual(result.Result.Success, false);
    }
    
    [TestMethod]
    public void DadoUmUpdateValidoDeveTerSucessoAoAtualizar()
    {
        var seller = new Seller("Wesley", "11122233344", "44999999999", "wesley@gmail.com");
        var updateSeller = new UpdateSellerCommand(seller.Id, "Wesley Moreira", "11122233344", "44999999999", "wesley@gmail.com");
        var result = _handler.Handle(updateSeller);
        Assert.AreEqual(result.Result.Success, true);

    }
    
    [TestMethod]
    public void DadoUmUpdateComCpfInvalidoDeveFalharAoAtualizar()
    {
        var seller = new Seller("Wesley", "11122233344", "44999999999", "wesley@gmail.com");
        var updateSeller = new UpdateSellerCommand(seller.Id, "Wesley Moreira", "11122", "44999999999", "wesley@gmail.com");
        var result = _handler.Handle(updateSeller);
        Assert.AreEqual(result.Result.Success, false);
    }
}