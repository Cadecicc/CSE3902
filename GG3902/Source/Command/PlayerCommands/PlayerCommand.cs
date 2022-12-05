namespace GG3902
{
    public abstract class PlayerCommand : GenericCommand<Player>
    {
        public PlayerCommand(Player player) : base(player) { }
    }
}
