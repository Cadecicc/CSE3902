using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GG3902
{
    public static class CollisionHandler
    {
        private static Dictionary<(Type, Type), Action<Collision>> typesToCollisionResponse;
        private static Game1 Game;
        private static Camera Camera;

        static CollisionHandler()
        {
            typesToCollisionResponse = new Dictionary<(Type, Type), Action<Collision>>()
            {
                { (typeof(Player), typeof(Enemy)),
                    (Collision collision) => { CollisionResponses.DamageableDamagingResponse(collision); } },
                { (typeof(Player), typeof(Tile)),
                    (Collision collision) => { CollisionResponses.EntityTileResponse(collision,Game,Camera); } },
                { (typeof(Player), typeof(Door)),
                    (Collision collision) => { CollisionResponses.PlayerDoorResponse(collision,Game,Camera); } },
                { (typeof(Enemy), typeof(Door)),
                    (Collision collision) => { CollisionResponses.EntityTileResponse(collision,Game,Camera); } },
                { (typeof(Projectile), typeof(Door)),
                    (Collision collision) => { CollisionResponses.ProjectileResponse(collision); } },
                { (typeof(Enemy), typeof(Tile)),
                    (Collision collision) => { CollisionResponses.EntityTileResponse(collision,Game,Camera); } },
                { (typeof(Enemy), typeof(Enemy)),
                    (Collision collision) => { CollisionResponses.EnemyEnemyResponse(collision); } },
                { (typeof(Projectile), typeof(Tile)),
                    (Collision collision) => { CollisionResponses.ProjectileResponse(collision); } },
                { (typeof(Projectile), typeof(Enemy)),
                    (Collision collision) => { CollisionResponses.ProjectileResponse(collision); } },
                { (typeof(Projectile), typeof(Player)),
                    (Collision collision) => { CollisionResponses.ProjectileResponse(collision); } },
                { (typeof(Player), typeof(ItemPickup)),
                    (Collision collision) => { CollisionResponses.PlayerItemResponse(collision,Game,Camera); } }
            };
        }

        public static void DetectCollisions(Game1 game, Camera camera, IEnumerable<ICollideable> colliders, IEnumerable<ICollideable> collidees)
        {
            foreach (ICollideable collider in colliders)
            {
                foreach (ICollideable collidee in collidees)
                {
                    Game = game;
                    Camera = camera;
                    if (!typesToCollisionResponse.ContainsKey((collider.GetType(), collidee.GetType())))
                        continue;
                    if (collider == collidee)
                        continue;
                    if (collider.Collider == null || collidee.Collider == null)
                        continue;
                    if (!typesToCollisionResponse.ContainsKey((collider.GetType(), collidee.GetType())))
                        continue;

                    Direction direction;
                    Rectangle overlap;
                    Collision collision;

                    if (collider.Collider.Hitbox.Intersects(collidee.Collider.Hitbox))
                    {
                        overlap = Rectangle.Intersect(collider.Collider.Hitbox, collidee.Collider.Hitbox);

                        if (overlap.Width < overlap.Height)
                        {
                            if (collider.Collider.Hitbox.Center.X < collidee.Collider.Hitbox.Center.X)
                                direction = Direction.Left;
                            else
                                direction = Direction.Right;
                        }
                        else
                        {
                            if (collider.Collider.Hitbox.Center.Y < collidee.Collider.Hitbox.Center.Y)
                                direction = Direction.Down;
                            else
                                direction = Direction.Up;
                        }
                        collision = new Collision() { Direction = direction, Collider = collider, Collidee = collidee, Overlap = overlap };
                        GetCollisionResponse(collision);
                    }
                }
            }
        }

        public static void GetCollisionResponse(Collision collision)
        {
            var collider = collision.Collider;
            var collidee = collision.Collidee;
            if (!typesToCollisionResponse.TryGetValue((collider.GetType(), collidee.GetType()), out Action<Collision> value))
                return;
            value.Invoke(collision);
        }
    }
}