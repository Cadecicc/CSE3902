using System;
using Microsoft.Xna.Framework.Content;

namespace GG3902
{
    public class AddSoundCommand : ICommand
    {
        private string soundName;
        private string filepath;
        private ContentManager contentManager;

        public AddSoundCommand(string name, string filepath, ContentManager contentManager)
        {
            soundName = name;
            this.filepath = filepath;
            this.contentManager = contentManager;
        }

        public void Execute()
        {
            SoundManager.Instance.LoadSound(soundName, filepath, contentManager);
        }

        public void Undo()
        {
            
        }
    }
}
