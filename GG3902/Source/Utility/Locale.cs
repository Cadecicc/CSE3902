using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace GG3902
{
    public class Locale
    {
        public Dictionary<Direction, int> neighbors;
        public Vector2 offset;

        public Locale(int right, int left, int up, int down, Vector2 offset)
        {
            neighbors = new Dictionary<Direction, int>();
            neighbors.Add(Direction.Right, right);
            neighbors.Add(Direction.Left, left);
            neighbors.Add(Direction.Up, up);
            neighbors.Add(Direction.Down, down);
            this.offset = offset;
        }

    }
}