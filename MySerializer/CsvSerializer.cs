

class CsvSerializer
{
    public static string Serialize(F obj)
    {
        return $"{obj.i1},{obj.i2},{obj.i3},{obj.i4},{obj.i5}";
    }

    public static F Deserialize(string csv)
    {
        var values = csv.Split(',');
        return new F()
        {
            i1 = int.Parse(values[0]),
            i2 = int.Parse(values[1]),
            i3 = int.Parse(values[2]),
            i4 = int.Parse(values[3]),
            i5 = int.Parse(values[4])
        };
    }
}
