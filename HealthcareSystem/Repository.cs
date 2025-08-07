using System;
using System.Collections.Generic;

public class Repository<T>
{
    private readonly List<T> _items = new List<T>();
    
    // Adds an item to the repository
    public void Add(T item)
    {
        _items.Add(item);
    }

    // Returns all items
    public List<T> GetAll()
    {
        return new List<T>(_items); // Return copy for safety
    }

    // Gets item by predicate (e.g., ID matching)
    public T? GetById(Predicate<T> predicate)
    {
        return _items.Find(predicate);
    }

    // Removes item matching predicate
    public bool Remove(Predicate<T> predicate)
    {
        var item = _items.Find(predicate);
        return item != null && _items.Remove(item);
    }
}
