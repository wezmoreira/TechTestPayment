namespace Pottencial.Domain.Entities;

public class Item : Entity
{
    public string Name { get; private set; }
    public string Skuid { get; private set; }
    public double Price { get; private set; }
    public int Amount { get; private set; }

    public Item(string name, double price, int amount)
    {
        Name = name;
        Skuid = $"itm{Guid.NewGuid().ToString().Substring(0, 12).Replace("-", "").ToUpper()}";
        Price = price;
        Amount = amount;
    }
    
    public void UpdateItem(string name, double price, int amount)
    {
        Name = name;
        Price = price;
        Amount = amount;
    }

    public void UpdateAmount(int amount)
    {
        Amount -= amount;
    }
}