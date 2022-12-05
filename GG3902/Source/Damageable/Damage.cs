namespace GG3902
{
    public class Damage : IDamage
    {
        private int currentHealth;
        private int maxHealth;

        public int MaxHealth
        {
            get => maxHealth;
            set
            {
                maxHealth = value;
                CurrentHealth = CurrentHealth;
            }
        }

        // Set current health within the acceptable scope 
        public int CurrentHealth
        {
            get => currentHealth;
            set
            {
                currentHealth = value;
                if (currentHealth > MaxHealth)
                    currentHealth = MaxHealth;
                else if (currentHealth < 0)
                    currentHealth = 0;
            }
        }

        // Initialize damageable object
        public Damage(int maxHealth)
        {
            currentHealth = maxHealth;
            MaxHealth = maxHealth;
        }
    }
}
