using Microsoft.Xna.Framework;

namespace GG3902
{
    public class MovePlayerState : IState
    {
        private Player player;
        private Direction animDirection;

        public MovePlayerState(Player player)
        {
            this.player = player;
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
            Direction currentDirection = player.GetDirection();
            if (currentDirection != animDirection)
            {
                SetAnimation();
            }

            if (player.IsMoving())
                player.PlayAnimation();
            else
                player.StopAnimation();
        }

        private void SetAnimation()
        {
            player.SetDirectionalAnimation("PlayerUpMoving", "PlayerDownMoving", "PlayerLeftMoving", "PlayerRightMoving");
            animDirection = player.GetDirection();
        }
    }
}
