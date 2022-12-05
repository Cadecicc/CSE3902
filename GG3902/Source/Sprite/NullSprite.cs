using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GG3902
{
    public class NullSprite : ISprite
    {
        public NullSprite() { }

        public void Draw(SpriteBatch spriteBatch, Vector2 position) { }

        public void Update(GameTime gameTime) { }
    }
}
