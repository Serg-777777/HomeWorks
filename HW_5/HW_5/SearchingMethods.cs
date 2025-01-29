

namespace HW_5;

internal class SearchingMethods
{
    public static void OkResult(object sender, FileArgs args)
    {
        Console.WriteLine($"::File path event: {args.Name}");
    }
    public static void NotResult()
    {
        Console.WriteLine($"::Файлы не найдены::");
    }
}
