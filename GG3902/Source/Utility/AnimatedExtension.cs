namespace GG3902
{
    public static class AnimatedExtension
    {
        public static void SetDirectionalAnimation(this IAnimated animated, string upAnim, string downAnim, string leftAnim, string rightAnim)
        {
            string animationName = "";

            switch (animated.GetDirection())
            {
                case Direction.Up:
                    animationName = upAnim;
                    break;
                case Direction.Down:
                    animationName = downAnim;
                    break;
                case Direction.Left:
                    animationName = leftAnim;
                    break;
                case Direction.Right:
                    animationName = rightAnim;
                    break;
                default:
                    break;
            }

            animated.SetAnimation(animationName);
        }
    }
}
