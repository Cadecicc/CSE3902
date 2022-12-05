using Microsoft.Xna.Framework;

namespace GG3902
{
    public static class ToggleButtonFactory
    {
        public static ToggleButton SpawnToggleButton(string buttonName, int width, int height, Camera camera)// put things here
        {
            Vector2 screenBottomRightCorner = new Vector2(475, -425);
            Vector2 screenBottomLeftCorner = new Vector2(-475, -425);
            int spriteWidth = width;
            int spriteHeight = height;
            ToggleButton button;
            switch (buttonName)
            {
                case "ToggleMuteSongButton":
                    button = new ToggleButton(buttonName,"MuteSongButton", "UnmuteSongButton", camera.WorldPosition + screenBottomRightCorner);
                    button.SpriteWidth = spriteWidth;
                    button.SpriteHeight = spriteHeight;
                    button.Initialize();
                    break;
                case "ToggleMuteSoundButton":
                    button = new ToggleButton(buttonName,"MuteSoundButton", "UnmuteSoundButton", camera.WorldPosition + screenBottomLeftCorner);
                    button.SpriteWidth = spriteWidth;
                    button.SpriteHeight = spriteHeight;
                    button.Initialize();
                    break;
                default:
                    button = null;
                    break;
            }
            return button;
        }
    }
}
