namespace GG3902
{
    // IEntity is the interface describing moving, animated characters within the game world
    public interface IEntity : IPositionable
    {
        void Initialize();

        int Id { get; }
    }
}
