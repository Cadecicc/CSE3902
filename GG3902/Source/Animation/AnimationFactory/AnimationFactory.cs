using System.Collections.Generic;

namespace GG3902
{
    public static class AnimationFactory
    {
        private static Dictionary<string, IAnimation> animations;

        public static float Scale = 4f;
        public static int DrawCallsPerFrame = 8;

        static AnimationFactory()
        {
            animations = new Dictionary<string, IAnimation>();
            EnemyAnimationFactory.LoadAnimations();
            ItemPickupAnimationFactory.LoadAnimations();
            PlayerAnimationFactory.LoadAnimations();
            ProjectileAnimationFactory.LoadAnimations();
            animations.Add("", new NullAnimation());
        }

        public static IAnimation LoadAnimation(string name)
        {
            IAnimation animation = animations[name];
            if (animation is Animation)
                return (IAnimation)(animation as Animation).Clone();
            animation.Reset();
            return animations[name];
        }

        public static void RegisterAnimation(string animationName, IAnimation animation)
        {
            animations.Add(animationName, animation);
        }

        public static void RegisterAnimation(string objectName, string animationName, IAnimation animation)
        {
            animations.Add(objectName + animationName, animation);
        }
    }
}
