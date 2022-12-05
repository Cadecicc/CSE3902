using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace GG3902
{
    public class Background : Entity
    {
        private string type;

        private ISprite Sprite
        {
            get => GetComponent<ISprite>();
            set => SetComponent(value);
        }
 
        public Background(string type,Camera camera)
        {
            this.type = type;
            Position = camera.WorldPosition + new Vector2(0, -116);
            Initialize();
        }

        public override void Initialize()
        {
            Sprite = BackgroundSpriteFactory.LoadSprite(type);
        }
    }
}
