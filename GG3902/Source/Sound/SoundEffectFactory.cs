using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace GG3902
{
    public static class SoundEffectFactory
    {
        private static Dictionary<string, SoundEffect> sounds;
        private static Dictionary<string, Song> songs;

        static SoundEffectFactory()
        {
            sounds = new Dictionary<string, SoundEffect>();
            songs = new Dictionary<string, Song>();
            PlayerSoundFactory.LoadSounds();
            EnemySoundFactory.LoadSounds();
            RoundSoundFactory.LoadSounds();
            SongFactory.LoadSounds();
        }

        public static SoundEffect LoadSoundEffect(string name)
        {
            return sounds[name];
        }

        public static Song LoadSong(string name)
        {
            return songs[name];
        }

        public static void RegisterSoundEffect(string name, SoundEffect soundEffect)
        {
            sounds.Add(name, soundEffect);
        }

        public static void RegisterSong(string name, Song song)
        {
            songs.Add(name, song);
        }
    }
}
