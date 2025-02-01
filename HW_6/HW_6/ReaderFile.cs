
namespace HW_6;

internal class ReaderFile
{
    private Action<string> _debuger;
    public ReaderFile(Action<string> debuger)
    {
        _debuger = debuger;
    }
    public async Task<string> ReadAsync(string path, CancellationToken token)
    {
        if (!_ExistPath(path)) return default!;
        string str = await File.ReadAllTextAsync(path, token);
        return str;
    }
    public string Read(object path)
    {
        var str = (string)path;
        if (!_ExistPath(str)) return default!;
        var txt = File.ReadAllText(str);
        var f = new FileInfo(str);

        _debuger.Invoke($"<<< TaskId: {Task.CurrentId}, File: {f.Name}, Пробелов: {txt.Where(p => p == ' ').Count()}, Text: {txt}");
        return Task.CompletedTask.ToString()!;
    }

    private bool _ExistPath(string path)
    {
        bool isExist = true;
        if (!Directory.Exists(path))
        {
            isExist = false;
            _debuger($":Error: Директория не существует => {path}");
        }
        return isExist;
    }
}
