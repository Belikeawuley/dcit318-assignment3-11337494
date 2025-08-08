using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class InventoryLogger<T> where T : IInventoryEntity
{
    private List<T> _log = new List<T>();
    private string _filePath;

    public InventoryLogger(string filePath)
    {
        _filePath = filePath;
    }

    public void Add(T item)
    {
        _log.Add(item);
    }

    public List<T> GetAll()
    {
        return _log;
    }

    public void SaveToFile()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                string json = JsonSerializer.Serialize(_log);
                writer.Write(json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
        }
    }

    public void LoadFromFile()
    {
        try
        {
            using (StreamReader reader = new StreamReader(_filePath))
            {
                string json = reader.ReadToEnd();
                _log = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading from file: {ex.Message}");
        }
    }
}
