using System;
using System.Collections.Generic;
using System.Linq;
using Delegates;

public class Item
{
    public string Name { get; set; }
    public float Value { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var walker = new DirectoryWalker();
        walker.FileFound += Walker_FileFound;

       
        walker.Walk(@"C:\course");

        var items = new List<Item>
        {
            new Item { Name = "Item1", Value = 1.5f },
            new Item { Name = "Item2", Value = 3.7f },
            new Item { Name = "Item3", Value = 2.8f },
        };

        var maxItem = items.GetMax(item => item.Value);

        Console.WriteLine($"Максимальный элемент: {maxItem.Name} с значением {maxItem.Value}");
    }

    private static void Walker_FileFound(object sender, FileArgs e)
    {
        Console.WriteLine($"Файл найден: {e.FileName}");
    }
}