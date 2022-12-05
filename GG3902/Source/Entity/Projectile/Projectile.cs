using Microsoft.Xna.Framework;

namespace GG3902
{
    public class Projectile : Entity, ICollideable, IAnimated
    {
        private string type;
        private IState initialState;
        private ProjectileMovement movement;
        private Direction facingDir;
        private bool hasExploded;
        private bool IsEnemy;
        private int damage;
        private bool destroyOnContact;

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
        public ICollider Collider { get; set; }

        public string Type => type;
        public bool IsExploding { get; }
        public bool HasExploded => hasExploded;
        public IEntity Parent { get; set; }
        public int Damage => damage;
        public bool DestroyOnContact => destroyOnContact;
        public Vector2 Direction { get => movement.Direction; set => movement.Direction = value; }

        public Projectile(Vector2 position, Vector2 direction, string type, bool isExploding, double lifeSpanInSeconds, MovementStrategy movementBehaviour, bool IsEnemy, int damage = 1, bool destroyOnContact = true)
        {
            facingDir = direction.ToDirection();
            Position = position;
            this.type = type;
            IsExploding = isExploding;
            initialState = new ProjectileState(this, lifeSpanInSeconds);
            movement = new ProjectileMovement(this, direction, movementBehaviour);
            this.IsEnemy = IsEnemy;
            this.damage = damage;
            this.destroyOnContact = destroyOnContact;
            Initialize();
        }

        public override void Initialize()
        {
            hasExploded = false;
            Collider = new Collider(this, new Point(60, 60));
            SetState(initialState);
            SetComponent(movement as IMovement);
        }

        public void Explode()
        {
            if (hasExploded)
                return;

            damage = 0;
            SetState(new ExplodeProjectileState(this));
            hasExploded = true;
        }

        public void SetAnimation(string animationName)
        {
            Animation = AnimationFactory.LoadAnimation(animationName);
        }

        public void PlayAnimation() { }

        public void StopAnimation() { }

        public bool HasAnimationEnded() => Animation.HasLooped;

        public Direction GetDirection() => facingDir;

        private void SetState(IState state)
        {
            State?.Exit();
            State = state;
            state.Enter();
        }

        public bool IsEnemyProjectile()
        {
            return IsEnemy;
        }
    }
}
