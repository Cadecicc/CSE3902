using System;
using Microsoft.Xna.Framework.Content;

namespace GG3902
{
    public class AddSongCommand : ICommand
    {
        private string songName;
        private string filepath;
        private ContentManager contentManager;

        public AddSongCommand(string name, string filepath, ContentManager contentManager)
        {
            songName = name;
            this.filepath = filepath;
            this.contentManager = contentManager;
        }

        public void Execute()
        {
            SoundManager.Instance.LoadSong(songName, filepath, contentManager);
        }

        public void Undo()
        {
            
        }
    }
}
