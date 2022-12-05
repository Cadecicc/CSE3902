using Microsoft.Xna.Framework;

namespace GG3902
{
    public class PushBackMovementDecorator : IMovement
    {
        private IMovement undecorated;
        private IPositionable parent;
        private Vector2 direction;

        public Vector2 Direction => direction;
        public Vector2 Velocity { get => undecorated.Velocity; set => undecorated.Velocity = value; }
        public float MaxSpeed { get => undecorated.MaxSpeed * 2.5f; set => undecorated.MaxSpeed = value; }

        public PushBackMovementDecorator(IMovement undecorated, IPositionable parent,Direction direction)
        {
            this.undecorated = undecorated;
            this.parent = parent;
            this.direction = -direction.ToVector();
        }

        public void Update(GameTime gameTime)
        {
            parent.Position += -Direction * MaxSpeed * gameTime.DeltaTime();
        }

        public bool IsMoving()
        {
            return undecorated.IsMoving();
        }

        public IMovement GetUndecorated()
        {
            return undecorated;
        }
    }
}
