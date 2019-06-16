using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace HTMLSourceViewer
{
    public class HTMLSourceLoader
    {
        public const int ProgressTimeout = 50;
        private readonly Printer printer;

        public HTMLSourceLoader(Printer printer)
        {
            this.printer = printer;
        }

        public async Task<Result> LoadSource(string url)
        {
            var result = new Result();

            using (var client = new HttpClient())
            {
                try
                {
                    result.HTMLSource = await LoadSource(client, url);
                }
                catch (Exception e)
                {
                    result.IsError = true;
                    result.ErrorMesssage = e.Message;
                }
            }

            return result;
        }

        private async Task<string> LoadSource(HttpClient client, string url)
        {
            var getResponse = client.GetAsync(url);

            WaitForResponse(getResponse);

            var response = await getResponse;

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        private void WaitForResponse(Task<HttpResponseMessage> getResponse)
        {
            printer.PrintLoadingBegin();

            while (!getResponse.IsCompleted)
            {
                printer.PrintLoadingProgress();
                Thread.Sleep(ProgressTimeout);
            }

            printer.PrintLoadingEnd();
        }
    }
}
