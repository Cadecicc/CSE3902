using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GG3902
{
    // Warning: This class is quite large
    public class Player : Entity, IAnimated, ICollideable, IDamageable
    {
        private static readonly int magicNumber = 87;

        public static readonly List<string> Guns = new List<string>()
        {
            "Pistol",
            "Shotgun",
            "AR",
            "Sniper",
            "SawbladeGun",
            "Rocket Launcher",
            "MachineGun",
            "Finger"
        };

        /*
         * movingDir = a combination of all the player's direction change commands,
         * isBusy = true if the player is in a non interruptible state (such as attacking or being dead)
         */
        public Vector2 startingPosition;
        private Vector2[] axes;
        private string currentAnimation;
        private bool hasDied;

        /*
         * Inventory variables.
         */
        private string[] inventory;
        private int currentItemIndex;
        private int[] ammo;

        private IAnimation Animation
        {
            get => GetComponent<IAnimation>();
            set => SetComponent(value);
        }
        private IMovement Movement
        {
            get => GetComponent<IMovement>();
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
        private Vector2 MovingDir
        {
            get
            {
                Vector2 dirVector = Vector2.Zero;
                foreach (Vector2 vec in axes)
                    dirVector += vec;
                return dirVector;
            }
        }

        public ICollider Collider { get; set; }
        public int CurrentHealth => Damageable?.CurrentHealth ?? 0;
        public int MaxHealth { get => Damageable.MaxHealth; set => Damageable.MaxHealth = value; }
        public bool HasDied => hasDied;
        public Vector2 Rotation =>  Vector2.Normalize(MouseController.MousePositionInWorld() - Position);

        public event Action<string> OnAddItem;
        public event Action<int> OnTakeDamage;
        public event Action<int, string> OnItemSwitch;

        public Player(Vector2 startingPosition) : base()
        {
            EntityManager.Instance.PersistEntity(Id);

            Position = startingPosition;

            inventory = new string[8];
            ammo = new int[8];
            axes = new Vector2[4];
            currentItemIndex = 0;

            // Test inventory
            inventory[0] = "Pistol";
            ammo[0] = GunFactory.GetCapacity("Pistol");
        }

        // Sets the player's initial state and loads its animation data
        public override void Initialize()
        {
            currentAnimation = "PlayerDownMoving";
            hasDied = false;
            Collider = new Collider(this, new Point(32, 32));
            Movement = new Movement(this, 350);
            Animation = AnimationFactory.LoadAnimation(currentAnimation);
            State = new MovePlayerState(this);
            Damageable = new Damageable(1, 6);
        }

        public void SetState(IState state)
        {
            if (!(state is DeadPlayerState) && (State as BusyPlayerState)?.IsBusy == true)
                return;
            State.Exit();
            State = state;
            state.Enter();
        }

        public void SetPosition(Vector2 position)
        {
            Position = position;
        }

        /*
         * Methods for managing the player's combat state.
         */

        public void TakeDamage(int damage,Direction direction)
        {
            if (HasDied || !Damageable.Vulnerable)
                return;

            
            Damageable.TakeDamage(damage,direction);
            OnTakeDamage?.Invoke(CurrentHealth);
            SetState(new DamagedPlayerState(this,direction));

            if (CurrentHealth < 1)
                Die();
        }

        public void Heal(int health)
        {
            if (hasDied)
                return;

            Damageable.Heal(health);
            OnTakeDamage.Invoke(CurrentHealth);
        }

        public void Die()
        {
            DeadPlayerState deadPlayerState = new DeadPlayerState(this);
            SetState(deadPlayerState);
            deadPlayerState.OnAnimationEnd += () => hasDied = true;
        }

        public void Attack()
        {
            SetState(new AttackPlayerState(this));
        }

        /*
         * Methods for managing the player's animation state.
         */

        public void SetAnimation(string animationName)
        {
            if (animationName.Equals(currentAnimation))
                return;
            Animation = AnimationFactory.LoadAnimation(currentAnimation = animationName);
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
         * Methods for managing the player's movement state.
         */

        public void Stop()
        {
            for (int i = 0; i < axes.Length; i++)
                axes[i] = Vector2.Zero;
        }

        public void Push(Direction direction)
        {
            axes[(int)direction] = direction.ToVector();
            SetVelocity();
        }

        public void Pull(Direction direction)
        {
            axes[(int)direction] = Vector2.Zero;
            SetVelocity();
        }

        private void SetVelocity()
        {
            Movement.Velocity = MovingDir * Movement.MaxSpeed;
        }

        public Direction GetDirection()
        {
            Direction dir;
            float normalUnitSideLen = 1 / MathF.Sqrt(2);

            if (Rotation.X > normalUnitSideLen)
                dir = Direction.Right;
            else if (Rotation.Y > normalUnitSideLen)
                dir = Direction.Up;
            else if (Rotation.X < -normalUnitSideLen)
                dir = Direction.Left;
            else
                dir = Direction.Down;
            return dir;
        }

        public bool IsMoving()
        {
            return Movement.IsMoving();
        }

        /*
         * Methods for managing the player's inventory.
         */

        public void AddItem(string item)
        {
            if (GunFactory.IsAGun(item))
            {
                inventory[Guns.IndexOf(item)] = item;
                while (!inventory[currentItemIndex].Equals(item))
                {
                    SwitchActiveItem();
                }
                ammo[currentItemIndex] = GunFactory.GetCapacity(item) / 2;
            }
            else if (item.Equals("Heart_Small"))
            {
                Heal(2);
            }
            else if (item.Equals("Heart_Big"))
            {
                if (MaxHealth < 32)
                    MaxHealth += 2;
            }
            else if (item.Equals("BulletUpMoving"))
            {
                //Add half of max capacity for CURRENT gun
                string currGun = inventory[currentItemIndex];
                ammo[currentItemIndex] = Math.Min(ammo[currentItemIndex] + GunFactory.GetCapacity(currGun) / 2, GunFactory.GetCapacity(currGun)); 
            }
            OnAddItem?.Invoke(item);
        }

        public void Debug_AddItems()
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == null)
                {
                    AddItem(Guns[i]);
                }
            }
        }

        public void UseGunYeehaw()
        {
            if (currentItemIndex == -1)
                return;

            if (State is ShootPlayerState)
                (State as ShootPlayerState).IsShooting = true;
            else
                SetState(new ShootPlayerState(this, inventory[currentItemIndex]));
        }

        public void HolsterGun()
        {
            ShootPlayerState state = State as ShootPlayerState;
            if (state == null)
                return;

            state.IsShooting = false;
        }

        public int GetAmmo()
        {
            return ammo[currentItemIndex];
        }

        public void SetAmmo(int amount)
        {
            ammo[currentItemIndex] = amount;
        }

        public void SwitchActiveItem()
        {
            if (State is ShootPlayerState)
                SetState(new MovePlayerState(this));

            int newIndex = Math.Max(0, currentItemIndex);
            for (int i = 0; i < inventory.Length; i++)
            {
                newIndex = (newIndex + 1) % inventory.Length;
                if (inventory[newIndex] != null)
                {
                    currentItemIndex = newIndex;
                    OnItemSwitch?.Invoke(currentItemIndex, inventory[currentItemIndex]);
                    break;
                }
            }
        }

    }
}
