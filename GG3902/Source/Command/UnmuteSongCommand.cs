using Microsoft.Xna.Framework.Media;
namespace GG3902
{
    public class UnmuteSongCommand : ICommand
    {
        public UnmuteSongCommand() { }

        public void Execute()
        {
            MediaPlayer.IsMuted = false;
        }

        public void Undo() { }
    }
}
