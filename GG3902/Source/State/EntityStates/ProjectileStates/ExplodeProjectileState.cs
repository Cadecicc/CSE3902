using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace GG3902
{
    public class ExplodeProjectileState : IState
    {
        private Projectile projectile;
        private string type;
        private SoundEffect soundEffect;

        public ExplodeProjectileState(Projectile projectile)
        {
            this.projectile = projectile;
            type = projectile.Type;
            soundEffect = SoundEffectFactory.LoadSoundEffect("linkBombExplode");
        }

        public void Enter()
        {
            if (projectile.IsExploding)
            {
                projectile.SetAnimation(projectile.Type + "Explode");

                if ((type == "Bomb" || type == "Rocket") && !SoundManager.isMuted)
                {
                    soundEffect.Play();
                }
            }

            else
                projectile.SetAnimation("");

            projectile.SetComponent(new StopMovingDecorator(projectile.GetComponent<IMovement>()) as IMovement);
            
        }

        public void Exit() { }

        public void Update(GameTime gameTime)
        {
            if (projectile.HasAnimationEnded())
            {
                if (projectile.Type == "Rocket")
                    foreach (IEntity damageable in EntityManager.Instance.Damageables)
                        if (damageable is Enemy && Vector2.Distance(damageable.Position, projectile.Position) < 240f)
                            (damageable as IDamageable).TakeDamage(10, (damageable.Position - projectile.Position).ToDirection().Opposite());

                projectile.DeleteSelf();
            }
        }
    }
}
