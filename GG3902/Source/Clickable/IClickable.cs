using Microsoft.Xna.Framework;

namespace GG3902
{
    public interface IClickable
    {
        public string Type { get; }

        // Given a mouse point, returns true if it's being clicked.
        bool IsClicked(Vector2 mousePosition);
    }
}