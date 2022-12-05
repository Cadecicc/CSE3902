using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GG3902
{
    public static class EnemyAnimationFactory
    {
        private static float enemyLayerDepth = .5f;

        public static void LoadAnimations()
        {
            Texture2D texture;
            ISprite[] frames;
            string name = "";

            //Armos Animations
            texture = TextureManager.Instance.GetTexture("armos");
            name = "Armos";
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 0, 17, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(texture, new Rectangle(16, 0, 17, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "DownMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            AnimationFactory.RegisterAnimation(name, "RightMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            AnimationFactory.RegisterAnimation(name, "LeftMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(33, 0, 17, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(texture, new Rectangle(50, 0, 17, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "UpMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            //Tank Animations
            texture = TextureManager.Instance.GetTexture("tank");
            name = "Tank";
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 0, 17, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(texture, new Rectangle(16, 0, 17, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "DownMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            AnimationFactory.RegisterAnimation(name, "RightMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            AnimationFactory.RegisterAnimation(name, "LeftMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(33, 0, 17, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(texture, new Rectangle(50, 0, 17, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "UpMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            //Ghini Animations
            texture = TextureManager.Instance.GetTexture("ghini");
            name = "Ghini";
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 0, 16, 14), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "LeftMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));
            AnimationFactory.RegisterAnimation(name, "DownMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));
            AnimationFactory.RegisterAnimation(name, "RightMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(17, 0, 16, 14), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "UpMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));

            //Leever Animations
            texture = TextureManager.Instance.GetTexture("leever");
            name = "Leever";
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(texture, new Rectangle(18, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(texture, new Rectangle(34, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(texture, new Rectangle(50, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(texture, new Rectangle(68, 0, 15, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "UpMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));
            AnimationFactory.RegisterAnimation(name, "DownMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));
            AnimationFactory.RegisterAnimation(name, "RightMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));
            AnimationFactory.RegisterAnimation(name, "LeftMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));

            //Lynel Animations
            texture = TextureManager.Instance.GetTexture("lynel");
            name = "Lynel";
            Texture2D flipped = TextureManager.Instance.GetTexture("lynelflipped");
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 0, 15, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite (flipped, new Rectangle(52, 0, 15, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "DownMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(17, 0, 15, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(flipped, new Rectangle(35, 0, 15, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "UpMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(33, 0, 17, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(texture, new Rectangle(50, 0, 17, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "RightMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));
            frames = new ISprite[]
            {
                new Sprite(flipped, new Rectangle(0, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(flipped, new Rectangle(17, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "LeftMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));

            //Moblin Animations
            name = "Moblin";
            texture = TextureManager.Instance.GetTexture("moblin");
            flipped = TextureManager.Instance.GetTexture("moblinflipped");
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(flipped, new Rectangle(51, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "DownMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(17, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(flipped, new Rectangle(34, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "UpMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(34, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(texture, new Rectangle(51, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "RightMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));
            frames = new ISprite[]
            {
                new Sprite(flipped, new Rectangle(0, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(flipped, new Rectangle(17, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "LeftMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));

            //Walker Animations
            name = "Walker";
            texture = TextureManager.Instance.GetTexture("walker");
            flipped = TextureManager.Instance.GetTexture("walkerflipped");
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(flipped, new Rectangle(51, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "DownMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(17, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(flipped, new Rectangle(34, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "UpMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(34, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(texture, new Rectangle(51, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "RightMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(flipped, new Rectangle(0, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(flipped, new Rectangle(17, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "LeftMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            //Octorok Animations
            name = "Octorok";
            texture = TextureManager.Instance.GetTexture("octorok");
            flipped = TextureManager.Instance.GetTexture("octorokflipped");
            Texture2D upsideDown = TextureManager.Instance.GetTexture("octorokupsidedown");
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(texture, new Rectangle(17, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "UpMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(upsideDown, new Rectangle(34, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(upsideDown, new Rectangle(51, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "DownMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(34, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(texture, new Rectangle(53, 0, 14, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "RightMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(flipped, new Rectangle(0, 0, 14, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(flipped, new Rectangle(17, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "LeftMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            //Spitter Animations
            name = "Spitter";
            texture = TextureManager.Instance.GetTexture("spitter");
            flipped = TextureManager.Instance.GetTexture("spitterflipped");
            upsideDown = TextureManager.Instance.GetTexture("spitterupsidedown");
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(texture, new Rectangle(17, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "UpMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(upsideDown, new Rectangle(34, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(upsideDown, new Rectangle(51, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "DownMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(34, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(texture, new Rectangle(53, 0, 14, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "RightMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(flipped, new Rectangle(0, 0, 14, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(flipped, new Rectangle(17, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "LeftMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            //Peahat Animations
            name = "Peahat";
            texture = TextureManager.Instance.GetTexture("peahat");
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 0, 17, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(texture, new Rectangle(17, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "UpMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));
            AnimationFactory.RegisterAnimation(name, "DownMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));
            AnimationFactory.RegisterAnimation(name, "LeftMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));
            AnimationFactory.RegisterAnimation(name, "RightMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));

            //Tektite Animations
            name = "Tektite";
            texture = TextureManager.Instance.GetTexture("tektite");
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                new Sprite(texture, new Rectangle(17, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "UpMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));
            AnimationFactory.RegisterAnimation(name, "DownMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));
            AnimationFactory.RegisterAnimation(name, "LeftMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));
            AnimationFactory.RegisterAnimation(name, "RightMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame ));

            //Runner Animations
            texture = TextureManager.Instance.GetTexture("runner");
            name = "Runner";
            // Down moving
            frames = new ISprite[]
            {
                    new Sprite(texture, new Rectangle(0, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                    new Sprite(texture, new Rectangle(16, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "DownMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            // Right moving
            frames = new ISprite[]
            {
                    new Sprite(texture, new Rectangle(32, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                    new Sprite(texture, new Rectangle(48, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "RightMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            // Up moving
            frames = new ISprite[]
            {
                    new Sprite(texture, new Rectangle(64, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth - .2f),
                    new Sprite(texture, new Rectangle(80, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth - .2f)
            };
            AnimationFactory.RegisterAnimation(name, "UpMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            // Left moving
            frames = new ISprite[]
            {
                    new Sprite(texture, new Rectangle(96, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth),
                    new Sprite(texture, new Rectangle(112, 0, 16, 16), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "LeftMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            //Blood splatters
            texture = TextureManager.Instance.GetTexture("bloodSplatter");
            name = "Blood";
            frames = new ISprite[]
            {
                    new Sprite(texture, new Rectangle(14, 50, 38, 30), AnimationFactory.Scale, enemyLayerDepth),
                    new Sprite(texture, new Rectangle(62, 50, 38, 30), AnimationFactory.Scale, enemyLayerDepth),
                    new Sprite(texture, new Rectangle(111, 40, 58, 36), AnimationFactory.Scale, enemyLayerDepth),
                    new Sprite(texture, new Rectangle(173, 18, 64, 52), AnimationFactory.Scale, enemyLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "UpMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
        }
    }
}
