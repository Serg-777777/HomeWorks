
using BenchmarkDotNet.Attributes;

namespace HW_Reflection;

public class Runner
{
    string _nameFile = "containers.csv";
    int _counter = 100;
    [Benchmark]
    public void Serial()
    {
        var data = _Containers();
        for (int i = 0; i < _counter; i++)
            using (var stream = new FileStream(_nameFile, FileMode.Create, FileAccess.Write))
            {
                var cs = new CsvSerializer<Container>();

                cs.Serialize(stream, data);
            }
    }
    [Benchmark]
    public void Deserial()
    {
        IList<Container> data = null!;
        for (int i = 0; i < _counter; i++)
            using (var stream = new FileStream(_nameFile, FileMode.Open, FileAccess.Read))
            {
                var cs = new CsvSerializer<Container>();
                data = cs.Deserialize(stream);
            }
    }
    private static IList<Container> _Containers()
    {
        List<Container> cs = new List<Container>
        {
            new Container(){Description="40HQ", Volume=70.0, Weight=19},
            new Container(){Description="20GP", Volume=63.0, Weight=10}
        };
        return cs;
    }
}
