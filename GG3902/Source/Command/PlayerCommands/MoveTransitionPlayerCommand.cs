namespace GG3902
{
    public class MoveTransitionPlayerCommand : PlayerCommand
    {
        private Direction direction;

        public MoveTransitionPlayerCommand(Player player, Direction direction) : base(player)
        {
            this.direction = direction;
        }

        public override void Execute()
        {
            Receiver.Push(direction);
        }

        public override void Undo()
        {
            Receiver.Pull(direction);
        }
    }
}
