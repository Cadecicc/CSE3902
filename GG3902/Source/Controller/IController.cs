using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GG3902
{
    public interface IController
    {
        public void ChangeMappings(string key);
        public void Update();
    }
}
