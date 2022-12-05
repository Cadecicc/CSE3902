using Microsoft.Xna.Framework;

namespace GG3902
{
    public interface IMovement : IComponent
    {
        Vector2 Direction { get; }
        Vector2 Velocity { get; set; }
        float MaxSpeed { get; set; }

        bool IsMoving();
    }
}
