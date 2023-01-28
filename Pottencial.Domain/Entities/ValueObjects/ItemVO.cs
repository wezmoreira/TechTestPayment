namespace Pottencial.Domain.Entities.ValueObjects;

public class ItemVO
{
    public string Skuid { get; private set; }
    public int Amount { get; private set; }

    public ItemVO(string skuid, int amount)
    {
        Skuid = skuid;
        Amount = amount;
    }
}