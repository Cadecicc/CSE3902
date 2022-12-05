using System;
using System.Collections.Generic;
using System.Text;

namespace GG3902
{
    public class ToggleMuteSoundsCommand : ICommand
    {
        public void Execute()
        {
            SoundManager.isMuted = !SoundManager.isMuted;
        }

        public void Undo(){}
    }
}
