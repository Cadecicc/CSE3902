using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace GG3902
{
    public class Collider : ICollider
    {
        private Point location;
        private Point bounds;
        private Entity parent;

        public Rectangle Hitbox
        {
            get
            {
                if (parent is Tile)
                    location = new Point((int)parent.Position.X, (int)parent.Position.Y);
                else if (parent is Door)
                    location = new Point((int)parent.Position.X, (int)parent.Position.Y - (bounds.Y / 2));
                else if (parent is Button || parent is ToggleButton)
                    location = new Point((int)(parent.Position.X - (bounds.X / 2)), (int)(parent.Position.Y - (bounds.Y /2)));
                else
                    location = new Point((int)(parent.Position.X - (bounds.X / 2)), (int)(parent.Position.Y + (bounds.Y / 2)));
                return new Rectangle(location, bounds);
            }
        }

        public Collider(Entity parent, Point bounds)
        {
            this.parent = parent;
            this.bounds = bounds;
        }
    }
}
