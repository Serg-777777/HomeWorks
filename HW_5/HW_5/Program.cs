

using Microsoft.VisualBasic.FileIO;

namespace HW_5;

 class Program
{
    static void Main()
    {
        GetMaxNum();
        GetMaxObjectValue();
        SearchingFiles(SpecialDirectories.MyDocuments);
    }

    private static void SearchingFiles(string path)
    {
        var search = new SearchFiles();
        search.IsFounHandler += SearchingMethods.OkResult!;
        search.NotFiles = SearchingMethods.NotResult!;
        search.Search(path);
    }

    private static void GetMaxNum()
    {
        List<int> arr = new() { 10, 100, 5, 20, 200, 30 };
        var res = arr.GetMax<int>(p => p);
        Console.WriteLine($"Максимальное число: {res}");
    }

    private static void GetMaxObjectValue()
    {
         ICollection<ValueObject> objs = new List<ValueObject>()
        {
            new ValueObject(1000.05f),
            new ValueObject(1000.55f),
            new ValueObject(1000.50f)
        };
        var res = objs.GetMax<ValueObject>(o =>  o.Value);
        Console.WriteLine($"Описание объекта с макс. значением: {res.Desc}");
    }
}

  

