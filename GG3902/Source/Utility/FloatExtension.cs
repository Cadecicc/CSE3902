using System;

namespace GG3902
{
    public static class FloatExtension
    {
        private static float epsilon = 0.0001f;

        public static bool IsZero(this float num)
        {
            return MathF.Abs(num) < epsilon;
        }
    }
}
