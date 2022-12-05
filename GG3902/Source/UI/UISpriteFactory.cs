using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GG3902
{
    public static class UISpriteFactory
    {

        private static float tileLayerDepth = .15f;

        private static string textureName = "UI";
        
        public static int Scale = 4;

        public static ISprite LoadSprite(string spriteName)
        {

            Rectangle bounds;

            switch (spriteName)
            {
                case "RedMarker":
                    bounds = new Rectangle(144, 8, 3, 3);
                    break;
                case "BlueMarker":
                    bounds = new Rectangle(147, 8, 3, 3);
                    break;
                case "LinkMarker":
                    bounds = new Rectangle(150, 8, 3, 3);
                    break;
                case "0":
                    bounds = new Rectangle(16, 0, 8, 8);
                    break;
                case "1":
                    bounds = new Rectangle(24, 0, 8, 8);
                    break;
                case "2":
                    bounds = new Rectangle(32, 0, 8, 8);
                    break;
                case "3":
                    bounds = new Rectangle(40, 0, 8, 8);
                    break;
                case "4":
                    bounds = new Rectangle(48, 0, 8, 8);
                    break;
                case "5":
                    bounds = new Rectangle(56, 0, 8, 8);
                    break;
                case "6":
                    bounds = new Rectangle(64, 0, 8, 8);
                    break;
                case "7":
                    bounds = new Rectangle(72, 0, 8, 8);
                    break;
                case "8":
                    bounds = new Rectangle(80, 0, 8, 8);
                    break;
                case "9":
                    bounds = new Rectangle(88, 0, 8, 8);
                    break;
                case "Empty_Heart":
                    bounds = new Rectangle(96, 0, 8, 8);
                    break;
                case "Half_Heart":
                    bounds = new Rectangle(104, 0, 8, 8);
                    break;
                case "Full_Heart":
                    bounds = new Rectangle(112, 0, 8, 8);
                    break;
                case "All_Doors":
                    bounds = new Rectangle(120, 0, 8, 8);
                    break;
                case "Bottom_and_Left_Doors":
                    bounds = new Rectangle(128, 0, 8, 8);
                    break;
                case "Bottom_and_Right_Doors":
                    bounds = new Rectangle(136, 0, 8, 8);
                    break;
                case "Bottom_and_Side_Doors":
                    bounds = new Rectangle(144, 0, 8, 8);
                    break;
                case "Bottom_Door":
                    bounds = new Rectangle(152, 0, 8, 8);
                    break;
                case "Isolated_Room":
                    bounds = new Rectangle(160, 0, 8, 8);
                    break;
                case "Left_Door":
                    bounds = new Rectangle(168, 0, 8, 8);
                    break;
                case "No_Room":
                    bounds = new Rectangle(176, 0, 8, 8);
                    break;
                case "Right_Door":
                    bounds = new Rectangle(184, 0, 8, 8);
                    break;
                case "Side_Doors":
                    bounds = new Rectangle(192, 0, 8, 8);
                    break;
                case "Top_and_Bottom_Door":
                    bounds = new Rectangle(200, 0, 8, 8);
                    break;
                case "Top_and_Left_Door":
                    bounds = new Rectangle(208, 0, 8, 8);
                    break;
                case "Top_and_Right_Door":
                    bounds = new Rectangle(216, 0, 8, 8);
                    break;
                case "Top_and_Side_Doors":
                    bounds = new Rectangle(224, 0, 8, 8);
                    break;
                case "Top_Bottom_and_Left_Doors":
                    bounds = new Rectangle(232, 0, 8, 8);
                    break;
                case "Top_Bottom_and_Right_Doors":
                    bounds = new Rectangle(240, 0, 8, 8);
                    break;
                case "Top_Door":
                    bounds = new Rectangle(248, 0, 8, 8);
                    break;
                case "Both_Minimap_Rectangles":
                    bounds = new Rectangle(120, 8, 8, 8);
                    break;
                case "Top_Minimap_Rectangle":
                    bounds = new Rectangle(128, 8, 8, 8);
                    break;
                case "Bottom_Minimap_Rectangle":
                    bounds = new Rectangle(133, 8, 8, 8);
                    break;
                case "Wooden_Sword":
                    bounds = new Rectangle(0, 8, 8, 16);
                    break;
                case "Metal_Sword":
                    bounds = new Rectangle(8, 8, 8, 16);
                    break;
                case "Tilted_Sword":
                    bounds = new Rectangle(16, 8, 8, 16);
                    break;
                case "Boomerang":
                    bounds = new Rectangle(24, 8, 8, 16);
                    break;
                case "BlueBoomerang":
                    bounds = new Rectangle(32, 8, 8, 16);
                    break;
                case "Bomb":
                    bounds = new Rectangle(40, 8, 8, 16);
                    break;
                case "GreenArrow":
                    bounds = new Rectangle(48, 8, 8, 16);
                    break;
                case "BlueArrow":
                    bounds = new Rectangle(56, 8, 8, 16);
                    break;
                case "Bow":
                    bounds = new Rectangle(64, 8, 8, 16);
                    break;
                case "Blue_Candle":
                    bounds = new Rectangle(72, 8, 8, 16);
                    break;
                case "Red_Candle":
                    bounds = new Rectangle(80, 8, 8, 16);
                    break;
                case "Rolled_Scroll":
                    bounds = new Rectangle(88, 8, 8, 16);
                    break;
                case "Meat":
                    bounds = new Rectangle(96, 8, 8, 16);
                    break;
                case "White_Page":
                    bounds = new Rectangle(104, 8, 8, 16);
                    break;
                case "Blue_Potion":
                    bounds = new Rectangle(112, 8, 8, 16);
                    break;
                case "Red_Potion":
                    bounds = new Rectangle(0, 24, 8, 16);
                    break;
                case "Blue_Staff":
                    bounds = new Rectangle(8,24, 8, 16);
                    break;
                case "Red_Book":
                    bounds = new Rectangle(16, 24, 8, 16);
                    break;
                case "Red_Ring":
                    bounds = new Rectangle(24, 24, 8, 16);
                    break;
                case "Lion_Key":
                    bounds = new Rectangle(32, 24, 8, 16);
                    break;
                case "Crescent":
                    bounds = new Rectangle(40, 24, 8, 16);
                    break;
                case "Map":
                    bounds = new Rectangle(48, 24, 8, 16);
                    break;
                case "Logs":
                    bounds = new Rectangle(56, 24, 16, 16);
                    break;
                case "Ladder":
                    bounds = new Rectangle(72, 24, 16, 16);
                    break;
                case "Compass":
                    bounds = new Rectangle(88, 24, 15, 16);
                    break;
                case "BlueCursor":
                    bounds = new Rectangle(103, 24, 16, 16);
                    break;
                case "Bullet":
                    bounds = new Rectangle(136, 24, 2, 2);
                    break;
                case "Pistol":
                    bounds = new Rectangle(0, 272, 16, 16);
                    break;
                case "Shotgun":
                    bounds = new Rectangle(16, 272, 16, 16);
                    break;
                case "AR":
                    bounds = new Rectangle(32, 272, 16, 16);
                    break;
                case "Sniper":
                    bounds = new Rectangle(48, 272, 16, 16);
                    break;
                case "SawbladeGun":
                    bounds = new Rectangle(64, 272, 16, 16);
                    break;
                case "Rocket Launcher":
                    bounds = new Rectangle(80, 272, 16, 16);
                    break;
                case "MachineGun":
                    bounds = new Rectangle(96, 272, 16, 16);
                    break;
                case "Finger":
                    bounds = new Rectangle(112, 272, 16, 16);
                    break;
                case "RedCursor":
                    bounds = new Rectangle(119, 24, 16, 16);
                    break;
                case "BlueRooms":
                    bounds = new Rectangle(207, 15, 49, 25);
                    break;
                case "BaseInventory":
                    bounds = new Rectangle(0, 40, 256, 88);
                    break;
                case "BaseMap":
                    bounds = new Rectangle(0, 128, 256, 88);
                    break;
                case "BaseHUD":
                    bounds = new Rectangle(0, 214, 256, 58);
                    break;
                default:
                    bounds = new Rectangle(0, 0, 0, 0);
                    break;
            }

            if (spriteName.Contains("Base"))
                return new Sprite(TextureManager.Instance.GetTexture(textureName), bounds, Scale, tileLayerDepth + .01f, new Vector2(bounds.Width / 2, bounds.Height / 2));
            else
                return new Sprite(TextureManager.Instance.GetTexture(textureName), bounds, Scale, tileLayerDepth, new Vector2(bounds.Width / 2, bounds.Height / 2));
        }
    }
}
