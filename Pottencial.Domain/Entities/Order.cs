using Pottencial.Domain.Enums;

namespace Pottencial.Domain.Entities;

public class Order : Entity
{
    public DateTime Date { get; private set; }
    public EStatusOrder Status { get; private set; }
    public Guid SellerId { get; private set; }
    public Seller Seller { get; private set; }
    public double Total { get; private set; }
    public ICollection<Item> Items { get; private set; }


    public Order()
    {
    }
    
    public Order(Seller seller, double total, IList<Item> items)
    {
        Date = DateTime.Now;
        Status = EStatusOrder.AGUARDANDO_PAGAMENTO;
        Seller = seller;
        Total = total;
        Items = items;
    }

    public void PatchStatus(EStatusOrder status)
    {
        Status = status;
    }
}