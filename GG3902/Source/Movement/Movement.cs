using Microsoft.Xna.Framework;

namespace GG3902
{
    public class Movement : IMovement
    {
        private IPositionable parent;
        private Vector2 velocity;

        public Vector2 Velocity
        {
            get => velocity;
            set
            {
                velocity = value;
                if (velocity.Length() > MaxSpeed)
                    velocity = Vector2.Normalize(velocity) * MaxSpeed;
            }
        }
        public float MaxSpeed { get; set; }
        public Vector2 Direction
        {
            get
            {
                Vector2 direction = Velocity;
                if (!direction.Equals(Vector2.Zero))
                    direction = Vector2.Normalize(direction);
                return direction;
            }
        }

        public Movement(IPositionable parent, float speed)
        {
            this.parent = parent;
            MaxSpeed = speed;
        }

        public void Update(GameTime gameTime)
        {
            parent.Position += Velocity * gameTime.DeltaTime();
        }

        public bool IsMoving()
        {
            return !Velocity.Equals(Vector2.Zero);
        }
    }
}
