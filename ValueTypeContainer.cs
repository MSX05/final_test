using System;
using System.Collections.Generic;
using System.Linq;

public class ValueTypeContainer<T> where T : struct // Constraint to value types
{
    private List<T> valueList;

    public ValueTypeContainer()
    {
        valueList = new List<T>();
    }

    // Method to add items to the private collection
    public void AddItem(T item)
    {
        valueList.Add(item);
    }

    // Method to return an item from the list based on index (starting from 0)
    public T GetItem(int index)
    {
        if (index < 0 || index >= valueList.Count)
        {
            throw new IndexOutOfRangeException("Index out of range");
        }
        return valueList[index];
    }

    // Method to return a sorted collection in descending order
    public IEnumerable<T> GetSortedDescending()
    {
        var sortedList = valueList.OrderByDescending(x => x);
        return sortedList;
    }
}
