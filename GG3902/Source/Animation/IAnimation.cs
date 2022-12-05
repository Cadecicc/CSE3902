namespace GG3902
{
    // Subject to change
    public interface IAnimation : IDrawableComponent
    {
        bool HasLooped { get; }
        bool Playing { get; set; }
        void Reset();
    }
}
