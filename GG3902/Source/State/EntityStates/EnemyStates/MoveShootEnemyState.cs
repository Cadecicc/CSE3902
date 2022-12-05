using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace GG3902
{
    public class MoveShootEnemyState : IState
    {
        private Vector2 animationDirection;
        private Vector2 movementDirection;
        private double timer;
        private Random rand;
        private Enemy Enemy;
        private SoundEffect soundEffect;

        public MoveShootEnemyState(Enemy enemy)
        {
            animationDirection = Vector2.Zero;
            timer = 0;
            rand = new Random();
            Enemy = enemy;
            soundEffect = SoundEffectFactory.LoadSoundEffect("enemyScream");
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
            if (timer > 1000)
            {
                int direction = rand.Next() % 6;
                if (direction == 0)
                    movementDirection = Vector2.UnitX;
                if (direction == 1)
                    movementDirection = Vector2.UnitY;
                if (direction == 2)
                    movementDirection = -Vector2.UnitX;
                if (direction == 3)
                    movementDirection = -Vector2.UnitY;
                if (direction == 4)
                    if (movementDirection != Vector2.Zero)
                        ProjectileFactory.SpawnProjectile(Enemy.Position, movementDirection, "Fireball", true, Enemy);
                if (direction == 5 && !SoundManager.isMuted)
                    soundEffect.Play();
                timer = 0;
            }

            Vector2 currentDirection = movementDirection;
            if (!animationDirection.Equals(currentDirection))
            {
                animationDirection = currentDirection;
                SetAnimation();
            }

            //Enemy.Animator.ActiveAnimation.Playing = !Enemy.Speed.Equals(0f);
            
            Enemy.Position += movementDirection;
        }

        private void SetAnimation() {

            Direction direction = movementDirection.ToDirection();

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
    }
}
