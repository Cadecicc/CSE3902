using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace GG3902
{
    public class PlayGameState : IState
    {
        private Game1 game;
        private Camera camera;
        private Song song;

        public PlayGameState(Game1 game,Camera camera)
        {
            this.game = game;
            this.camera = camera;
        }

        public void Enter()
        {
            foreach (IController controller in game.Controllers)
                controller.ChangeMappings("player");

            song = SoundEffectFactory.LoadSong("Dungeon");
            MediaPlayer.IsRepeating = true;
            if (MediaPlayer.State != MediaState.Playing)
            {
                MediaPlayer.Play(song);
            }
        }

        public void Exit()
        {
            if (game.GetState() != this)
                MediaPlayer.Stop();
        }

        public void Update(GameTime gameTime)
        {
            foreach (IController controller in game.Controllers)
                controller.Update();

            EntityManager.Instance.Update(gameTime);

            CollisionHandler.DetectCollisions(game, camera, EntityManager.Instance.Collideables, EntityManager.Instance.Collideables);

            foreach (Player player in EntityManager.Instance.Players)
                if (player.HasDied)
                    game.SetState(StateManager.Instance.GetState("Death"));
        }
    }
}
