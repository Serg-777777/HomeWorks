

namespace HW_5;

internal class SearchFiles
{
    public void Search(string path)
    {
        bool isFounding = false;
        foreach(var v in Directory.GetFiles(path))
        {
            if (!isFounding) isFounding = true;
            IsFounHandler?.Invoke(this, new FileArgs(v));
        }
        if (!isFounding) NotFiles?.Invoke();
        IsFounHandler = null;
    }

    public event EventHandler<FileArgs>? IsFounHandler;
    public Action? NotFiles;
}
