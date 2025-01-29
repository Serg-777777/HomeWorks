

namespace HW_5;

static class GetValueExtention
{
    public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber)
    {

        ArgumentNullException.ThrowIfNull(collection);

        if (collection.Count() > 0)
        {
            float maxVal = 0;
            T val = default(T)!;

            foreach (var v in collection)
            {
                var num = convertToNumber(v);
                if (maxVal < num)
                {
                    maxVal = num;
                    val = v;
                }
            }
            return val;
        }
        else
            throw new ArgumentException("Коллекция не содержит элементы");
    }
}

