using System.Threading.Tasks;

namespace HTMLSourceViewer
{

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var info = new ArgumentsInfo(args);
            var printer = new Printer();

            if (!info.AreArgumentsValid())
            {
                printer.PrintInvalidArguments();
                return;
            }
            
            var url = info.GetURLArgument();
            var loader = new HTMLSourceLoader(printer);
            var result = await loader.LoadSource(url);

            if (result.IsError)
            {
                printer.PrintError(result.ErrorMesssage);
            }
            else
            {
                printer.PrintSource(result.HTMLSource);
            }
        }
    }
}
