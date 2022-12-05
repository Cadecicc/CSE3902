using System;
using Microsoft.Xna.Framework.Media;

namespace GG3902
{
    public static class SongFactory
    {
        public static void LoadSounds()
        {
            string name = "Dungeon";
            Song song = SoundManager.Instance.GetSong(name);
            SoundEffectFactory.RegisterSong(name, song);

            name = "linkReggae";
            song = SoundManager.Instance.GetSong(name);
            SoundEffectFactory.RegisterSong(name, song);

            name = "linkZombies1";
            song = SoundManager.Instance.GetSong(name);
            SoundEffectFactory.RegisterSong(name, song);

            name = "linkZombies2";
            song = SoundManager.Instance.GetSong(name);
            SoundEffectFactory.RegisterSong(name, song);

            name = "linkZombies3";
            song = SoundManager.Instance.GetSong(name);
            SoundEffectFactory.RegisterSong(name, song);

            name = "linkZombies4";
            song = SoundManager.Instance.GetSong(name);
            SoundEffectFactory.RegisterSong(name, song);

            name = "Damned";
            song = SoundManager.Instance.GetSong(name);
            SoundEffectFactory.RegisterSong(name, song);
        }
    }
}
