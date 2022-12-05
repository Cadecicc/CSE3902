using Microsoft.Xna.Framework;

namespace GG3902
{
    public struct Collision
    {
        public Direction Direction { get; set; }
        public ICollideable Collider { get; set; }
        public ICollideable Collidee { get; set; }
        public Rectangle Overlap { get; set; }
    }
}
