using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GG3902
{
    public class RocketMovementStrategy : MovementStrategy
    {
        private double lifeSpan;
        private double timeSpent;

        private float maxSpeed;
        private float targetDistance;
        private float currentDistance;
        private Vector2 initialPosition;

        public RocketMovementStrategy(float maxSpeed, double lifeSpan, Vector2 initialPosition)
        {
            this.maxSpeed = maxSpeed;
            this.lifeSpan = lifeSpan;
            this.initialPosition = initialPosition;
            targetDistance = Vector2.Distance(initialPosition, MouseController.MousePositionInWorld());
            timeSpent = 0;
        }

        public override void Move(IMovement movement, double deltaTime)
        {
            timeSpent += deltaTime;
            if (movement.MaxSpeed >= 0)
                movement.MaxSpeed = maxSpeed * (float)Math.Cos(Math.PI / lifeSpan * timeSpent);



        }
    }
}
