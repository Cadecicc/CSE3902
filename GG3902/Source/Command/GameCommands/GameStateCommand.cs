namespace GG3902
{
    public class GameStateCommand : GameCommand
    {
        private IState nextState;

        public GameStateCommand(Game1 game, IState nextState) : base(game)
        {
            this.nextState = nextState;
        }

        public override void Execute()
        {
            Receiver.SetState(nextState);
        }

        public override void Undo() { }
    }
}
