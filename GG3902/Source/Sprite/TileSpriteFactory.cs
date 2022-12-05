using Microsoft.Xna.Framework;

namespace GG3902
{
    public static class TileSpriteFactory
    {
        private static float tileLayerDepth = 1f;

        private static string textureName = "1_level_tilemap";

        public static int Scale = 4;

        public static ISprite LoadSprite(string spriteName)
        {
            Rectangle bounds;

            switch (spriteName)
            {
                case "GreenFloorTile":
                    bounds = new Rectangle(368, 32, 16, 16);
                    break;
                case "GreyStairTile":
                    bounds = new Rectangle(304, 448, 16, 16);
                    break;
                case "GreyBrickTile":
                    bounds = new Rectangle(288, 480, 16, 16);
                    break;
                case "GreenStairTile":
                    bounds = new Rectangle(384, 1136, 16, 16);
                    break;
                case "BlackBackgroundTile":
                    bounds = new Rectangle(288, 448, 16, 16);
                    break;
                case "DottedFloorTile":
                    bounds = new Rectangle(288, 560, 16, 16);
                    break;
                case "DragonStatueTile":
                    bounds = new Rectangle(400, 64, 16, 16);
                    break;
                case "FishStatueTile":
                    bounds = new Rectangle(336, 80, 16, 16);
                    break;
                case "PyramidTile":
                    bounds = new Rectangle(304, 64, 16, 16);
                    break;
                case "EntireRoom1":
                    bounds = new Rectangle(0, 1232, 256, 176);
                    break;
                case "EntireRoom2":
                    bounds = new Rectangle(256, 1232, 256, 176);
                    break;
                case "EntireRoom3":
                    bounds = new Rectangle(256, 1056, 256, 176);
                    break;
                case "EntireRoom4":
                    bounds = new Rectangle(0, 1056, 256, 176);
                    break;
                case "EntireRoom5":
                    bounds = new Rectangle(0, 880, 256, 176);
                    break;
                case "EntireRoom6":
                    bounds = new Rectangle(0, 704, 256, 176);
                    break;
                case "EntireRoom7":
                    bounds = new Rectangle(256, 704, 256, 176);
                    break;
                case "EntireRoom8":
                    bounds = new Rectangle(256, 528, 256, 176);
                    break;
                case "EntireRoom9":
                    bounds = new Rectangle(0, 528, 256, 176);
                    break;
                case "EntireRoom10":
                    bounds = new Rectangle(0, 352, 256, 176);
                    break;
                case "EntireMap":
                    bounds = new Rectangle(0, 352, 512, 1056);
                    break;
                case "EmptyTile":
                    bounds = new Rectangle(0,0,0,0);
                    break;
                case "Fire":
                    bounds = new Rectangle(0, 0, 0, 0);
                    break;
                case "Void":
                    bounds = new Rectangle(0, 0, 0, 0);
                    break;
                case "Teleporter":
                    bounds = new Rectangle(0,0,0,0);
                    break;
                case "ZombieWorld":
                    bounds = new Rectangle(0,0,1250,1250);
                    textureName = "zombieworld";
                    break;
                default:
                    bounds = new Rectangle(0, 0, 16, 16);
                    break;
            }

            Sprite sprite = new Sprite(TextureManager.Instance.GetTexture(textureName), bounds, Scale, tileLayerDepth, Vector2.Zero);
            textureName = "1_level_tilemap";
            return sprite;
        }
    }
}
