using Microsoft.Xna.Framework;
using System;

namespace GG3902
{
    public class ProjectileMovement : IMovement
    {
        private Projectile projectile;
        private MovementStrategy movementStrategy;

        public Vector2 Direction { get; set; }
        public Vector2 Velocity { get => MaxSpeed * Direction; set => _ = value; }
        public float MaxSpeed { get; set; }

        public ProjectileMovement(Projectile projectile, Vector2 direction, MovementStrategy movementStrategy)
        {
            this.projectile = projectile;
            this.movementStrategy = movementStrategy;
            Direction = direction;
        }

        public bool IsMoving()
        {
            return MaxSpeed.IsZero();
        }

        public void Update(GameTime gameTime)
        {
            projectile.Position += Velocity * gameTime.DeltaTime();
            movementStrategy.Move(this, gameTime.DeltaTime());
        }
    }
}
