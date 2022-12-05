using Microsoft.Xna.Framework;

namespace GG3902
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public static class DirectionExtension
    {
        public static Vector2 ToVector(this Direction direction)
        {
            Vector2 dirVector;

            switch(direction)
            {
                case Direction.Up:
                    dirVector = Vector2.UnitY;
                    break;
                case Direction.Down:
                    dirVector = -Vector2.UnitY;
                    break;
                case Direction.Left:
                    dirVector = -Vector2.UnitX;
                    break;
                case Direction.Right:
                    dirVector = Vector2.UnitX;
                    break;
                default:
                    dirVector = Vector2.Zero;
                    break;
            }

            return dirVector;
        }

        public static Direction ToDirection(this Vector2 vector)
        {
            Direction direction;

            if (vector.Equals(Vector2.UnitY))
                direction = Direction.Up;
            else if (vector.Equals(-Vector2.UnitY))
                direction = Direction.Down;
            else if (vector.Equals(-Vector2.UnitX))
                direction = Direction.Left;
            else
                direction = Direction.Right;

            return direction;
        }

        public static string ToString(this Direction direction)
        {
            string str;

            if (direction == Direction.Up)
                str = "Up";
            else if (direction == Direction.Down)
                str = "Down";
            else if (direction == Direction.Left)
                str = "Left";
            else
                str = "right";

            return str;
        }

        public static Direction Opposite(this Direction direction)
        {
            Direction dir;

            if (direction == Direction.Down)
                dir = Direction.Up;
            else if (direction == Direction.Up)
                dir = Direction.Down;
            else if (direction == Direction.Right)
                dir = Direction.Left;
            else
                dir = Direction.Right;

            return dir;
        }
    }
}
