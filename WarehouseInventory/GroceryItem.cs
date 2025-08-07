using System;

public class GroceryItem : IInventoryItem
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Quantity { get; set; }
    public DateTime ExpiryDate { get; private set; }

    public GroceryItem(int id, string name, int quantity, DateTime expiryDate)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        ExpiryDate = expiryDate;
    }
}
