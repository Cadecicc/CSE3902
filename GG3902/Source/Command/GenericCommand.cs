namespace GG3902
{
    public abstract class GenericCommand<T> : ICommand
    {
        private T receiver;

        protected T Receiver => receiver;

        public GenericCommand(T receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
        public abstract void Undo();
    }
}
