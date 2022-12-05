using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace GG3902
{
    public class HUD
    {
        private UIElement baseHUD;
        private UIElement rooms;
        private UIElement equippedItem;
        private UIElement[] bullets;
        private UIElement[] scoreCount;
        private UIElement[] roundCount;
        private UIElement[] killCount;
        private UIElement[] hearts;

        private static Vector2 outOfSight = new Vector2(1000000, 10000000);
        private Vector2 baseHUDOffset;
        private Vector2 roomsOffset;
        private Vector2 equippedItemOffset;
        private Vector2 heartOffset;
        private Vector2 bulletOffset;

        public HUD()
        {
            baseHUD = new UIElement("BaseHUD");
            rooms = new UIElement("");
            equippedItem = new UIElement("");

            baseHUDOffset = new Vector2(0, 352);
            roomsOffset = new Vector2(-320, -16);
            equippedItemOffset = new Vector2(16, -20);
            heartOffset = new Vector2(208, 316);
            bulletOffset = new Vector2(-476, 20);

            hearts = new UIElement[16];
            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i] = new UIElement("Empty_Heart");
            }

            scoreCount = new UIElement[3];
            roundCount = new UIElement[3];
            killCount = new UIElement[3];
            for (int i = 0; i < 3; i++)
            {
                scoreCount[i] =  new UIElement("0");
                roundCount[i] = new UIElement("0");
                killCount[i] = new UIElement("0");
            }

            bullets = new UIElement[100];
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = new UIElement("Bullet");
            }

            SetEquippedItem("Pistol");
        }

        public void UpdateKills(int numOfKills)
        {
            numOfKills = Math.Min(numOfKills, 999);
            for (int i = 0; i < 3; i++)
            {
                killCount[i].DeleteSelf();
                killCount[i] = new UIElement("" + (numOfKills % 10));
                numOfKills /= 10;
            }
        }

        public void UpdateScore(int score)
        {
            score = Math.Min(score, 999);
            for (int i = 0; i < 3; i++)
            {
                scoreCount[i].DeleteSelf();
                scoreCount[i] = new UIElement("" + (score % 10));
                score /= 10;
            }
        }

        public void UpdateRound(int round)
        {
            round = Math.Min(round, 999);
            for (int i = 0; i < 3; i++)
            {
                roundCount[i].DeleteSelf();
                roundCount[i] = new UIElement("" + (round % 10));
                round /= 10;
            }
        }

        public void UpdateAmmo(int ammo)
        {
            for (int i = 0; i < Math.Min(100, ammo); i++)
            {
                bullets[i].Enabled = true;
            }

            for (int i = ammo; i < 100; i++)
            {
                bullets[i].Enabled = false;
            }
        }

        // Sets each HUD element position relative to the camera's position
        public void SetPosition(Vector2 cameraPosition)
        {
            baseHUD.Position = cameraPosition + baseHUDOffset;
            rooms.Position = baseHUD.Position + roomsOffset;
            equippedItem.Position = baseHUD.Position + equippedItemOffset;

            // Set the position for score, kills, and round
            for (int i = 0; i < 3; i++)
            {
                scoreCount[i].Position = baseHUD.Position + new Vector2(-48 + i * -32, 28);
                killCount[i].Position = baseHUD.Position + new Vector2(-48 + i * -32, -20);
                roundCount[i].Position = baseHUD.Position + new Vector2(-48 + i * -32, -68);
            }

            // Set the position for each bullet
            for (int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i].Enabled)
                    bullets[i].Position = baseHUD.Position + bulletOffset + new Vector2((i % 20) * 12, (i / 20) * -20);
                else
                    bullets[i].Position = outOfSight;
            }

            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i].Position = cameraPosition + heartOffset + new Vector2((i) % 8 * 32, -(i) / 8 * 32);
            }
        }

        // Sets the incoming item to the active item in the second slot of the HUD
        public void SetEquippedItem(string item)
        {
            if (!equippedItem.Type.Equals(""))
                equippedItem.Position = outOfSight;
            equippedItem = new UIElement(item);
        }

        // Adds the minimap to the HUD
        public void EnableRooms()
        {
            EntityManager.Instance.RemoveEntity(rooms.Id);
            rooms = new UIElement("BlueRooms");
        }

        public void UpdateHP(int health)
        {
            for (int i = 0; i < 16; i++)
            {
                hearts[i].DeleteSelf();

                if (i < health / 2)
                    hearts[i] = new UIElement("Full_Heart");
                else if ((i * 2 <= health) && (health % 2 == 1))
                    hearts[i] = new UIElement("Half_Heart");
                else
                    hearts[i] = new UIElement("Empty_Heart");
            }
        }
    }
}