using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace GG3902
{
    class ZombieLandGameState : IState
    {
        private Game1 game;
        private Camera camera;
        private Player player;
        private Round round;
        private Dictionary<int, Dictionary<string, int>> roundEntities;
        private Dictionary<string, int> scores;
        private int totalScore;
        private bool roundsFinished;

        private Song song;
        private List<Song> playlist;
        private int currentSong;
        private SoundEffect soundEffect;

        public int RoundNum => round?.roundNumber ?? 0;
        public int Score => totalScore;
        public int NumOfKills => round?.NumOfKills ?? 0;

        public ZombieLandGameState(Game1 game, Camera camera,Player player)
        {
            this.game = game;
            this.camera = camera;
            this.player = player;
            roundEntities = new Dictionary<int, Dictionary<string, int>>();
            totalScore = 0;
            roundsFinished = false;

            // This block of code adds the enemy counts and score multipliers from xml into organized dictionaries
            XmlParser parser = new XmlParser(new Type[] { typeof(DictionaryExtension) });
            string filepath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/Source/Level/Rounds.xml";
            List<object> lists = parser.CreateObjectsFromXml(filepath);
            for (int i = 0; i < lists.Count - 1; i++)
                roundEntities.Add(i + 1, (lists[i] as DictionaryExtension).dictionary);
            scores = (lists[lists.Count - 1] as DictionaryExtension).dictionary;

        }
        public void Enter() 
        {
            MediaPlayer.Stop();
            foreach (IController controller in game.Controllers)
                controller.ChangeMappings("zombies");

            //Create and start playing the playlist
            MediaPlayer.IsRepeating = false;
            MediaPlayer.Volume = 0.3f;
            playlist = new List<Song>();
            currentSong = 0;
            CreatePlaylist();
        }

        public void Exit(){}
        public void Update(GameTime gameTime)
        {
            //Debug.WriteLine(player.Position);
            camera.CenterOn(player.Position * new Vector2(1,-1) + new Vector2(0,-100));

            foreach (IController controller in game.Controllers)
                controller.Update();


            // Constructs the first round
            if (round == null)
            {
                round = new Round(1, roundEntities[1], scores, player);
                soundEffect = SoundEffectFactory.LoadSoundEffect("round" + round.roundNumber.ToString());
                if (!SoundManager.isMuted)
                    soundEffect.Play();
            }
            else if (!round.over)
            {
                // Updates the round until the round signals that it is over, then the next round is started if one exists
                totalScore = round.Update(gameTime);
            }
            else if (round.roundNumber + 1 <= roundEntities.Count)
            {
                totalScore += round.Update(gameTime);
                round = new Round(round.roundNumber + 1, roundEntities[round.roundNumber + 1], scores, player);
                soundEffect = SoundEffectFactory.LoadSoundEffect("round" + round.roundNumber.ToString());
                if (!SoundManager.isMuted)
                    soundEffect.Play();
            }
            else if (!roundsFinished)
            {
                totalScore += round.Update(gameTime);
                roundsFinished = true;
            }

            EntityManager.Instance.Update(gameTime);

            List<List<Enemy>> enemyLists = EntityManager.Instance.Enemies.Chop(2);
            CollisionHandler.DetectCollisions(game, camera, EntityManager.Instance.Collideables, EntityManager.Instance.Collideables);
            if (enemyLists.Count > 1)
                CollisionHandler.DetectCollisions(game, camera, enemyLists[0], enemyLists[1]);

            foreach (Player player in EntityManager.Instance.Players)
                if (player.HasDied)
                    game.SetState(StateManager.Instance.GetState("Death"));

            if (MediaPlayer.State == MediaState.Stopped)
            {
                Shuffle();
            }
        }

        private void CreatePlaylist()
        {
            song = SoundEffectFactory.LoadSong("linkZombies1");
            playlist.Add(song);
            song = SoundEffectFactory.LoadSong("linkZombies2");
            playlist.Add(song);
            song = SoundEffectFactory.LoadSong("linkZombies3");
            playlist.Add(song);
            song = SoundEffectFactory.LoadSong("linkZombies4");
            playlist.Add(song);
        }

        private void Shuffle()
        {
            Random rand = new Random();
            int num = rand.Next() % 4;
            while (currentSong == num)
            {
                num = rand.Next() % 4;
            }
            MediaPlayer.Play(playlist[num]);
            currentSong = num;
        }
    }
}
