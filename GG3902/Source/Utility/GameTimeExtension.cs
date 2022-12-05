using Microsoft.Xna.Framework;
using System;

namespace GG3902
{
    public static class GameTimeExtension
    {
        public static float DeltaTime(this GameTime gameTime)
        {
            return Convert.ToSingle(gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
