namespace GG3902
{
    public class ArrowMovementStrategy : MovementStrategy
    {
        private float maxSpeed;

        public ArrowMovementStrategy(float maxSpeed)
        {
            this.maxSpeed = maxSpeed;
        }

        public override void Move(IMovement movement, double deltaTime)
        {
            movement.MaxSpeed = maxSpeed;
        }
    }
}
