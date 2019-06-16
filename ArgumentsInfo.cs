namespace HTMLSourceViewer
{
    public class ArgumentsInfo
    {
        private readonly string[] args;

        public ArgumentsInfo(string[] args)
        {
            this.args = args;
        }

        public bool AreArgumentsValid()
        {
            return args.Length != 0;
        }

        public string GetURLArgument()
        {
            return args[0];
        }
    }
}
