using System.Collections.Generic;

public class Factory<T>
{
    public Dictionary<string, T> CloneDictionary = new();

    public T this[string key]
    {
        get
        {
            if (CloneDictionary.TryGetValue(key, out var item))
            {
                return item;
            }
          
                throw new KeyNotFoundException("Key not fouund " + key);
            
        }
        set => CloneDictionary[key] = value;
    }
}