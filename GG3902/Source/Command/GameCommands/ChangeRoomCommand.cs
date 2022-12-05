using Microsoft.Xna.Framework;

namespace GG3902
{
    public class ChangeRoomCommand : ICommand
    {
        private Game1 game;
        private Direction direction;
        private Camera camera;
        private Player player;

        public ChangeRoomCommand(Game1 game, Camera camera, Direction direction, Player player)
        {
            this.game = game;
            this.direction = direction;
            this.camera = camera;
            this.player = player;
        }

        public void Execute()
        {
            // TODO: Fix player not appearing in each room
            bool success = game.ChangeRooms(direction);
            if (success)
            {
                if (direction.Equals(Direction.Up) || direction.Equals(Direction.Down))
                    camera.MoveCamera(-direction.ToVector() * (camera.ViewportHeight - 232));
                else
                    camera.MoveCamera(direction.ToVector() * camera.ViewportWidth);

                player.SetPosition(camera.WorldPosition - new Vector2(0, 192));
            }
        }

        public void Undo() { }
    }
}