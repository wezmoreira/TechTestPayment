using Pottencial.Domain.Commands.ItemCommands;

namespace Pottencial.Tests.CommandTests;

[TestClass]
public class ItemCommandTest
{
    private readonly CreateItemCommand _validItem = new CreateItemCommand("Gabinete", 100.0, 10);
    private readonly CreateItemCommand _invalidPriceItem = new CreateItemCommand("Gabinete", 0, 10);
    private readonly CreateItemCommand _invalidNameItem = new CreateItemCommand("G", 100.0, 10);

    [TestMethod]
    public void DadoUmNomeValidoDeveTerSucesso()
    {
        _validItem.Validate();
        Assert.AreEqual(_validItem.Valid, true);
    }
    
    [TestMethod]
    public void DadoUmNomeInvalidoDeveFalhar()
    {
        _invalidNameItem.Validate();
        Assert.AreEqual(_invalidNameItem.Valid, false);
    }
    
     [TestMethod]
     public void DadoUmPrecoInvalidoDeveFalhar()
     {
         _invalidPriceItem.Validate();
         Assert.AreEqual(_invalidPriceItem.Valid, false);
     }
}