using Microsoft.Xna.Framework;
using System;

namespace GG3902
{
    public static class VectorExtension
    {
        private static float degreeToRadianConversion = (MathF.PI * 2) / 360;

        public static Vector2 Rotate(this Vector2 vector, float degrees)
        {
            float sin = MathF.Sin(degrees * degreeToRadianConversion);
            float cos = MathF.Cos(degrees * degreeToRadianConversion);
            float oldX = vector.X;
            float oldY = vector.Y;

            vector.X = (cos * oldX) - (sin * oldY);
            vector.Y = (sin * oldX) + (cos * oldY);

            return vector;
        }
    }
}
