using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GG3902
{
    public static class PlayerAnimationFactory
    {
        private static float playerLayerDepth = .3f;

        public static void LoadAnimations()
        {
            Texture2D texture = TextureManager.Instance.GetTexture("moving_link");
            string name = "Player";
            // Down moving
            ISprite[] frames =
            {
                    new Sprite(texture, new Rectangle(0, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth),
                    new Sprite(texture, new Rectangle(16, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth)
                };
            AnimationFactory.RegisterAnimation(name, "DownMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            // Right moving
            frames = new ISprite[]
            {
                    new Sprite(texture, new Rectangle(32, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth),
                    new Sprite(texture, new Rectangle(48, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "RightMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            // Up moving
            frames = new ISprite[]
            {
                    new Sprite(texture, new Rectangle(64, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth - .02f),
                    new Sprite(texture, new Rectangle(80, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth - .02f)
            };
            AnimationFactory.RegisterAnimation(name, "UpMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            // Left moving
            frames = new ISprite[]
            {
                    new Sprite(texture, new Rectangle(96, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth),
                    new Sprite(texture, new Rectangle(112, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "LeftMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            // Death
            Texture2D texture2 = TextureManager.Instance.GetTexture("death_flash");
            frames = new ISprite[]
            {
                    new Sprite(texture, new Rectangle(0, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth),
                    new Sprite(texture, new Rectangle(32, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth),
                    new Sprite(texture, new Rectangle(64, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth),
                    new Sprite(texture, new Rectangle(96, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth),
                    new Sprite(texture, new Rectangle(0, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth),
                    new Sprite(texture, new Rectangle(32, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth),
                    new Sprite(texture, new Rectangle(64, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth),
                    new Sprite(texture, new Rectangle(96, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth),
                    new Sprite(texture2, new Rectangle(0, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth),
                    new Sprite(texture2, new Rectangle(16, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth),
                    new Sprite(texture2, new Rectangle(32, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth),
                    new Sprite(texture2, new Rectangle(48, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "Death", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            // Damaged
            texture = TextureManager.Instance.GetTexture("damaged_link");
            frames = new ISprite[]
            {
                    new Sprite(texture, new Rectangle(0, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth),
                    new Sprite(texture, new Rectangle(16, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth),
                    new Sprite(texture, new Rectangle(32, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth),
                    new Sprite(texture, new Rectangle(48, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth),
                    new Sprite(texture, new Rectangle(64, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth),
            };
            AnimationFactory.RegisterAnimation(name, "Damaged", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            texture = TextureManager.Instance.GetTexture("wooden_sword_attack_link");
            Vector2 pivot = new Vector2(8, 8);
            frames = new ISprite[]
            {
                    new Sprite(texture, new Rectangle(0, 0, 16, 32), AnimationFactory.Scale, playerLayerDepth, pivot),
                    new Sprite(texture, new Rectangle(16, 0, 16, 32), AnimationFactory.Scale, playerLayerDepth, pivot),
                    new Sprite(texture, new Rectangle(32, 0, 16, 32), AnimationFactory.Scale, playerLayerDepth, pivot),
                    new Sprite(texture, new Rectangle(48, 0, 16, 32), AnimationFactory.Scale, playerLayerDepth, pivot)
            };
            AnimationFactory.RegisterAnimation(name, "DownAttack", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            pivot = new Vector2(8, 24);
            frames = new ISprite[]
            {
                    new Sprite(texture, new Rectangle(0, 48, 16, 32), AnimationFactory.Scale, playerLayerDepth, pivot),
                    new Sprite(texture, new Rectangle(16, 48, 16, 32), AnimationFactory.Scale, playerLayerDepth, pivot),
                    new Sprite(texture, new Rectangle(32, 48, 16, 32), AnimationFactory.Scale, playerLayerDepth, pivot),
                    new Sprite(texture, new Rectangle(48, 48, 16, 32), AnimationFactory.Scale, playerLayerDepth, pivot)
            };
            AnimationFactory.RegisterAnimation(name, "UpAttack", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            pivot = new Vector2(8, 8);
            frames = new ISprite[]
            {
                    new Sprite(texture, new Rectangle(0, 32, 32, 16), AnimationFactory.Scale, playerLayerDepth, pivot),
                    new Sprite(texture, new Rectangle(32, 32, 32, 16), AnimationFactory.Scale, playerLayerDepth, pivot),
                    new Sprite(texture, new Rectangle(64, 32, 32, 16), AnimationFactory.Scale, playerLayerDepth, pivot),
                    new Sprite(texture, new Rectangle(96, 32, 32, 16), AnimationFactory.Scale, playerLayerDepth, pivot)
            };
            AnimationFactory.RegisterAnimation(name, "RightAttack", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            pivot = new Vector2(24, 8);
            frames = new ISprite[]
            {
                    new Sprite(texture, new Rectangle(0, 80, 32, 16), AnimationFactory.Scale, playerLayerDepth, pivot),
                    new Sprite(texture, new Rectangle(32, 80, 32, 16), AnimationFactory.Scale, playerLayerDepth, pivot),
                    new Sprite(texture, new Rectangle(64, 80, 32, 16), AnimationFactory.Scale, playerLayerDepth, pivot),
                    new Sprite(texture, new Rectangle(96, 80, 32, 16), AnimationFactory.Scale, playerLayerDepth, pivot)
            };
            AnimationFactory.RegisterAnimation(name, "LeftAttack", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            // Pickup item
            texture = TextureManager.Instance.GetTexture("pickup_item_link"); frames = new ISprite[]
             {
                    new Sprite(texture, new Rectangle(0, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth)
             };
            AnimationFactory.RegisterAnimation(name, "DownItem", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                    new Sprite(texture, new Rectangle(16, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "RightItem", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                    new Sprite(texture, new Rectangle(32, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "UpItem", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                    new Sprite(texture, new Rectangle(48, 0, 16, 16), AnimationFactory.Scale, playerLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "LeftItem", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
        }
    }
}
