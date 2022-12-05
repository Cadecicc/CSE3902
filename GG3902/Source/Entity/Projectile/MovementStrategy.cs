using System;

namespace GG3902
{
    public abstract class MovementStrategy
    {
        public abstract void Move(IMovement movement, double deltaTime);
    }
}
