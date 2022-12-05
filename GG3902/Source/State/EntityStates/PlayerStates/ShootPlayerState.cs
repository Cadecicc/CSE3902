using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace GG3902
{
    public class ShootPlayerState : IState
    {
        private Player player;
        private Gun gun;
        private SoundEffect soundEffect;

        /*
         * animDirection = cardinal direction of the player,
         * timeUntilNextShot = the remaining time in seconds until the gun can fire again,
         * gunTimeToLive = the remaining time in seconds between the player lifting the shoot key and the gun being holstered,
         * isShooting = true if the player is holding the shoot key,
         * hasFired = true if the player has fired the gun (for semi-automatic weapons)
         */
        private Direction animDirection;
        private float timeUntilNextShot;
        private float gunTimeToLive;
        private bool isShooting;

        public bool IsShooting
        {
            get => isShooting;
            set
            {
                gunTimeToLive = 1f;
                isShooting = value;
            }
        }

        public ShootPlayerState(Player player, string gunType)
        {
            this.player = player;
            gun = GunFactory.SpawnGun(gunType, player);
            if (gunType.Equals("Shotgun"))
                soundEffect = SoundEffectFactory.LoadSoundEffect("linkShotgun");
            else if (gunType.Equals("Finger"))
                soundEffect = SoundEffectFactory.LoadSoundEffect("linkFinger");
            else if (gunType.Equals("SawGun"))
                soundEffect = SoundEffectFactory.LoadSoundEffect("linkSaw");
            else
                soundEffect = SoundEffectFactory.LoadSoundEffect("linkPistol");
            timeUntilNextShot = 0f;
            gunTimeToLive = 1f;
            isShooting = true;
        }

        public void Enter()
        {
            SetAnimation();
            gun.Initialize();
        }

        public void Exit()
        {
            gun.DeleteSelf();
        }

        public void Update(GameTime gameTime)
        {
            // Set the player movement animation
            Direction currentDirection = player.GetDirection();
            if (currentDirection != animDirection)
            {
                SetAnimation();
            }

            if (player.IsMoving())
                player.PlayAnimation();
            else
                player.StopAnimation();

            timeUntilNextShot -= gameTime.DeltaTime();

            // If the player isn't shooting anymore, set a countdown timer to holster the gun
            if (!isShooting)
            {
                gunTimeToLive -= gameTime.DeltaTime();
                if (gunTimeToLive < 0)
                    player.SetState(new MovePlayerState(player));

                return;
            }

            // If the player is shooting, decrement the shoot timer until it hits 0, then shoot and reset the timer.

            if (timeUntilNextShot < 0)
            {
                int ammo = player.GetAmmo();
                if (ammo > 0)
                {
                    player.SetAmmo(gun.Shoot(ammo));

                    if (!SoundManager.isMuted)
                        soundEffect.Play();
                }
                timeUntilNextShot = 1 / gun.RoundsPerSecond;
            }
        }

        // Duplicated code from MovePlayerState to set the player animation based on his direction.
        private void SetAnimation()
        {
            player.SetDirectionalAnimation("PlayerUpMoving", "PlayerDownMoving", "PlayerLeftMoving", "PlayerRightMoving");
            animDirection = player.GetDirection();
        }
    }
}
