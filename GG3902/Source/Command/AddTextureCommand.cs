using Microsoft.Xna.Framework.Content;

namespace GG3902
{
    public class AddTextureCommand : ICommand
    {
        private string textureName;
        private string filepath;
        private ContentManager contentManager;
        private bool isPersistent;

        public AddTextureCommand(string textureName, string filepath, ContentManager contentManager, bool isPersistent = false)
        {
            this.textureName = textureName;
            this.filepath = filepath;
            this.contentManager = contentManager;
            this.isPersistent = isPersistent;
        }

        public void Execute()
        {
            TextureManager.Instance.LoadTexture(textureName, filepath, contentManager);
        }

        public void Undo()
        {
            if (!isPersistent)
                TextureManager.Instance.UnloadTexture(textureName);
        }
    }
}
