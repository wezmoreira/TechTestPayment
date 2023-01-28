using Pottencial.Domain.Commands.SellerCommands;

namespace Pottencial.Tests.CommandTests;

[TestClass]
public class SellerCommandTest
{
    private readonly CreateSellerCommand _invalidSellerCpf = new CreateSellerCommand("Wesley", "123456789101", "44999999999", "wesley@gmail.com");
    private readonly CreateSellerCommand _validSeller = new CreateSellerCommand("Wesley", "12345678910", "44999999999", "wesley@gmail.com");
    private readonly CreateSellerCommand _invalidSellerName = new CreateSellerCommand("An", "12345678910", "44999999999", "ana@gmail.com");
    
    
    [TestMethod]
    public void DadoUmNomeInvalidoDeveFalhar()
    {
        _invalidSellerName.Validate();
        Assert.AreEqual(_invalidSellerName.Valid, false);
    }
    
    [TestMethod]
    public void DadoUmCpfInvalidoDeveFalhar()
    {
        _invalidSellerCpf.Validate();
        Assert.AreEqual(_invalidSellerCpf.Valid, false);
    }
    
    [TestMethod]
    public void DadoUmVendedorValidoDeveTerSucesso()
    {
        _validSeller.Validate();
        Assert.AreEqual(_validSeller.Valid, true);
    }
}