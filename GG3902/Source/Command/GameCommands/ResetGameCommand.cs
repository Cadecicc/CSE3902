namespace GG3902
{
    public class ResetGameCommand : ICommand
    {
        private Game1 game;

        public ResetGameCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Reset();
        }

        public void Undo() { }
    }
}
