using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace GG3902
{
    public class ToggleMuteSongsCommand : ICommand
    {
        public void Execute()
        {
            MediaPlayer.IsMuted = !MediaPlayer.IsMuted;
        }

        public void Undo() { }
    }
}
