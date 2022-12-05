using Microsoft.Xna.Framework;

namespace GG3902
{
    public static class GunSpriteFactory
    {
        private static float tileLayerDepth = .29f;

        private static string textureName = "guns";

        public static int Scale = 4;

        public static ISprite LoadSprite(string spriteName, Player player)
        {
            Rectangle bounds;

            switch (spriteName)
            {
                case "MachineGun":
                    bounds = new Rectangle(0, 0, 16, 16);
                    break;
                case "Shotgun":
                    bounds = new Rectangle(32, 0, 16, 16);
                    break;
                case "AR":
                    bounds = new Rectangle(48, 0, 16, 16);
                    break;
                case "Finger":
                    bounds = new Rectangle(64, 0, 16, 16);
                    break;
                case "Pistol":
                    bounds = new Rectangle(80, 0, 16, 16);
                    break;
                case "Rocket Launcher":
                    bounds = new Rectangle(112, 0, 16, 16);
                    break;
                case "Sniper":
                    bounds = new Rectangle(96 ,0, 16, 16);
                    break;
                case "SawbladeGun":
                    bounds = new Rectangle(16, 0, 16, 16);
                    break;
                default:
                    bounds = new Rectangle(0, 0, 16, 16);
                    break;
            }

            ISprite sprite = new GunSprite(TextureManager.Instance.GetTexture(textureName), bounds, Scale, tileLayerDepth, player);
            return sprite;
        }
    }
}
