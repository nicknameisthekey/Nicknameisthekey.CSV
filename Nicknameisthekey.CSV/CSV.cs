using System.Reflection;

namespace Nicknameisthekey.CSV;

public class CSV
{
    public static List<T> ParseString<T>(string csv, string? separator = ",") where T : new()
    {
        var mapings = GetMapings(typeof(T));
        var lineSeparator = csv.Contains("\r\n") ? "\r\n" : "\n";
        var lines = csv.Split(lineSeparator); //todo
        List<T> result = new();
        foreach (var line in lines)
        {
            var columns = line.Split(separator);
            var obj = new T();
            for (int i = 0; i < columns.Length; i++)
            {
                if (mapings.ContainsKey(i))
                {
                    object? value = null;
                    if (mapings[i].PropertyType == typeof(int))
                        value = int.Parse(columns[i]);
                    else if (mapings[i].PropertyType == typeof(string))
                        value = columns[i];
                    else if (mapings[i].PropertyType == typeof(DateTime))
                        value = DateTime.Parse(columns[i]);
                    mapings[i].SetValue(obj, value);
                };
            }
            result.Add(obj);
        }
        return result;
    }

    public static List<T> ParseFromFile<T>(string fileName) where T : new()
    {
        var fileData = File.ReadAllText(fileName);
        return ParseString<T>(fileData);
    }
    private static Dictionary<int, PropertyInfo> GetMapings(Type t)
    {
        var result = new Dictionary<int, PropertyInfo>();

        foreach (var property in t.GetProperties())
        {
            var attr = property.GetCustomAttribute
                (typeof(ColumnAttribute)) as ColumnAttribute;
            if (attr != null && result.ContainsKey(attr.ColumnNumber) == false)
            {
                result.Add(attr.ColumnNumber, property);
            }
        }

        return result;
    }
}
