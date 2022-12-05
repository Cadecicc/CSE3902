using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GG3902
{
    public class GunSprite : ISprite
    {
        private static Vector2 Flip = new Vector2(1, -1);

        private Texture2D texture;
        private Rectangle sourceRect;
        private Vector2 pivot;
        private float scale;
        private float layerDepth;
        private Player player;

        public GunSprite(Texture2D texture, Rectangle sourceRect, float scale, float layerDepth, Player player)
        {
            this.texture = texture;
            this.sourceRect = sourceRect;
            pivot = new Vector2(8, 16);
            this.scale = scale;
            this.layerDepth = layerDepth;
            this.player = player;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(texture, position * Flip, sourceRect, Color.White, MathF.Atan2(player.Rotation.X, player.Rotation.Y), pivot, Vector2.One * scale, SpriteEffects.None, layerDepth);
        }

        public void Update(GameTime gameTime) { }
    }
}
