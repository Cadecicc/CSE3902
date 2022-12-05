using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace GG3902
{
    // Given a direction, this state transitions the player from one room to another
    public class ChangeRoomGameState : IState
    {
        private Game1 game;
        private Direction direction;
        private Camera camera;
        private Vector2 newPosition;
        private Vector2 currentPosition;
        private Player player;
        private Vector2 playerInitialPosition;

        // Constructor
        public ChangeRoomGameState(Game1 game, Camera camera, Direction direction, Player player)
        {
            this.game = game;
            this.direction = direction;
            this.camera = camera;
            this.player = player;
        }

        public void Enter()
        {
            foreach (IController controller in game.Controllers)
                controller.ChangeMappings("null");
            // Swap rooms (based on current room known by room manager and given direction)
            bool success = game.ChangeRooms(direction);
            if (success)
            {
                // Calculate total distance between camera position and currently hardcoded magic numbers
                if (direction.Equals(Direction.Up) || direction.Equals(Direction.Down))
                    newPosition = camera.Position + -direction.ToVector() * (camera.ViewportHeight - 232);
                else
                    newPosition = camera.Position + direction.ToVector() * camera.ViewportWidth;

                // Set current camera position
                currentPosition = camera.Position;

                // Set player start position and direction for transition
                playerInitialPosition = player.Position;
                player.Stop();
                player.SetAnimation("Player" + direction.ToString() + "Moving");
            }
            else
                game.SetState(StateManager.Instance.GetState("PlayState"));
        }
        
        public void Exit() { }

        public void Update(GameTime gameTime)
        {
            EntityManager.Instance.Update(gameTime);
            //Check that camera has not closed the gap fully, resume game if it has
            if (!((newPosition - currentPosition) * direction.ToVector()).Equals(Vector2.Zero))
            {
                // Move the camera by a divisible amount via magic number and reset current position
                camera.MoveCamera(direction.ToVector() * new Vector2(1, -1) * 16f);
                currentPosition = camera.Position;

                if (!player.IsMoving())
                    player.Push(direction);
            }
            else if ((player.Position - playerInitialPosition).Length() > 192)
            {
                game.SetState(StateManager.Instance.GetState("PlayState"));
            }
        }
    }
}
