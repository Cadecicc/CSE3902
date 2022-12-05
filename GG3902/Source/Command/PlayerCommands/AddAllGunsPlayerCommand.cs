namespace GG3902
{
    public class AddAllGunsPlayerCommand : PlayerCommand
    {
        public AddAllGunsPlayerCommand(Player player) : base(player) { }

        public override void Execute()
        {
            Receiver.Debug_AddItems();
        }

        public override void Undo() { }
    }
}
