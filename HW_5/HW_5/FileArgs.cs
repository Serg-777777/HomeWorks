

namespace HW_5;

internal class FileArgs : EventArgs
{
    public string Name { get; init; }
    public FileArgs(string  name)
    {
        Name = name;
    }
}

