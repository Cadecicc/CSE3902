using Microsoft.Xna.Framework;

namespace GG3902
{
    public class Damageable : IDamageable, IComponent
    {
        private double recoveryTimeInterval;
        private Damage damage;
        private double currentTime;
        private double nextDamageTime;

        public int CurrentHealth
        {
            get => damage.CurrentHealth;
            private set => damage.CurrentHealth = value;
        }

        public int MaxHealth
        {
            get => damage.MaxHealth;
            set => CurrentHealth = damage.MaxHealth = value;
        }

        public bool Vulnerable => damage.CurrentHealth > 0 && currentTime >= nextDamageTime;

        // Initialize damageable object
        public Damageable(double recoveryTimeInterval = 0, int maxHealth = 1)
        {
            this.recoveryTimeInterval = recoveryTimeInterval;
            damage = new Damage(maxHealth);
            currentTime = nextDamageTime = 0;
        }

        public void Update(GameTime gameTime)
        {
            currentTime += gameTime.ElapsedGameTime.TotalSeconds;
        }

        // Set health values based on amount of damage 
        public void TakeDamage(int damage,Direction direction)
        {
            if (Vulnerable)
            {
                CurrentHealth -= damage;
                nextDamageTime = currentTime + recoveryTimeInterval;
            }
        }

        public void Heal(int health)
        {
            CurrentHealth += health;
        }
    }
}
