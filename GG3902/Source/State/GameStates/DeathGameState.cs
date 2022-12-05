using Microsoft.Xna.Framework;

namespace GG3902
{
    public class DeathGameState : IState
    {
        private Game1 game;
        private Camera camera;
        private Background background;
        private Button restartButton;
        private Button exitButton;

        public DeathGameState(Game1 game, Camera camera)
        {
            this.game = game;
            this.camera = camera;
        }

        public void Enter()
        {
            foreach (IController controller in game.Controllers)
                controller.ChangeMappings("winOrlose");

            EntityManager.Instance.Clear();
            background = new Background("LoseScreen",camera);
            restartButton = ButtonFactory.SpawnButton("RestartButton", game,camera);
            exitButton = ButtonFactory.SpawnButton("ExitButton", game, camera);
        }

        public void Exit()
        {
            background.DeleteSelf();
            restartButton.DeleteSelf();
            exitButton.DeleteSelf();
        }

        public void Update(GameTime gameTime)
        {
            foreach (IController controller in game.Controllers)
                controller.Update();

            EntityManager.Instance.Update(gameTime);
        }
    }
}
