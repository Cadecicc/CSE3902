using Microsoft.Xna.Framework;

namespace GG3902
{
    public static class CollisionResponses
    {
        public static void DamageableDamagingResponse(Collision collision)
        {
            (collision.Collider as IDamageable).TakeDamage(1,collision.Direction);
        }

        public static void EntityTileResponse(Collision collision, Game1 game, Camera camera)
        {
            IEntity entity = collision.Collider as IEntity;
            Tile tile = collision.Collidee as Tile;
            if (entity is Player && tile.GetName() == "Teleporter")
            {
                game.ChangeRooms(collision.Direction.Opposite());
                game.SetState(StateManager.Instance.GetState("Zombies"));
                (entity as Player).Position = new Vector2(-3904, -2040);
            }
            
            else if (!(entity is Player) && tile?.GetName() == "Fire") return;
            else
            {
                if (entity is Player && tile.GetName() == "Fire")
                    (entity as Player).TakeDamage(1, collision.Direction);
                entity.Position += collision.Direction.ToVector() * new Vector2(collision.Overlap.Width, collision.Overlap.Height);
                if (collision.Direction.ToVector().X != 0)
                    entity.Position = new Vector2((int)entity.Position.X, entity.Position.Y);
                if (collision.Direction.ToVector().Y != 0)
                    entity.Position = new Vector2(entity.Position.X, (int)entity.Position.Y);
            }
        }

        public static void ProjectileResponse(Collision collision)
        {
            Projectile projectile = collision.Collider as Projectile;
            if (projectile.Type == "Saw")
            {
                (collision.Collidee as IDamageable)?.TakeDamage(projectile.Damage, collision.Direction);
                projectile.Direction = Vector2.Reflect(projectile.Direction, collision.Direction.ToVector());
                return;
            }
            if (collision.Collidee == projectile.Parent) return;
            if (collision.Collidee is Enemy && projectile.IsEnemyProjectile()) return;
            if (collision.Collidee is Player && !projectile.IsEnemyProjectile()) return;
            if (projectile.Type.Equals("Bomb")) return;
            if (collision.Collidee is Tile && (collision.Collidee as Tile).GetName() == "Fire")
                return;
            if (collision.Collidee is IDamageable && projectile.Type != "Rocket")
            {
                (collision.Collidee as IDamageable).TakeDamage(projectile.Damage, collision.Direction);
                if (projectile.DestroyOnContact)
                    projectile.Explode();
            }
            else if(collision.Collidee is ICollideable)
                projectile.Explode();
            else
            {
                projectile.Position += collision.Direction.ToVector() * new Vector2(collision.Overlap.Width, collision.Overlap.Height);
                if (collision.Direction.ToVector().X != 0)
                    projectile.Position = new Vector2((int)projectile.Position.X, projectile.Position.Y);
                if (collision.Direction.ToVector().Y != 0)
                    projectile.Position = new Vector2(projectile.Position.X, (int)projectile.Position.Y);
            }

        }

        public static void PlayerItemResponse(Collision collision,Game1 game, Camera camera)
        {
            ItemPickup itemPickup = collision.Collidee as ItemPickup;
            if (itemPickup.Type == "Triforce")
                game.SetState(StateManager.Instance.GetState("Win"));
            else
                (collision.Collider as Player).AddItem(itemPickup.Type); itemPickup.Remove();
        }

        public static void PlayerDoorResponse(Collision collision,Game1 game, Camera camera)
        {

            Player collider = collision.Collider as Player;
            Door collidee = collision.Collidee as Door;
            collidee.TransitionRooms(game, camera, collider);
        }

        public static void EnemyEnemyResponse(Collision collision)
        {
            IEntity entity = collision.Collider as IEntity;
            entity.Position += collision.Direction.ToVector() * new Vector2(collision.Overlap.Width, collision.Overlap.Height);
            if (collision.Direction.ToVector().X != 0)
                entity.Position = new Vector2((int)entity.Position.X, entity.Position.Y);
            if (collision.Direction.ToVector().Y != 0)
                entity.Position = new Vector2(entity.Position.X, (int)entity.Position.Y);
        }
    }
}
