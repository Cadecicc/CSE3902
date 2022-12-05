using System;
using Microsoft.Xna.Framework.Audio;

namespace GG3902
{
    public static class RoundSoundFactory
    {
        public static void LoadSounds()
        {
            string name = "round1";

            SoundEffect soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "round2";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "round3";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "round4";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "round5";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "round6";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "round7";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "round8";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "round9";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "round10";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);
        }
    }
}
