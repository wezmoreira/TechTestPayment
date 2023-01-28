using Pottencial.Domain.Commands.ItemCommands;
using Pottencial.Domain.Commands.OrderCommands;
using Pottencial.Domain.Entities;
using Pottencial.Domain.Entities.ValueObjects;

namespace Pottencial.Tests.CommandTests;

[TestClass]
public class OrderCommandTest
{
    private readonly ItemVO _itemVO = new ItemVO("itmSJAISFGNIAFA", 10);
    private readonly ItemVO _itemVO2 = new ItemVO("itmSJAISRRRRRA", 20);
    private static List<ItemVO> _listItemVO = new List<ItemVO>();
    private readonly CreateOrderCommand _validOrder = new CreateOrderCommand(new Guid(), _listItemVO);

    public OrderCommandTest()
    {
        _listItemVO.Add(_itemVO);
        _listItemVO.Add(_itemVO2);
    }

    [TestMethod]
    public void DadoUmPedidoValidoDeveTerSucesso()
    {
        _validOrder.Validate();
        Assert.AreEqual(_validOrder.Valid, true);
    }
}