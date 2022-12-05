using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GG3902
{
    public class UIElement : Entity
    {
        private string type;

        // Set UI Sprite 
        private ISprite Sprite
        {
            get => GetComponent<ISprite>();
            set => SetComponent(value); 
        }

        public string Type => type;
        public bool Enabled { get; set; } = false;

        // Set type of UIElemnt
        public UIElement(string type)
        {
            EntityManager.Instance.PersistEntity(Id);

            this.type = type;
            Initialize();
        }

        public override void Initialize()
        {
            Sprite = UISpriteFactory.LoadSprite(type);
        }
    }
}
