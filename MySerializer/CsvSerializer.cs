

using System.Reflection;

class CsvSerializer
{
    public static string Serialize<T>(T obj)
    {
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var values = properties.Select(prop => prop.GetValue(obj, null)?.ToString() ?? string.Empty);
        return string.Join(",", values);
    }

    public static T Deserialize<T>(string csv)
    {
        var values = csv.Split(',');
        var obj = Activator.CreateInstance<T>();
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        for (int i = 0; i < properties.Length; i++)
        {
            if (i < values.Length)
            {
                var value = Convert.ChangeType(values[i], properties[i].PropertyType);
                properties[i].SetValue(obj, value);
            }
        }

        return obj;
    }
}
