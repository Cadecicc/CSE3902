using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;

namespace GG3902
{
    public class DeadPlayerState : BusyPlayerState
    {
        private StopMovingDecorator decorated;
        private bool hasSetAnimation;
        private SoundEffect soundEffect;

        public event Action OnAnimationEnd;

        public DeadPlayerState(Player player) : base(player)
        {
            decorated = new StopMovingDecorator(Player.GetComponent<IMovement>());
            hasSetAnimation = false;
            soundEffect = SoundEffectFactory.LoadSoundEffect("linkDying");
        }

        public override void Enter()
        {
            Player.SetAnimation("PlayerDeath");
            Player.SetComponent(decorated as IMovement);
            if (!SoundManager.isMuted)
                soundEffect.Play();
        }

        public override void Exit()
        {
            Player.SetComponent(decorated.GetUndecorated());
        }

        public override void Update(GameTime gameTime)
        {
            if (Player.HasAnimationEnded() && !hasSetAnimation)
            {
                Player.SetAnimation("");
                OnAnimationEnd?.Invoke();
                hasSetAnimation = true;
            }
        }
    }
}
