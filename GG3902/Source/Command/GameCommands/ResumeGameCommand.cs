using Microsoft.Xna.Framework;

namespace GG3902
{
    public class ResumeGameCommand : GameCommand
    {
        public ResumeGameCommand(Game1 game) : base(game) { }

        public override void Execute()
        {
            Receiver.ReverseState();
        }

        public override void Undo() { }
    }
}
