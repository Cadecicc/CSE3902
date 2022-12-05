using Microsoft.Xna.Framework;
using System;

namespace GG3902
{
    public class Button : Entity, IClickable
    {
        private string type;

        private ICollider Collider { get; set; }
        private ISprite Sprite
        {
            get => GetComponent<ISprite>();
            set => SetComponent(value);
        }

        public string Type
        {
            get
            {
                return type;
            }
        }

        public Button(string type, Vector2 startingPosition)
        {
            this.type = type;
            Position = startingPosition;
            Initialize();
        }

        public override void Initialize()
        {
            Collider = new Collider(this, new Point(256, 128));
            Sprite = new Sprite(TextureManager.Instance.GetTexture(type), new Rectangle(0, 0, 256, 128), 1, 0.01f);
        }

        public bool IsClicked(Vector2 mousePosition)
        {
            return Collider.Hitbox.Contains(mousePosition);
        }
    }
}
