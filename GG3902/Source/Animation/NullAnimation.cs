using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GG3902
{
    public class NullAnimation : IAnimation
    {
        public bool HasLooped => true;

        public bool Playing { get; set; }

        public void Draw(SpriteBatch spriteBatch, Vector2 position) { }

        public void Reset() { }

        public void Update(GameTime gameTime) { }
    }
}
