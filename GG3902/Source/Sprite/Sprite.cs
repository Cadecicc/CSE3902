using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace GG3902
{
    public class Sprite : ISprite
    {
        private static Vector2 Flip = new Vector2(1, -1);

        private Texture2D texture;
        private Rectangle sourceRect;
        private Vector2 pivot;
        private float scale;
        private float layerDepth;

        public Sprite(Texture2D texture, Rectangle sourceRect, float scale, float layerDepth)
        {
            this.texture = texture;
            this.sourceRect = sourceRect;
            pivot = new Vector2(sourceRect.Width / 2f, sourceRect.Height / 2f);
            this.scale = scale;
            this.layerDepth = layerDepth;
        }

        public Sprite(Texture2D texture, Rectangle sourceRect, float scale, float layerDepth, Vector2 pivot)
        {
            this.texture = texture;
            this.sourceRect = sourceRect;
            this.pivot = pivot;
            this.scale = scale;
            this.layerDepth = layerDepth;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(texture, position * Flip, sourceRect, Color.White, 0f, pivot, Vector2.One * scale, SpriteEffects.None, layerDepth);
        }

        public void Update(GameTime gameTime) { }
    }
}
