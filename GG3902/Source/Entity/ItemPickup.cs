using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace GG3902
{
    public class ItemPickup : Entity, ICollideable
    {
        private string type;

        private IAnimation Animation
        {
            get => GetComponent<IAnimation>();
            set => SetComponent(value);
        }

        private SoundEffect soundEffect;

        public ICollider Collider { get; set; }
        public string Type => type;

        public ItemPickup(Vector2 startingPosition, string type) : base()
        {
            Position = startingPosition;
            this.type = type;
        }

        public override void Initialize()
        {
            Collider = new Collider(this, new Point(40, 60));
            Animation = AnimationFactory.LoadAnimation(type);
            soundEffect = SoundEffectFactory.LoadSoundEffect("linkPickupItem");
        }

        public void Remove()
        {
            if (type == "Heart_Small" || type == "Heart_Big")
            {
                soundEffect = SoundEffectFactory.LoadSoundEffect("linkPickupHeart");
            } else if (type == "Rupee_1" || type == "Rupee_5")
            {
                soundEffect = SoundEffectFactory.LoadSoundEffect("linkPickupRupee");
            }
            if (!SoundManager.isMuted)
                soundEffect.Play();
            EntityManager.Instance.RemoveEntity(Id);
        }

        public void SetAnimation(string animationName)
        {
            Animation = AnimationFactory.LoadAnimation(animationName);
        }

        public void PlayAnimation()
        {
            Animation.Playing = true;
        }

        public void StopAnimation()
        {
            Animation.Playing = false;
        }
    }
}
