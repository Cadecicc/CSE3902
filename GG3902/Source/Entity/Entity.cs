using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

namespace GG3902
{
    // An entity is anything that can be drawn and updated with respect to game time.
    public abstract class Entity : IEntity
    {
        private EntityManager manager;
        private int id = -1;

        public virtual Vector2 Position
        {
            get { return position; }
            set
            {
                position = value;
                OnPositionChange?.Invoke(this);
            }
        }

        private Vector2 position;

        public string Name { get; set; }
        public int Id => id;

        public event Action<Entity> OnPositionChange;

        public Entity()
        {
            manager = EntityManager.Instance;
            id = manager.RegisterEntity(this);
        }

        /*
         * Methods allowing for an entity to manage its components.
         */

        public T GetComponent<T>() where T : IComponent
        {
            return manager.GetComponent<T>(id);
        }

        public void SetComponent<T>(T component) where T : IComponent
        {
            manager.SetComponent(id, component);
        }

        public void RemoveComponent<T>() where T : IComponent
        {
            manager.RemoveComponent<T>(id);
        }

        // All classes extending from entity must implemented this method as it will uniquely define them as an entity.
        public abstract void Initialize();
    }
}
