class Program
{
    static void Main(string[] args)
    {
        string filePath = "inventory.json"; // Specify the file path for saving inventory data
        InventoryApp app = new InventoryApp(filePath);

        // Seed sample data
        app.SeedSampleData();

        // Save data to file
        app.SaveData();

        // Clear memory and simulate a new session
        app = new InventoryApp(filePath);

        // Load data from file
        app.LoadData();

        // Print all items to confirm data was recovered
        app.PrintAllItems();
    }
}
