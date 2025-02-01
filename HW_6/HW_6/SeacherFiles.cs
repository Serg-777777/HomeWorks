
namespace HW_6;

internal class SeacherFiles
{
    private List<Task> _tasks;
    private ReaderFile _readerFile;
    private Action<string> _debuger;
    public CancellationTokenSource TokenSource { get; init; }


    public SeacherFiles(Action<string> debuger)
    {
        _debuger = debuger;
        _readerFile = new ReaderFile(_debuger);
        _tasks = new List<Task>();
        TokenSource = new CancellationTokenSource();
    }
    public async void ReadAsync(string filePath)
    {
        string str = await _readerFile.ReadAsync(filePath, TokenSource.Token);
        FileInfo file = new(filePath);
        _debuger.Invoke($"<<< File: {file.Name}, Пробелов: {str.Where(v=>v == ' ').Count()}, Text:\n{str}");
    }

    public void Search(string directory)
    {
        foreach (var filePath in Directory.GetFiles(directory))
        {
            var tsk = new Task<string>(_readerFile.Read!, (object)filePath, TokenSource.Token);
            _tasks.Add(tsk);
            tsk.Start();
        }
        Task.WaitAll(_tasks.ToArray());
    }
}
