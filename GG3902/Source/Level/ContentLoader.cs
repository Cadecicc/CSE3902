namespace GG3902
{
    public abstract class ContentLoader
    {
        private CommandList contentCommands;

        public ContentLoader()
        {
            contentCommands = new CommandList();
        }

        public void Load()
        {
            contentCommands.ExecuteCommands();
        }

        protected void RegisterContentCommand(ICommand command)
        {
            contentCommands.RegisterCommand(command);
        }
    }
}
