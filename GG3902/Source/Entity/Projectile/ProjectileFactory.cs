using Microsoft.Xna.Framework;

namespace GG3902
{
    public static class ProjectileFactory
    {
        public static Projectile SpawnProjectile(Vector2 position, Vector2 direction, string type, bool IsEnemy, IEntity entity = null, int damage = 1, bool destroyOnContact = true, int speed = 1000)
        {
            Projectile projectile;
            double lifeSpan = 1;
            Vector2 offset = new Vector2(64, 64);
            Vector2 offsetPosition = position + offset * direction;

            switch (type)
            {
                case "WoodenSword":
                    projectile = new Projectile(position, direction, type, false, lifeSpan / 3, new BoomerangMovementStrategy(500, lifeSpan / 3), IsEnemy, damage);
                    break;
                case "GreenArrow":
                    projectile = new Projectile(offsetPosition, direction, type, true, lifeSpan, new ArrowMovementStrategy(400), IsEnemy, damage);
                    break;
                case "BlueArrow":
                    projectile = new Projectile(offsetPosition, direction, type, true, lifeSpan, new ArrowMovementStrategy(550), IsEnemy, damage);
                    break;
                case "Boomerang":
                    projectile = new Projectile(position, direction, type, false, lifeSpan * 3, new BoomerangMovementStrategy(300, lifeSpan * 3), IsEnemy, damage);
                    break;
                case "BlueBoomerang":
                    projectile = new Projectile(position, direction, type, false, lifeSpan * 3, new BoomerangMovementStrategy(450, lifeSpan * 3), IsEnemy, damage);
                    break;
                case "Fireball":
                    projectile = new Projectile(offsetPosition, direction, type, false, lifeSpan, new ArrowMovementStrategy(250), IsEnemy, damage);
                    break;
                case "Bomb":
                    projectile = new Projectile(offsetPosition, direction, type, true, lifeSpan, new ArrowMovementStrategy(0), IsEnemy, damage);
                    break;
                case "Bullet":
                    projectile = new Projectile(offsetPosition, direction, type, true, lifeSpan, new ArrowMovementStrategy(speed), IsEnemy, damage, destroyOnContact);
                    break;
                case "Saw":
                    projectile = new Projectile(offsetPosition, direction, type, true, lifeSpan, new ArrowMovementStrategy(speed), IsEnemy, damage, destroyOnContact);
                    break;
                case "Rocket":
                    projectile = new Projectile(offsetPosition, direction, type, true, lifeSpan, new RocketMovementStrategy(speed, lifeSpan, position), IsEnemy, damage, destroyOnContact);
                    break;
                default:
                    projectile = null;
                    break;
            }

            projectile.Parent = entity;
            return projectile;
        }
    }
}
