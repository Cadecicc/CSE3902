using Microsoft.Xna.Framework;

namespace GG3902
{
    public class MenuGameState : IState
    {
        private Game1 game;
        private Camera camera;
        private Button resumeButton;
        private Button exitButton;
        private ToggleButton muteSongButton;
        private ToggleButton muteSoundButton;
        private int spriteHeight = 50;
        private int spriteWidth = 50;

        public MenuGameState(Game1 game,Camera camera)
        {
            this.game = game;
            this.camera = camera;
        }

        public void Enter()
        {
            foreach (IController controller in game.Controllers)
                controller.ChangeMappings("paused");

            resumeButton = ButtonFactory.SpawnButton("ResumeButton", game,camera);
            exitButton = ButtonFactory.SpawnButton("ExitButton", game, camera);
            muteSongButton = ToggleButtonFactory.SpawnToggleButton("ToggleMuteSongButton", spriteWidth, spriteHeight, camera);
            muteSoundButton = ToggleButtonFactory.SpawnToggleButton("ToggleMuteSoundButton", spriteWidth, spriteHeight, camera);
        }

        public void Exit()
        {
            resumeButton.DeleteSelf();
            exitButton.DeleteSelf();
            muteSongButton.DeleteSelf();
            muteSoundButton.DeleteSelf();
        }

        public void Update(GameTime gameTime)
        {
            foreach (IController controller in game.Controllers)
            {
                    controller.Update();
            }
        }
    }
}
