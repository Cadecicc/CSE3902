using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;

namespace GG3902
{
    public class AttackPlayerState : BusyPlayerState
    {
        private StopMovingDecorator decorated;
        private SoundEffect soundEffect;
        private Projectile sword;
        private Player player;

        public AttackPlayerState(Player Player) : base(Player)
        {
            player = Player;
            decorated = new StopMovingDecorator(Player.GetComponent<IMovement>());
            soundEffect = SoundEffectFactory.LoadSoundEffect("linkSwordAttack");
        }

        public override void Enter()
        {
            Player.SetDirectionalAnimation("PlayerUpItem", "PlayerDownItem", "PlayerLeftItem", "PlayerRightItem");
            Player.SetComponent(decorated as IMovement);
            sword = ProjectileFactory.SpawnProjectile(Player.Position, Player.GetDirection().ToVector(), "WoodenSword", false, player, 3);
            if (!SoundManager.isMuted)
                soundEffect.Play();
        }

        public override void Exit()
        {
            Player.SetComponent(decorated.GetUndecorated());
        }

        public override void Update(GameTime gameTime)
        {
            if (Player.HasAnimationEnded() && sword.HasExploded && IsBusy)
            {
                IsBusy = false;
                Player.SetState(new MovePlayerState(Player));
            }
        }
    }
}
