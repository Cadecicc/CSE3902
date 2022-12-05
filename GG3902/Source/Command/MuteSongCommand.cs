using Microsoft.Xna.Framework.Media;

namespace GG3902
{
    public class MuteSongCommand : ICommand
    {
        public MuteSongCommand() { }

        public void Execute()
        {
            MediaPlayer.IsMuted = true;
        }

        public void Undo(){ }
    }
}
