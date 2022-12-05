namespace GG3902
{
    public interface IDamageable
    {
        int CurrentHealth { get; }
        int MaxHealth { get; set; }

        void TakeDamage(int damage,Direction direction);
        void Heal(int health);
    }
}
