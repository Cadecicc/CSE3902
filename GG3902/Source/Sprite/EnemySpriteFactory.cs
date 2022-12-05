using System;
using GG3902.Source.Animations;
using GG3902.Source.Movements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GG3902.Source.Sprites
{
    public class EnemySpriteFactory : IEntity
    {
        public IDamageable Damageable { get; }

        public IMovement Movement { get; }

        public IAnimator Animator { get; }

        public Vector2 Position { get; set; }

        public EnemySpriteFactory()
        {
            Position = 
        }
    }
}
