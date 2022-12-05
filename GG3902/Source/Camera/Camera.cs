using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GG3902
{
    public class Camera
    {
        private static Vector2 WorldPositionTranslation = new Vector2(1f, -1f);

        public Vector2 Position { get; private set; }

        public Vector2 WorldPosition => Position * WorldPositionTranslation;

        public int ViewportWidth { get; set; }

        public int ViewportHeight { get; set; }

        public Camera() { }

        public Vector2 ViewportCenter
        {
            get
            {
                return new Vector2(ViewportWidth * 0.5f, ViewportHeight * 0.5f);
            }
        }

        // Called by spritebatch to offset everything drawn on the screen
        public Matrix TranslationMatrix
        {
            get
            {
                return Matrix.CreateTranslation(-(int)Position.X, -(int)Position.Y, 0)
                    * Matrix.CreateTranslation(new Vector3(ViewportCenter, 0));
            }
        }

        public void MoveCamera(Vector2 cameraMovement)
        {
            Position += cameraMovement;
        }

        public void CenterOn(Vector2 position)
        {
            Position = position;
        }

        public Vector2 ScreenToWorldSpace(in Vector2 point)
        {
            Matrix invertedMatrix = Matrix.Invert(TranslationMatrix);
            return Vector2.Transform(point, invertedMatrix) * WorldPositionTranslation;
        }
    } 
}
