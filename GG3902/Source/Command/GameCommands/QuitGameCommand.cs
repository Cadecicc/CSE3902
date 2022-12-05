using Microsoft.Xna.Framework;

namespace GG3902
{
    public class QuitGameCommand : GameCommand
    {
        public QuitGameCommand(Game1 game) : base(game) { }

        public override void Execute()
        {
            Receiver.Exit();
        }

        public override void Undo() { }
    }
}
