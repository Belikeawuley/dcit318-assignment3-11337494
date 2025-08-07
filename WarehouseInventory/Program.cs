class Program
{
    static void Main()
    {
        var manager = new WareHouseManager();
        manager.SeedData();

        Console.WriteLine("Grocery Items:");
        manager.PrintAllItems(manager.Groceries);

        Console.WriteLine("\nElectronic Items:");
        manager.PrintAllItems(manager.Electronics);

        // Test error scenarios
        Console.WriteLine("\nTesting error scenarios:");
        
        // Try to add a duplicate item
        try
        {
            manager.Electronics.AddItem(new ElectronicItem(1, "Tablet", 5, "BrandC", 12));
        }
        catch (DuplicateItemException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Try to remove a non-existent item
        try
        {
            manager.RemoveItemById(manager.Groceries, 3);
        }
        catch (ItemNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Try to update with invalid quantity
        try
        {
            manager.Groceries.UpdateQuantity(1, -5);
        }
        catch (InvalidQuantityException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
