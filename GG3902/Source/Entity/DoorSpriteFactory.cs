using Microsoft.Xna.Framework;

namespace GG3902
{
    public static class DoorSpriteFactory
    {
        private static float tileLayerDepth = .2f;

        private static string textureName = "1_level_tilemap";

        public static int Scale = 4;

        public static ISprite LoadSprite(string spriteName)
        {
            Rectangle bounds;

            switch (spriteName)
            {
                case "NormalDoorRight":
                    bounds = new Rectangle(240, 592, 16, 48);
                    break;
                case "NormalDoorLeft":
                    bounds = new Rectangle(256, 592, 16, 48);
                    break;
                case "NormalDoorUp":
                    bounds = new Rectangle(104, 528, 48, 16);
                    break;
                case "NormalDoorDown":
                    bounds = new Rectangle(360, 688, 48, 16);
                    break;
                default:
                    bounds = new Rectangle(0, 0, 16, 16);
                    break;
            }

            return new Sprite(TextureManager.Instance.GetTexture(textureName), bounds, Scale, tileLayerDepth, Vector2.Zero);
        }
    }
}
