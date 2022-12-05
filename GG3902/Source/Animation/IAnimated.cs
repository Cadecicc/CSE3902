namespace GG3902
{
    public interface IAnimated
    {
        void SetAnimation(string animationName);
        void PlayAnimation();
        void StopAnimation();
        bool HasAnimationEnded();
        Direction GetDirection();
    }
}
