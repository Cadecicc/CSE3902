namespace GG3902
{
    public class UseItemPlayerCommand : PlayerCommand
    {
        public UseItemPlayerCommand(Player player) : base(player) { }

        public override void Execute()
        {
            Receiver.UseGunYeehaw();
        }

        public override void Undo()
        {
            Receiver.HolsterGun();
        }
    }
}
