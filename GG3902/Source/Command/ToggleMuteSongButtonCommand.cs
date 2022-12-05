using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GG3902
{
    public class ToggleMuteSongButtonCommand : ICommand
    {
        public void Execute()
        {
            ToggleButton toggleMute = null;
            foreach (IClickable clickable in EntityManager.Instance.Clickables)
            {
                if (clickable is ToggleButton && clickable.Type.Equals("ToggleMuteSongButton"))
                {
                    toggleMute = (clickable as ToggleButton);
                }
            }
            if (toggleMute != null)
            {
                MediaPlayer.IsMuted = !MediaPlayer.IsMuted;
                toggleMute.CheckButtonType();
            } 
        }

        public void Undo() { }
    }
}
