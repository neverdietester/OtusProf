using Newtonsoft.Json;
using Reflection;
using System.Diagnostics;
class Program

{
    static void Main(string[] args)
    {
        F fInstance = F.Get();

        // 3. Замер времени сериализации
        int iterations = 1000;
        string serializedString = null;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < iterations; i++)
        {
            serializedString = fInstance.Serialize();
        }

        stopwatch.Stop();
        Console.WriteLine($"Сериализация: {serializedString}");
        Console.WriteLine($"Время на сериализацию (пользовательская): {stopwatch.ElapsedMilliseconds} мс");

        // 7. Сериализация с использованием Newtonsoft.Json
        stopwatch.Reset();
        stopwatch.Start();

        string jsonString = null;

        for (int i = 0; i < iterations; i++)
        {
            jsonString = JsonConvert.SerializeObject(fInstance);
        }

        stopwatch.Stop();
        Console.WriteLine($"JSON Сериализация: {jsonString}");
        Console.WriteLine($"Время на сериализацию (Newtonsoft.Json): {stopwatch.ElapsedMilliseconds} мс");

        // 9. Десериализация из строки
        stopwatch.Reset();
        stopwatch.Start();

        F deserializedInstance = null;

        for (int i = 0; i < iterations; i++)
        {
            deserializedInstance = F.Deserialize(serializedString);
        }

        stopwatch.Stop();
        Console.WriteLine($"Десериализация: i1={deserializedInstance.i1}, i2={deserializedInstance.i2}, i3={deserializedInstance.i3}, i4={deserializedInstance.i4}, i5={deserializedInstance.i5}");
        Console.WriteLine($"Время на десериализацию (пользовательская): {stopwatch.ElapsedMilliseconds} мс");

        // 11. Десериализация с использованием Newtonsoft.Json
        stopwatch.Reset();
        stopwatch.Start();

        F jsonDeserializedInstance = null;

        for (int i = 0; i < iterations; i++)
        {
            jsonDeserializedInstance = JsonConvert.DeserializeObject<F>(jsonString);
        }

        stopwatch.Stop();
        Console.WriteLine($"JSON Десериализация: i1={jsonDeserializedInstance.i1}, i2={jsonDeserializedInstance.i2}, i3={jsonDeserializedInstance.i3}, i4={jsonDeserializedInstance.i4}, i5={jsonDeserializedInstance.i5}");
        Console.WriteLine($"Время на десериализацию (Newtonsoft.Json): {stopwatch.ElapsedMilliseconds} мс");
    }
}