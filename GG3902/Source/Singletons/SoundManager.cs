using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace GG3902
{
    public class SoundManager
    {
        private static SoundManager instance = new SoundManager();

        private Dictionary<string, SoundEffect> soundMap;
        private Dictionary<string, Song> songMap;
        private List<SoundEffectInstance> instances;

        public static bool isMuted { get; set; }

        public static SoundManager Instance => instance;

        public SoundManager()
        {
            soundMap = new Dictionary<string, SoundEffect>();
            songMap = new Dictionary<string, Song>();
            instances = new List<SoundEffectInstance>();
            isMuted = false;
        }

        public void Reset()
        {
            soundMap = new Dictionary<string, SoundEffect>();
            songMap = new Dictionary<string, Song>();
            instances = new List<SoundEffectInstance>();
        }

        public void LoadSound(string name, string filepath, ContentManager contentManager)
        {
            soundMap.Add(name, contentManager.Load<SoundEffect>(filepath));
        }

        public void LoadSong(string name, string filepath, ContentManager contentManager)
        {
            songMap.Add(name, contentManager.Load<Song>(filepath));
        }

        public SoundEffect GetSoundEffect(string name)
        {
            return soundMap[name];
        }

        public Song GetSong(string name)
        {
            return songMap[name];
        }

        public void RegisterSoundInstance(SoundEffectInstance soundEffect)
        {
            instances.Add(soundEffect);
        }

        public void StopAllSounds()
        {
            foreach (SoundEffectInstance soundEffect in instances)
            {
                soundEffect.Stop();
            }
        }
    }
}
