namespace GG3902
{
    public class ExitInventoryCommand : GenericCommand<IState>
    {
        private InventoryGameState igs;

        public ExitInventoryCommand(IState igs) : base(igs)
        {
            if (igs is InventoryGameState)
            {
                this.igs = igs as InventoryGameState;
            }
        }

        public override void Execute()
        {
            igs.Direction = Direction.Down;
        }

        public override void Undo() { }
    }
}