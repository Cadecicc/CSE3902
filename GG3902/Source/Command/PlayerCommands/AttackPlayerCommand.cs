namespace GG3902
{
    public class AttackPlayerCommand : PlayerCommand
    {
        public AttackPlayerCommand(Player player) : base(player) { }

        public override void Execute()
        {
            Receiver.Attack();
        }

        public override void Undo() { }
    }
}
