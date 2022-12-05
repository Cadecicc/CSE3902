using System.Diagnostics;

namespace GG3902
{
    public class GameStateMachine
    {
        private IState currentState;
        private IState lastPlayState;

        public IState CurrentState
        {
            get => currentState;
            set
            {
                currentState.Exit();
                if(currentState is PlayGameState||currentState is ZombieLandGameState)
                    lastPlayState = currentState;
                currentState = value;
                currentState.Enter();
            }
        }
        public IState LastPlayState()
        {
            currentState.Exit();
            currentState = lastPlayState;
            currentState.Enter();
            return lastPlayState;
        }

        public GameStateMachine()
        {
            currentState = new NullState();
        }
    }
}
