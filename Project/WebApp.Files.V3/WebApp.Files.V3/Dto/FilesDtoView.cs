namespace Presentation.Dto
{
    public class FilesDtoView
    {
        public string? FileName { get; private set; }
        public FilesDtoView(string filename)
        {
            FileName = filename;
        }
    }
}
