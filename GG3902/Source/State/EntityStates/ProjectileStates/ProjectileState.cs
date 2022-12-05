using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace GG3902
{
    public class ProjectileState : IState
    {
        private Projectile projectile;
        private double lifeSpan;
        private string type;
        private SoundEffect soundEffect;
        private SoundEffectInstance soundEffectInstance;

        public ProjectileState(Projectile projectile, double lifeSpan)
        {
            this.projectile = projectile;
            this.lifeSpan = lifeSpan;
            type = projectile.Type;
            if (type == "GreenArrow" || type == "BlueArrow" || type == "Boomerang" || type == "BlueBoomerang" || type == "Fireball" || type == "Bullet" || type == "Saw")
            {
                soundEffect = SoundEffectFactory.LoadSoundEffect("linkArrowAttack");
            }
            else if (type == "Bomb" || type == "Rocket")
            {
                soundEffect = SoundEffectFactory.LoadSoundEffect("linkBombDrop");
            }
        }

        public void Enter()
        {
            projectile.SetDirectionalAnimation(type + "UpMoving", type + "DownMoving", type + "LeftMoving", type + "RightMoving");
            if (type == "Boomerang" || type == "BlueBoomerang" || type == "Saw")
            {
                soundEffectInstance = soundEffect.CreateInstance();
                soundEffectInstance.IsLooped = true;
                SoundManager.Instance.RegisterSoundInstance(soundEffectInstance);
                if (!SoundManager.isMuted)
                    soundEffectInstance.Play();
            } else if (type == "WoodenSword")
            {

            } else if (!SoundManager.isMuted)
            {
                soundEffect.Play();
            }
        }

        public void Exit()
        {
            if (type == "Boomerang" || type == "BlueBoomerang" || type == "Saw")
                soundEffectInstance.Stop();
        }

        public void Update(GameTime gameTime)
        {
            lifeSpan -= gameTime.DeltaTime();

            if (lifeSpan < 0)
                projectile.Explode();
        }
    }
}
