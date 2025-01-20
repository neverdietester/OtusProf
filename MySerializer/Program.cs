using Newtonsoft.Json;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        var obj = F.Get();
        int iterations = 100000;

        // Сериализация с помощью собственного механизма
        var stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            var csv = CsvSerializer.Serialize(obj);
        }
        stopwatch.Stop();
        Console.WriteLine($"Время на сериализацию (CSV): {stopwatch.ElapsedMilliseconds} мс");

        // Сериализация с помощью Newtonsoft.Json
        stopwatch.Restart();
        for (int i = 0; i < iterations; i++)
        {
            var json = JsonConvert.SerializeObject(obj);
        }
        stopwatch.Stop();
        Console.WriteLine($"Время на сериализацию (Newtonsoft.Json): {stopwatch.ElapsedMilliseconds} мс");

        // Десериализация с помощью собственного механизма
        string csvString = CsvSerializer.Serialize(obj);
        stopwatch.Restart();
        for (int i = 0; i < iterations; i++)
        {
            var deserializedObj = CsvSerializer.Deserialize<F>(csvString);
        }
        stopwatch.Stop();
        Console.WriteLine($"Время на десериализацию (CSV): {stopwatch.ElapsedMilliseconds} мс");

        // Десериализация с помощью Newtonsoft.Json
        string jsonString = JsonConvert.SerializeObject(obj);
        stopwatch.Restart();
        for (int i = 0; i < iterations; i++)
        {
            var deserializedObj = JsonConvert.DeserializeObject<F>(jsonString);
        }
        stopwatch.Stop();
        Console.WriteLine($"Время на десериализацию (Newtonsoft.Json): {stopwatch.ElapsedMilliseconds} мс");
    }
}
