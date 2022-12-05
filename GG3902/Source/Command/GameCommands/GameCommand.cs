using Microsoft.Xna.Framework;

namespace GG3902
{
    public abstract class GameCommand : GenericCommand<Game1>
    {
        public GameCommand(Game1 game) : base(game) { }
    }
}
