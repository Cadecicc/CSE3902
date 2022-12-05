using System;
using System.Collections.Generic;
using System.Text;

namespace GG3902
{
    public class ToggleMuteSoundButtonCommand : ICommand
    {
        public void Execute()
        {
            //Need to implement a way to mute the sound
            ToggleButton toggleMute = null;

            // Find the ToggleButton
            foreach (IClickable clickable in EntityManager.Instance.Clickables)
            {
                if (clickable is ToggleButton && clickable.Type.Equals("ToggleMuteSoundButton"))
                {
                    toggleMute = (clickable as ToggleButton);
                }
            }

            // Mute the sounds and Check type and give it the right sprite to draw
            if (toggleMute != null)
            {
                SoundManager.isMuted = !SoundManager.isMuted;
                toggleMute.CheckButtonType();
            }
        }

        public void Undo() { }
    }
}
