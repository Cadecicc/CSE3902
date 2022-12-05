namespace GG3902
{
    public class SwitchItemPlayerCommand : PlayerCommand
    {
        public SwitchItemPlayerCommand(Player player) : base(player) { }

        public override void Execute()
        {
            Receiver.SwitchActiveItem();
        }

        public override void Undo() { }
    }
}
