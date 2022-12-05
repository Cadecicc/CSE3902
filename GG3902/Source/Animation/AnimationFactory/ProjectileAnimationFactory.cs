using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GG3902
{
    public static class ProjectileAnimationFactory
    {
        private static float projectileLayerDepth = .5f;

        public static void LoadAnimations()
        {
            Texture2D texture;
            ISprite[] frames;

            string name = "MoblinArrow";
            texture = TextureManager.Instance.GetTexture("moblinarrows");
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 0, 9, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "UpMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame / 2));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(9, 0, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "RightMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame / 2));
            texture = TextureManager.Instance.GetTexture("moblinarrowsflipped");
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 0, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "LeftMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame / 2));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(16, 0, 9, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "DownMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame / 2));
            
            name = "GreenArrow";
            texture = TextureManager.Instance.GetTexture("player_projectiles");
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 0, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "UpMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(16, 0, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "RightMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(48, 0, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "LeftMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(32, 0, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "DownMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(64, 0, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "Explode", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            
            name = "BlueArrow";
            texture = TextureManager.Instance.GetTexture("player_projectiles");
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 16, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "UpMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(16, 16, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "RightMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(48, 16, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "LeftMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(32, 16, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "DownMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(64, 0, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "Explode", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            
            name = "Boomerang";
            Animation boomerangAnimation;

            texture = TextureManager.Instance.GetTexture("player_projectiles");
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 32, 16, 16), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(16, 32, 16, 16), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(32, 32, 16, 16), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(48, 32, 16, 16), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(64, 32, 16, 16), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(80, 32, 16, 16), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(96, 32, 16, 16), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(112, 32, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            boomerangAnimation = new Animation(frames, AnimationFactory.DrawCallsPerFrame / 2);
            AnimationFactory.RegisterAnimation(name, "UpMoving", boomerangAnimation);
            AnimationFactory.RegisterAnimation(name, "RightMoving", boomerangAnimation);
            AnimationFactory.RegisterAnimation(name, "LeftMoving", boomerangAnimation);
            AnimationFactory.RegisterAnimation(name, "DownMoving", boomerangAnimation);
            
            name = "BlueBoomerang";
            Animation blueBoomerangAnimation;

            texture = TextureManager.Instance.GetTexture("player_projectiles");
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 48, 16, 16), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(16, 48, 16, 16), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(32, 48, 16, 16), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(48, 48, 16, 16), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(64, 48, 16, 16), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(80, 48, 16, 16), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(96, 48, 16, 16), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(112, 48, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            blueBoomerangAnimation = new Animation(frames, AnimationFactory.DrawCallsPerFrame / 2);
            AnimationFactory.RegisterAnimation(name, "UpMoving", blueBoomerangAnimation);
            AnimationFactory.RegisterAnimation(name, "RightMoving", blueBoomerangAnimation);
            AnimationFactory.RegisterAnimation(name, "LeftMoving", blueBoomerangAnimation);
            AnimationFactory.RegisterAnimation(name, "DownMoving", blueBoomerangAnimation);
            
            name = "Bomb";
            Animation bombAnimation;

            texture = TextureManager.Instance.GetTexture("player_projectiles");
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 64, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            bombAnimation = new Animation(frames, AnimationFactory.DrawCallsPerFrame);
            AnimationFactory.RegisterAnimation(name, "UpMoving", bombAnimation);
            AnimationFactory.RegisterAnimation(name, "RightMoving", bombAnimation);
            AnimationFactory.RegisterAnimation(name, "LeftMoving", bombAnimation);
            AnimationFactory.RegisterAnimation(name, "DownMoving", bombAnimation);
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(16, 64, 16, 16), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(32, 64, 16, 16), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(48, 64, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "Explode", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            
            name = "Fireball";
            Animation fireballAnimation;

            texture = TextureManager.Instance.GetTexture("player_projectiles");
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 80, 16, 16), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(16, 80, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            fireballAnimation = new Animation(frames, AnimationFactory.DrawCallsPerFrame / 2);
            AnimationFactory.RegisterAnimation(name, "UpMoving", fireballAnimation);
            AnimationFactory.RegisterAnimation(name, "RightMoving", fireballAnimation);
            AnimationFactory.RegisterAnimation(name, "LeftMoving", fireballAnimation);
            AnimationFactory.RegisterAnimation(name, "DownMoving", fireballAnimation);

            name = "WoodenSword";
            texture = TextureManager.Instance.GetTexture("player_projectiles");
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 112, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "UpMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(16, 112, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "RightMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(48, 112, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "LeftMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(32, 112, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "DownMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            name = "Rocket";
            texture = TextureManager.Instance.GetTexture("Rocket");
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 0, 6, 4), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(6, 0, 4, 6), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(4, 6, 6, 4), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(0, 4, 4, 6), AnimationFactory.Scale, projectileLayerDepth)

            };
            AnimationFactory.RegisterAnimation(name, "RightMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 0, 3, 2), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(3, 0, 2, 3), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(2, 3, 3, 2), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(0, 2, 2, 3), AnimationFactory.Scale, projectileLayerDepth)

            };
            AnimationFactory.RegisterAnimation(name, "LeftMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 0, 3, 2), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(3, 0, 2, 3), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(2, 3, 3, 2), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(0, 2, 2, 3), AnimationFactory.Scale, projectileLayerDepth)

            };
            AnimationFactory.RegisterAnimation(name, "UpMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 0, 3, 2), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(3, 0, 2, 3), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(2, 3, 3, 2), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(0, 2, 2, 3), AnimationFactory.Scale, projectileLayerDepth)

            };
            AnimationFactory.RegisterAnimation(name, "DownMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            
            name = "Bullet";
            texture = TextureManager.Instance.GetTexture("player_projectiles");
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 128, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "UpMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            AnimationFactory.RegisterAnimation(name, "RightMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            AnimationFactory.RegisterAnimation(name, "LeftMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            AnimationFactory.RegisterAnimation(name, "DownMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(64, 0, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "Explode", new Animation(frames, AnimationFactory.DrawCallsPerFrame));

            name = "Saw";
            texture = TextureManager.Instance.GetTexture("player_projectiles");
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(0, 144, 16, 16), AnimationFactory.Scale, projectileLayerDepth),
                new Sprite(texture, new Rectangle(16, 144, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "UpMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            AnimationFactory.RegisterAnimation(name, "RightMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            AnimationFactory.RegisterAnimation(name, "LeftMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            AnimationFactory.RegisterAnimation(name, "DownMoving", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(64, 0, 16, 16), AnimationFactory.Scale, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation(name, "Explode", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
            frames = new ISprite[]
            {
                new Sprite(texture, new Rectangle(64, 0, 16, 16), AnimationFactory.Scale * 10, projectileLayerDepth)
            };
            AnimationFactory.RegisterAnimation("Rocket", "Explode", new Animation(frames, AnimationFactory.DrawCallsPerFrame));
        }
    }
}
