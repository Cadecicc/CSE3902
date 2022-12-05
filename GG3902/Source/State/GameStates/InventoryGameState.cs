using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace GG3902
{
    public class InventoryGameState : IState
    {
        private Game1 game;
        private Camera camera;
        private Player player;

        private Vector2 newPosition;
        private Vector2 currentPosition;
        private Vector2 originalPosition;

        public Direction Direction { get; set; } 

        public InventoryGameState(Game1 game, Camera camera, Player player)
        {
            this.game = game;
            this.camera = camera;
            this.player = player;
        }

        public void Enter()
        {
            Direction = Direction.Up;
            originalPosition = camera.Position;
            player.Stop();
           

            foreach (IController controller in game.Controllers)
                controller.ChangeMappings("inventory");

            // Swap rooms (based on current room known by room manager and given Direction)
            if (true)
            {
                // Calculate total distance between camera position and currently hardcoded magic numbers
                if (Direction.Equals(Direction.Up) || Direction.Equals(Direction.Down))
                    newPosition = camera.Position + -Direction.ToVector() * (camera.ViewportHeight - 232);
                else
                    newPosition = camera.Position + Direction.ToVector() * camera.ViewportWidth;

                // Set current camera position
                currentPosition = camera.Position;
            }
        }

        public void Exit(){ }

        public void Update(GameTime gameTime)
        {
            currentPosition = camera.Position;
            //Check that camera has not closed the gap fully, resume game if it has
            if (Direction == Direction.Up && !((newPosition - currentPosition) * Direction.ToVector()).Equals(Vector2.Zero))
            {
                // Move the camera by a divisible amount via magic number and reset current position
                camera.MoveCamera(Direction.ToVector() * new Vector2(1, -1) * 16f);
            }
            else if (Direction == Direction.Down)
            {
                if (!currentPosition.Equals(originalPosition))
                {
                    // Move the camera by a divisible amount via magic number and reset current position
                    camera.MoveCamera(Direction.ToVector() * new Vector2(1, -1) * 16f);
                }
                else
                    game.ReverseState();
            }
            else
            {
                foreach (IController controller in game.Controllers)
                    controller.Update();
            }
        }
    }
}
