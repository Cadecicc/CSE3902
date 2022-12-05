using Microsoft.Xna.Framework;

namespace GG3902
{
    public abstract class BusyPlayerState : IState
    {
        private Player player;

        public bool IsBusy { get; protected set; }
        protected Player Player => player;

        public BusyPlayerState(Player player)
        {
            this.player = player;
            IsBusy = true;
        }

        public abstract void Enter();

        public abstract void Exit();

        public abstract void Update(GameTime gameTime);
    }
}
