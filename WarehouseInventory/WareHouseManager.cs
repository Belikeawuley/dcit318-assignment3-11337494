using System;
using System.Collections.Generic;

public class WareHouseManager
{
    public InventoryRepository<ElectronicItem> Electronics { get; } = new();
    public InventoryRepository<GroceryItem> Groceries { get; } = new();

    public void SeedData()
    {
        Electronics.AddItem(new ElectronicItem(1, "Laptop", 10, "BrandA", 24));
        Electronics.AddItem(new ElectronicItem(2, "Smartphone", 20, "BrandB", 12));
        Groceries.AddItem(new GroceryItem(1, "Milk", 30, DateTime.Now.AddDays(7)));
        Groceries.AddItem(new GroceryItem(2, "Bread", 50, DateTime.Now.AddDays(3)));
    }

    public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
    {
        var items = repo.GetAllItems();
        foreach (var item in items)
        {
            Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}");
        }
    }

    public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
    {
        try
        {
            var item = repo.GetItemById(id);
            item.Quantity += quantity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
    {
        try
        {
            repo.RemoveItem(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
