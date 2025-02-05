
using System.Text.Json;

namespace HW_8;

internal class SamplesFactory
{
    public static T? GetClone<T>(T item) where T : class
    {
        var str = JsonSerializer.Serialize(item);
        var obj = JsonSerializer.Deserialize<T>(str);
        return obj;
    }
}
