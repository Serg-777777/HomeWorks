

using System.Diagnostics;

namespace HW_6;

internal class RunnerSeacher
{
    SeacherFiles searcher = new SeacherFiles(Console.WriteLine);
    public void SearcherRunAsync(string filePath)
    {
        searcher.ReadAsync(filePath);
    }
    public void SearcherRun(string directory)
    {
        searcher.Search(directory);
    }
}
