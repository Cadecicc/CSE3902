using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace GG3902
{
    public class Door : Entity, ICollideable, ITransitionable
    {
        private string type;
        private ISprite Sprite
        {
            get => GetComponent<ISprite>();
            set => SetComponent(value);
        }
        private Direction Side;

        public Door(string type, Vector2 startingPosition, Direction side)
        {
            this.type = type;
            Position = startingPosition * 16 * DoorSpriteFactory.Scale;
            Side = side;
        }

        public ICollider Collider { get; set; }

        public override void Initialize()
        {
            if (Side.Equals(Direction.Up) || Side.Equals(Direction.Down))
                Collider = new Collider(this, new Point(180, 60));
            else
                Collider = new Collider(this, new Point(60, 180));
            Sprite = DoorSpriteFactory.LoadSprite(type + Side.ToString());
        }

        public void TransitionRooms(Game1 game, Camera camera, Player player)
        {
            game.SetState(new ChangeRoomGameState(game, camera, Side, player));
        }
    }
}
