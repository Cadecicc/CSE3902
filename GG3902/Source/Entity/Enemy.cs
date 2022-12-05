using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;

namespace GG3902
{
    public class Enemy : Entity, ICollideable, IDamageable
    {
        private SoundEffect soundEffect;
        private ItemPickup itemPickup;

        private IAnimation Animation
        {
            get => GetComponent<IAnimation>();
            set => SetComponent(value);
        }
        private IState State
        {
            get => GetComponent<IState>();
            set => SetComponent(value);
        }
        private Damageable Damageable
        {
            get => GetComponent<Damageable>();
            set => SetComponent(value);
        }

        public ICollider Collider { get; set; }
        public int CurrentHealth => Damageable?.CurrentHealth ?? 0;
        public int MaxHealth { get => Damageable.MaxHealth; set => Damageable.MaxHealth = value; }

        public event Action<string> OnDeath;

        public Enemy(Vector2 startingPosition, string type)
        {
            Position = startingPosition;
            Name = type;
        }

        public override void Initialize()
        {
            if (Name == "Walker")
            {
                State = new WalkerEnemyState(this);
                Damageable = new Damageable(0, 3);
            }
            else if (Name == "Spitter")
            {
                State = new SpitterEnemyState(this);
                Damageable = new Damageable(0, 3);
            }
            else if (Name == "Tank")
            {
                State = new TankEnemyState(this);
                Damageable = new Damageable(0, 6);
            }
            else if (Name == "Runner")
            {
                State = new RunnerEnemyState(this);
                Damageable = new Damageable(0, 2);
            }
            else
            {
                State = new MoveShootEnemyState(this);
                Damageable = new Damageable(0, 1);
            }
            Collider = new Collider(this, new Point(60, 60));
            Animation = AnimationFactory.LoadAnimation(Name + "DownMoving");

            
        }

        /*
         * Methods for managing an enemy's animation state.
         */

        public void SetAnimation(string animationName)
        {
            Animation = AnimationFactory.LoadAnimation(Name + animationName);
        }

        public void PlayAnimation()
        { 
            Animation.Playing = true;
        }

        public void StopAnimation()
        {
            Animation.Playing = false;
        }

        public bool HasAnimationEnded()
        {
            return Animation.HasLooped;
        }

        /*
         * Methods for managing an enemy's damageable state.
         */

        public void TakeDamage(int damage,Direction direction)
        {
            Damageable?.TakeDamage(damage,direction);

            if (CurrentHealth < 1)
                Die();
        }

        public void Heal(int health)
        {
            Damageable.Heal(health);
        }

        public void Die()
        {
            soundEffect = SoundEffectFactory.LoadSoundEffect("enemyDying");
            if (!SoundManager.isMuted)
                soundEffect.Play();
            DropItem();
            this.DeleteSelf();
            OnDeath?.Invoke(Name);
        }

        public void DropItem()
        {
            string itemType;

            Random rand = new Random();
            int itemNum = rand.Next() % 6;

            if (itemNum == 0)
                itemType = "Heart_Small";
            else if (itemNum == 1 || itemNum == 2)
                itemType = "BulletUpMoving";
            else
                return;

            itemPickup = new ItemPickup(Position, itemType);
            itemPickup.Initialize();
        }
    }
}
