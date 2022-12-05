using System;
using Microsoft.Xna.Framework.Audio;

namespace GG3902
{
    public static class PlayerSoundFactory
    {
        public static void LoadSounds()
        {
            string name = "linkSwordAttack";

            SoundEffect soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "linkArrowAttack";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "linkBombDrop";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "linkBombExplode";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "linkTakeDamage";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "linkPickupItem";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "linkPickupHeart";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "linkPickupRupee";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "linkDying";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "linkLowHealth";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "linkPistol";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "linkShotgun";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "linkFinger";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "linkSaw";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);

            name = "linkWinScreen";
            soundEffect = SoundManager.Instance.GetSoundEffect(name);
            SoundEffectFactory.RegisterSoundEffect(name, soundEffect);
        }
    }
}
