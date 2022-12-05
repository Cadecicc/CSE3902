using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GG3902
{
    public interface ICommand
    {
        public void Execute();

        public void Undo(); //not sure what this will be yet
    }
}
