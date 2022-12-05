using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

namespace GG3902
{
    public class Gun : Entity
    {
        private Vector2 barrelPosOffset;
        private string type;
        private int roundsLoaded;
        private float roundsPerSecond;
        private ShootBehaviour shootBehaviour;
        private Player player;
        private int damage;
        private int speed;

        public delegate int ShootBehaviour(Gun gun);

        public override Vector2 Position { get { return player.Position; } set => _ = value; }
        public Vector2 Rotation => player.Rotation;
        public string Type => type;
        public Vector2 BarrelPosition => Position + barrelPosOffset * Rotation;
        public int RoundsLoaded => roundsLoaded;
        public float RoundsPerSecond => roundsPerSecond;
        public int Damage => damage;


        public Gun(Vector2 barrelPosOffset, string type, float roundsPerSecond, ShootBehaviour shootBehaviour, Player player, int damage = 1, int speed = 1000)
        {
            this.barrelPosOffset = barrelPosOffset;
            this.type = type;
            this.roundsPerSecond = roundsPerSecond;
            this.shootBehaviour = shootBehaviour;
            this.player = player;
            this.damage = damage;
            this.speed = speed;
        }

        public override void Initialize()
        {
            SetComponent(GunSpriteFactory.LoadSprite(type, player));
        }

        public int Shoot(int ammo)
        {
            roundsLoaded = ammo;
            if (roundsLoaded < 1)
                return 0;

            roundsLoaded -= shootBehaviour.Invoke(this);
            return roundsLoaded;
        }
    }

    // Shoot behaviours spawn bullets and return how many bullets they've spawned.
    public static class ShootBehaviours
    {
        public static int ShootOnce(Gun gun)
        {
            ProjectileFactory.SpawnProjectile(gun.BarrelPosition, gun.Rotation, "Bullet", false, null, gun.Damage);
            return 1;
        } 

        // Spawns three bullets in a cone.
        public static int ScatterShot(Gun gun)
        {
            int roundsShot = 1;
            // Spawn one in the middle
            ProjectileFactory.SpawnProjectile(gun.BarrelPosition, gun.Rotation, "Bullet", false, null, gun.Damage);
            if (gun.RoundsLoaded > 2)
            {
                // Spawn one to the left
                ProjectileFactory.SpawnProjectile(gun.BarrelPosition, gun.Rotation.Rotate(33), "Bullet", false, null, gun.Damage);
                roundsShot++;
            }
            if (gun.RoundsLoaded > 1)
            {
                // Spawn one to the right
                ProjectileFactory.SpawnProjectile(gun.BarrelPosition, gun.Rotation.Rotate(-33), "Bullet", false, null, gun.Damage);
                roundsShot++;
            }
            return roundsShot;
        }

        public static int ShootPenetration(Gun gun)
        {            
            ProjectileFactory.SpawnProjectile(gun.BarrelPosition, gun.Rotation, "Bullet", false, null, gun.Damage, false, 4000);
            return 1;
        }

        public static int ShootSaw(Gun gun)
        {
            ProjectileFactory.SpawnProjectile(gun.BarrelPosition, gun.Rotation, "Saw", false, null, gun.Damage, false);
            return 1;
        }

        public static int ShootRocket(Gun gun)
        {
            ProjectileFactory.SpawnProjectile(gun.BarrelPosition, gun.Rotation, "Rocket", false, null, gun.Damage);
            return 1;
        }
    }
}
