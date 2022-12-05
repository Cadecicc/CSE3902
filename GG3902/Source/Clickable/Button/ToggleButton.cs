using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;

namespace GG3902
{
    public class ToggleButton : Entity, IClickable
    {
        private int spriteWidth = 50;
        private int spriteHeight = 50;
        private string onState;
        private string offState;
        private string currentState;
        private string type;
        private ISprite onSprite;
        private ISprite offSprite;


        public int SpriteWidth
        {
            get { return spriteWidth; }
            set { spriteWidth = value; }
        }
        public int SpriteHeight
        {
            get { return spriteHeight; }
            set { spriteHeight = value; }
        }

        private ICollider Collider { get; set; }

        public ISprite CurrentSprite
        {
            get => GetComponent<ISprite>();
            set => SetComponent(value);
        }


        public string OnState
        {
            get
            {
                return onState;
            }
        }

        public string OffState
        {
            get
            {
                return offState;
            }
        }

        public string CurrentState
        {
            get
            {
                return currentState;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
        }

        public ToggleButton(string type,string onType, string offType, Vector2 startingPosition)
        {
            this.type = type;
            this.offState = offType;
            this.onState = onType;
            currentState = offType;
            Position = startingPosition;
            onSprite = new Sprite(TextureManager.Instance.GetTexture(OnState), new Rectangle(0, 0, spriteWidth, spriteHeight), 1, 0.01f);
            offSprite = new Sprite(TextureManager.Instance.GetTexture(offState), new Rectangle(0, 0, spriteWidth, spriteHeight), 1, 0.01f);
        }

        public override void Initialize()
        {
            Collider = new Collider(this, new Point(50, 50));
            CheckButtonType();
        }

        public void ToggleButtonOn()
        {      
                currentState = OnState;
                CurrentSprite = onSprite;
        }

        public void ToggleButtonOff()
        {
            currentState = OffState;
            CurrentSprite = offSprite;
        }

        public bool IsClicked(Vector2 mousePosition)
        {
            return Collider.Hitbox.Contains(mousePosition);
        }
        public void CheckButtonType()
        {
            if (Type.Equals("ToggleMuteSongButton"))
            {
                if(MediaPlayer.IsMuted)
                {
                    CurrentSprite = onSprite;
                } 
                else
                {
                    CurrentSprite = offSprite;
                }
            } 
            else if (Type.Equals("ToggleMuteSoundButton"))
            {
                if(SoundManager.isMuted)
                {
                    CurrentSprite = onSprite;
                }
                else
                {
                    CurrentSprite = offSprite;
                }
            }
        }
    }
}
