using static System.Console;

namespace HTMLSourceViewer
{
    public class Printer
    {
        public void PrintSource(string source)
        {
            WriteLine($"HTML source:\n{source}");
        }

        public void PrintError(string error)
        {
            WriteLine($"Error: {error}");
        }

        public void PrintInvalidArguments()
        {
            WriteLine("Invalid number of arguments");
        }

        public void PrintLoadingBegin()
        {
            Write("Loading HTML source");
        }

        public void PrintLoadingProgress()
        {
            Write('.');
        }

        public void PrintLoadingEnd()
        {
            WriteLine();
        }
    }
}
