using System.Diagnostics;

namespace GG3902
{
    public class StateMachine
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

        public StateMachine()
        {
            currentState = StateManager.Instance.GetState("Null");
        }
    }
}
