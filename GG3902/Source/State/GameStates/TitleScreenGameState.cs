using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace GG3902
{
    public class TitleScreenGameState : IState
    {
        private Game1 game;
        private Camera camera;
        private Background background;
        private Button playButton;
        private Button exitButton;
        private ToggleButton muteSongButton;
        private ToggleButton muteSoundButton;
        private Song song;
        private int spriteHeight = 50;
        private int spriteWidth = 50;

        public TitleScreenGameState(Game1 game, Camera camera)
        {
            this.game = game;
            this.camera = camera;
        }

        public void Enter()
        {
            foreach (IController controller in game.Controllers)
                controller.ChangeMappings("title");

            background = new Background("TitleScreen", camera);
            playButton = ButtonFactory.SpawnButton("PlayButton", game,camera);
            exitButton = ButtonFactory.SpawnButton("ExitButton", game, camera);
            muteSongButton = ToggleButtonFactory.SpawnToggleButton("ToggleMuteSongButton", spriteWidth, spriteHeight,camera);
            muteSoundButton = ToggleButtonFactory.SpawnToggleButton("ToggleMuteSoundButton", spriteWidth, spriteHeight, camera);
            song = SoundEffectFactory.LoadSong("Damned");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.2f;
            MediaPlayer.Play(song);
        }

        public void Exit()
        {
            // Stop the music
            MediaPlayer.Stop();

            // Delete the buttons
            background.DeleteSelf();
            playButton.DeleteSelf();
            exitButton.DeleteSelf();
            muteSongButton.DeleteSelf();
            muteSoundButton.DeleteSelf();

            // Load the first room
            RoomManager.Instance.LoadRoom();
            EntityManager.Instance.Initialize();
        }

        public void Update(GameTime gameTime)
        {
            foreach (IController controller in game.Controllers)
            {
                    controller.Update();
            }

            EntityManager.Instance.Update(gameTime);
        }
    }
}
