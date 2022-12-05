using System;
using Microsoft.Xna.Framework.Audio;

namespace GG3902
{
    public static class EnemySoundFactory
    {
        public static void LoadSounds()
        {
            string name = "enemyDying";

            SoundEffect soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "enemyScream";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "enemyGrowl";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);
        }
    }
}
