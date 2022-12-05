using Microsoft.Xna.Framework;

namespace GG3902
{
    public class ItemPlayerState : BusyPlayerState
    {
        private StopMovingDecorator decorated;
        private string item;
        private Player player;

        public ItemPlayerState(Player Player, string item) : base (Player)
        {
            player = Player;
            this.item = item;
            decorated = new StopMovingDecorator(Player.GetComponent<IMovement>());
        }

        public override void Enter()
        {
            Player.SetDirectionalAnimation("PlayerUpItem", "PlayerDownItem", "PlayerLeftItem", "PlayerRightItem");
            Player.SetComponent(decorated as IMovement);
            ProjectileFactory.SpawnProjectile(Player.Position, Player.GetDirection().ToVector(), item, false, player);
        }

        public override void Exit()
        {
            Player.SetComponent(decorated.GetUndecorated());
        }

        public override void Update(GameTime gameTime)
        {
            if (Player.HasAnimationEnded() && IsBusy)
            {
                IsBusy = false;
                Player.SetState(new MovePlayerState(Player));
            }
        }
    }
}
