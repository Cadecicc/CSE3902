using System;

namespace GG3902
{
    public class BoomerangMovementStrategy : MovementStrategy
    {
        private double lifeSpan;
        private double timeSpent;

        private float maxSpeed;

        public BoomerangMovementStrategy(float maxSpeed)
        {
            this.maxSpeed = maxSpeed;
        }
            
        public BoomerangMovementStrategy(float maxSpeed, double lifeSpan)
        {
            this.maxSpeed = maxSpeed;
            this.lifeSpan = lifeSpan;
            timeSpent = 0;
        }

        public override void Move(IMovement movement, double deltaTime)
        {
            timeSpent += deltaTime;
            movement.MaxSpeed = maxSpeed * (float)Math.Cos(timeSpent);
            movement.MaxSpeed = maxSpeed * (float)Math.Cos(Math.PI / lifeSpan * timeSpent);
        }
    }
}
