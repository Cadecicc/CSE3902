using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace GG3902
{
    public class TransitionRoomPlayerState : BusyPlayerState
    {
        private KeepMovingDecorator decorated;

        public TransitionRoomPlayerState(Player Player) : base(Player)
        {
            decorated = new KeepMovingDecorator(Player);
        }

        public override void Enter()
        {
            Player.SetComponent(decorated as IMovement);
        }

        public override void Exit()
        {
            Player.SetComponent(decorated.GetUndecorated());
        }

        public override void Update(GameTime gameTime)
        {
                IsBusy = false;
                Player.SetState(new MovePlayerState(Player));
        }
    }
}
