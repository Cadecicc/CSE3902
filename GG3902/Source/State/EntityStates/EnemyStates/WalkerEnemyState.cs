using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace GG3902
{
    public class WalkerEnemyState : IState
    {
        private Vector2 animationDirection;
        private Vector2 movementDirection;
        private double timer;
        private Random rand;
        private Enemy Enemy;
        private SoundEffect soundEffect;

        public WalkerEnemyState(Enemy enemy)
        {
            animationDirection = Vector2.Zero;
            timer = 0;
            rand = new Random();
            Enemy = enemy;
            //soundEffect
        }

        public void Enter()
        {
            SetAnimation();
        }

        public void Exit()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.TotalMilliseconds;

            Vector2 distanceToLink = EntityManager.Instance.DirectionToLink() - Enemy.Position;
            distanceToLink.Normalize();
            movementDirection = distanceToLink;

            Vector2 currentDirection = movementDirection;
            if (!animationDirection.ToDirection().Equals(ClosestDirection(currentDirection)))
            {
                animationDirection = ClosestDirection(currentDirection).ToVector();
                SetAnimation();
            }

            if (timer > 20)
            {
                Enemy.Position += movementDirection * 2;
                timer = 0;
            }
        }

        private void SetAnimation()
        {

            Direction direction = ClosestDirection(movementDirection);

            switch (direction)
            {
                case Direction.Up:
                    Enemy.SetAnimation("UpMoving");
                    break;
                case Direction.Down:
                    Enemy.SetAnimation("DownMoving");
                    break;
                case Direction.Left:
                    Enemy.SetAnimation("LeftMoving");
                    break;
                case Direction.Right:
                    Enemy.SetAnimation("RightMoving");
                    break;
                default:
                    break;
            }
        }

        private Direction ClosestDirection(Vector2 givenDirection)
        {
            Direction direction = Direction.Down;

            if (givenDirection.Y > 0 && (givenDirection.X < 0.5 && givenDirection.X > -0.5))
            {
                direction = Direction.Up;
            } else if (givenDirection.Y < 0 && (givenDirection.X < 0.5 && givenDirection.X > -0.5))
            {
                direction = Direction.Down;
            } else if (givenDirection.X < 0)
            {
                direction = Direction.Left;
            } else if (givenDirection.X > 0)
            {
                direction = Direction.Right;
            }

            return direction;
        }
    }
}
