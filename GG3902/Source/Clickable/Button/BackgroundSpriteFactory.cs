using Microsoft.Xna.Framework;

namespace GG3902
{
    public static class BackgroundSpriteFactory
    {
        private static float backgroundLayerDepth = .02f;
        private static int Scale = 1;
        private static Rectangle rect = new Rectangle(0, 0, 1024, 704);

        public static ISprite LoadSprite(string textureName)
        {
            return new Sprite(TextureManager.Instance.GetTexture(textureName), rect, Scale, backgroundLayerDepth);
        }
    }
}
