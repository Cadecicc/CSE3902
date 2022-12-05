using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GG3902
{
    public class Animation : IAnimation, ICloneable
    {
        private int drawCallCounter;
        private int frameCounter;

        private ISprite[] frames;
        private int drawCallsPerFrame;

        private ISprite CurrentFrame => frames[FrameCounter];
        private int FrameCounter
        {
            get => frameCounter;
            set
            {
                if (value >= frames.Length)
                {
                    value = 0;
                    HasLooped = true;
                }
                frameCounter = value;
            }
        }
        private int DrawCallCounter { get => drawCallCounter; set => drawCallCounter = value %= drawCallsPerFrame; }

        public bool HasLooped { get; private set; }
        public bool Playing { get; set; }

        public Animation(ISprite[] frames, int drawCallsPerFrame)
        {
            Reset();
            this.frames = frames;
            this.drawCallsPerFrame = drawCallsPerFrame;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            CurrentFrame.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            // Still not technically right, need a delta time instead
            if (Playing && ++DrawCallCounter % drawCallsPerFrame == 0)
                FrameCounter++;
        }

        public void Reset()
        {
            drawCallCounter = 0;
            frameCounter = 0;
            HasLooped = false;
            Playing = true;
        }

        public object Clone()
        {
            return new Animation((ISprite[])frames.Clone(), drawCallsPerFrame);
        }
    }
}
