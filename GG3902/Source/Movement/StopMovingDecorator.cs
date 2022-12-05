using Microsoft.Xna.Framework;

namespace GG3902
{
    public class StopMovingDecorator : IMovement
    {
        private IMovement undecorated;

        public Vector2 Direction => undecorated.Direction;
        public Vector2 Velocity { get => undecorated.Velocity; set => undecorated.Velocity = value; }
        public float MaxSpeed { get => undecorated.MaxSpeed; set => undecorated.MaxSpeed = value; }

        public StopMovingDecorator(IMovement undecorated)
        {
            this.undecorated = undecorated;
        }

        public void Update(GameTime gameTime) { } // Do nothing

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
