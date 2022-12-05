using Microsoft.Xna.Framework;

namespace GG3902
{
    public class KeepMovingDecorator : IMovement
    {
        private IMovement undecorated;
        private Player player;

        public Vector2 Direction => undecorated.Direction;
        public Vector2 Velocity { get => undecorated.Velocity; set => undecorated.Velocity = value; }
        public float MaxSpeed { get => undecorated.MaxSpeed; set => undecorated.MaxSpeed = value; }

        public KeepMovingDecorator(Player player)
        {
            undecorated = player.GetComponent<IMovement>();
            this.player = player;
        }

        public void Update(GameTime gameTime)
        {
            player.Push(player.GetDirection());
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
