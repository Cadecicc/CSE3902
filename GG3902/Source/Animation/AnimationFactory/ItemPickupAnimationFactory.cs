using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GG3902
{
    public static class ItemPickupAnimationFactory
    {
        private static float itemPickupLayerDepth = .4f;

        public static void LoadAnimations()
        {
            Texture2D texture = TextureManager.Instance.GetTexture("items_misc");
            ISprite[] frames = { new Sprite(texture, new Rectangle(240, 0, 8, 16), AnimationFactory.Scale, itemPickupLayerDepth) };
            AnimationFactory.RegisterAnimation("Key", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(72, 0, 8, 16), AnimationFactory.Scale, itemPickupLayerDepth),
                new Sprite(texture, new Rectangle(72, 16, 8, 16), AnimationFactory.Scale, itemPickupLayerDepth)
            };
            AnimationFactory.RegisterAnimation("Rupee_1", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            frames = new ISprite[] { new Sprite(texture, new Rectangle(58, 0, 11, 16), AnimationFactory.Scale, itemPickupLayerDepth) };
            AnimationFactory.RegisterAnimation("Clock", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            frames = new ISprite[] { new Sprite(texture, new Rectangle(72, 16, 8, 16), AnimationFactory.Scale, itemPickupLayerDepth) };
            AnimationFactory.RegisterAnimation("Rupee_5", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 0, 7, 8), AnimationFactory.Scale, itemPickupLayerDepth),
                new Sprite(texture, new Rectangle(0, 8, 7, 8), AnimationFactory.Scale, itemPickupLayerDepth)
            };
            AnimationFactory.RegisterAnimation("Heart_Small", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(40, 0, 8, 16), AnimationFactory.Scale, itemPickupLayerDepth),
                new Sprite(texture, new Rectangle(48, 0, 8, 16), AnimationFactory.Scale, itemPickupLayerDepth)
            };
            AnimationFactory.RegisterAnimation("Fairy", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            frames = new ISprite[] { new Sprite(texture, new Rectangle(257, 0, 13, 13), AnimationFactory.Scale, itemPickupLayerDepth) };
            AnimationFactory.RegisterAnimation("Compass", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            frames = new ISprite[] { new Sprite(texture, new Rectangle(88, 0, 8, 16), AnimationFactory.Scale, itemPickupLayerDepth) }; AnimationFactory.RegisterAnimation("Map", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            frames = new ISprite[] { new Sprite(texture, new Rectangle(136, 0, 8, 14), AnimationFactory.Scale, itemPickupLayerDepth) };
            AnimationFactory.RegisterAnimation("Bomb", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            frames = new ISprite[] { new Sprite(texture, new Rectangle(144, 0, 8, 16), AnimationFactory.Scale, itemPickupLayerDepth) };
            AnimationFactory.RegisterAnimation("Bow", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            frames = new ISprite[] { new Sprite(texture, new Rectangle(129, 3, 5, 8), AnimationFactory.Scale, itemPickupLayerDepth) };
            AnimationFactory.RegisterAnimation("Boomerang", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            frames = new ISprite[] { new Sprite(texture, new Rectangle(25, 1, 13, 13), AnimationFactory.Scale, itemPickupLayerDepth) };
            AnimationFactory.RegisterAnimation("Heart_Big", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            frames = new ISprite[] { new Sprite(TextureManager.Instance.GetTexture("guns"), new Rectangle(0, 0, 16, 16), AnimationFactory.Scale, itemPickupLayerDepth) };
            AnimationFactory.RegisterAnimation("MachineGun", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            frames = new ISprite[] { new Sprite(TextureManager.Instance.GetTexture("guns"), new Rectangle(32, 0, 16, 16), AnimationFactory.Scale, itemPickupLayerDepth) };
            AnimationFactory.RegisterAnimation("Shotgun", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            frames = new ISprite[] { new Sprite(TextureManager.Instance.GetTexture("guns"), new Rectangle(48, 0, 16, 16), AnimationFactory.Scale, itemPickupLayerDepth) };
            AnimationFactory.RegisterAnimation("AR", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            frames = new ISprite[] { new Sprite(TextureManager.Instance.GetTexture("guns"), new Rectangle(64, 0, 16, 16), AnimationFactory.Scale, itemPickupLayerDepth) };
            AnimationFactory.RegisterAnimation("Finger", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            frames = new ISprite[] { new Sprite(TextureManager.Instance.GetTexture("guns"), new Rectangle(80, 0, 16, 16), AnimationFactory.Scale, itemPickupLayerDepth) };
            AnimationFactory.RegisterAnimation("Pistol", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            frames = new ISprite[] { new Sprite(TextureManager.Instance.GetTexture("guns"), new Rectangle(112, 0, 16, 16), AnimationFactory.Scale, itemPickupLayerDepth) };
            AnimationFactory.RegisterAnimation("Rocket Launcher", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            frames = new ISprite[] { new Sprite(TextureManager.Instance.GetTexture("guns"), new Rectangle(16, 0, 16, 16), AnimationFactory.Scale, itemPickupLayerDepth) };
            AnimationFactory.RegisterAnimation("SawbladeGun", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            frames = new ISprite[] { new Sprite(TextureManager.Instance.GetTexture("guns"), new Rectangle(96, 0, 16, 16), AnimationFactory.Scale, itemPickupLayerDepth) };
            AnimationFactory.RegisterAnimation("Sniper", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(275, 3, 10, 10), AnimationFactory.Scale, itemPickupLayerDepth),
                new Sprite(texture, new Rectangle(275, 19, 10, 10), AnimationFactory.Scale, itemPickupLayerDepth)
            };
            AnimationFactory.RegisterAnimation("Triforce", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
        }
    }
}
