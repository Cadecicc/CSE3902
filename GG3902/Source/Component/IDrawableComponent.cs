using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GG3902
{
    public interface IDrawableComponent : IComponent
    {
        public void Draw(SpriteBatch spriteBatch, Vector2 position);
    }
}
