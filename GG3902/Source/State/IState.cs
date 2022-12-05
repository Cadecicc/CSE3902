namespace GG3902
{
    public interface IState : IComponent
    {
        public void Enter();
        public void Exit();
    }
}
