using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace GG3902
{
    public class WinGameState : IState
    {
        private Game1 game;
        private Camera camera;
        private Background background;
        private Button restartButton;
        private Button exitButton;
        private SoundEffect soundEffect;

        public WinGameState(Game1 game,Camera camera)
        {
            this.game = game;
            this.camera = camera;
        }

        public void Enter()
        {
            foreach (IController controller in game.Controllers)
                controller.ChangeMappings("winOrlose");

            EntityManager.Instance.Clear();
            background = new Background("WinScreen", camera);
            restartButton = ButtonFactory.SpawnButton("RestartButton", game, camera);
            exitButton = ButtonFactory.SpawnButton("ExitButton", game, camera);
            soundEffect = SoundEffectFactory.LoadSoundEffect("linkWinScreen");
            if (!SoundManager.isMuted)
                soundEffect.Play();
        }

        public void Exit()
        {
            background.DeleteSelf();
            exitButton.DeleteSelf();
            restartButton.DeleteSelf();
        }

        public void Update(GameTime gameTime)
        {
            foreach (IController controller in game.Controllers)
            {
                    controller.Update();
            }
            EntityManager.Instance.Update(gameTime);
        }
    }
}
