using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace GG3902
{
    public class TextureManager
    {
        private static TextureManager instance = new TextureManager();

        private Dictionary<string, Texture2D> textureMap;

        public static TextureManager Instance => instance;

        private TextureManager()
        {
            textureMap = new Dictionary<string, Texture2D>();
        }
        public void Reset()
        {
            textureMap = new Dictionary<string, Texture2D>();
        }

        public void LoadTexture(string textureName, string filepath, ContentManager contentManager)
        {
            textureMap.Add(textureName, contentManager.Load<Texture2D>(filepath));
        }

        public void UnloadTexture(string textureName)
        {
            textureMap.Remove(textureName);
        }

        public Texture2D GetTexture(string textureName)
        {
            return textureMap[textureName];
        }
    }
}
