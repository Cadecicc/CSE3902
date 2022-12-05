using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Diagnostics;

namespace GG3902
{
    public class DamagedPlayerState : BusyPlayerState
    {
        private PushBackMovementDecorator decorated;
        private float remainingStateDuration;
        private SoundEffect soundEffect;

        public DamagedPlayerState(Player player,Direction direction) : base(player)
        {
            decorated = new PushBackMovementDecorator(Player.GetComponent<IMovement>(), player,direction);
            remainingStateDuration = 0.25f;
            soundEffect = SoundEffectFactory.LoadSoundEffect("linkTakeDamage");
        }

        public override void Enter()
        {
            Player.SetDirectionalAnimation("PlayerUpMoving", "PlayerDownMoving", "PlayerLeftMoving", "PlayerRightMoving");
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
            remainingStateDuration -= gameTime.DeltaTime();
            if (remainingStateDuration < 0 && IsBusy)
            {
                IsBusy = false;
                Player.SetState(new MovePlayerState(Player));
            }
        }
    }
}
