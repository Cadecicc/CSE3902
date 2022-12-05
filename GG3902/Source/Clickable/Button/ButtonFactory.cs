using Microsoft.Xna.Framework;

namespace GG3902
{
    public static class ButtonFactory
    {
        public static Button SpawnButton(string buttonName, Game1 game,Camera camera)// put things here
        {
            int exitButtonPos = -234;
            Button button;
            switch(buttonName)
            {
                case "ExitButton":
                    button = new Button(buttonName, camera.WorldPosition + new Vector2(0, exitButtonPos)); 
                    break;
                case "PlayButton":
                    button = new Button(buttonName, camera.WorldPosition); 
                    break;
                case "ResumeButton":
                    button = new Button(buttonName, camera.WorldPosition); 
                    break;
                case "RestartButton":
                    button = new Button(buttonName, camera.WorldPosition); 
                    break;
                default:
                    button = null;
                    break;
            }
            return button;
        }
    }
}
