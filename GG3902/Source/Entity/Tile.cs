using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace GG3902
{
    public class Tile : Entity, ICollideable
    {
        private string type;

        // Set tile sprite
        private ISprite Sprite
        {
            get => GetComponent<ISprite>();
            set => SetComponent(value);
        }
        private bool IsCollideable;

        //Set type of tile, starting position, and if collidable 
        public Tile(string type, Vector2 startingPosition, bool isCollideable)
        {
            this.type = type;
            Position = startingPosition * 16 * TileSpriteFactory.Scale;
            IsCollideable = isCollideable;
        }

        public ICollider Collider { get; set; }

        //Load sprite and initialize collider 
        public override void Initialize()
        {
            if (IsCollideable)
            {
                Collider = new Collider(this, new Point(60, 60));
            }
            Sprite = TileSpriteFactory.LoadSprite(type);
        }

        public string GetName()
        {
            return type;
        }
    }
}
