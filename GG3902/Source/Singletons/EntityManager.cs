using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace GG3902
{
    // Class used to keep track of all entities and their components.
    public class EntityManager
    {
        /*
         * lastIdUsed = last ID used by any entity, ensuring a unique ID for all entities,
         * entities = list of all entities and their IDs,
         * persistentEntityIds = list of entity IDs that persist when all other entities are reset,
         * mapOfComponentMaps = maps types to lists of entity IDs and their corresponding components,
         * updateQueue = a queue for updating component and entity lists (used to avoid modifying a collection during iteration)
         */
        private int lastIdUsed;
        private Dictionary<int, IEntity> entities;
        private HashSet<int> persistentEntityIds;
        private Dictionary<Type, Dictionary<int, IComponent>> mapOfComponentMaps;


        // Variables used to update entities and their components without modifying the collection during iteration.
        private Queue<Action> updateQueue;
        private bool isIterating;

        public IEnumerable<IDamageable> Damageables => GetEntityList<IDamageable>();
        public IEnumerable<ICollideable> Collideables => GetEntityList<ICollideable>();
        public IEnumerable<IEntity> Entities => GetEntityList<IEntity>();
        public IEnumerable<IClickable> Clickables => GetEntityList<IClickable>();
        public IEnumerable<Player> Players => GetEntityList<Player>();
        public List<Enemy> Enemies => GetEntityList<Enemy>();

        public static EntityManager Instance { get; } = new EntityManager();

        private EntityManager()
        {
            lastIdUsed = -1;
            entities = new Dictionary<int, IEntity>();
            persistentEntityIds = new HashSet<int>();
            mapOfComponentMaps = new Dictionary<Type, Dictionary<int, IComponent>>();
            updateQueue = new Queue<Action>();
        }

        /*
         * Methods for managing all entities at once.
         */

        public void Reset()
        {
            lastIdUsed = -1;
            entities = new Dictionary<int, IEntity>();
            persistentEntityIds = new HashSet<int>();
            mapOfComponentMaps = new Dictionary<Type, Dictionary<int, IComponent>>();
            updateQueue = new Queue<Action>();
        }

        public void Initialize()
        {
            // This line of code seems pretty hacky but it's necessary to avoid a null reference error when loading rooms.
            FlushUpdateQueue();

            foreach (IEntity entity in entities.Values)
                entity.Initialize();
        }

        public void Clear()
        {
            Dictionary<int, IEntity> newEntityList = new Dictionary<int, IEntity>();

            mapOfComponentMaps.Clear();
            foreach (KeyValuePair<int, IEntity> entity in entities)
                if (persistentEntityIds.Contains(entity.Key))
                    newEntityList.Add(entity.Key, entity.Value);

            entities = newEntityList;
        }

        /*
         * Methods for the management of individual entities.
         */

        public int RegisterEntity(IEntity entity)
        {
            int currentId;
            if (entity.Id > -1)
            {
                currentId = entity.Id;
            }
            else
            {
                currentId = lastIdUsed++;
            }
            entities.Add(currentId, entity);
            return currentId;
        }

        public void RemoveEntity(int id)
        {
            TryActionOrEnqueue(() => entities.Remove(id));

            foreach (Dictionary<int, IComponent> componentMap in mapOfComponentMaps.Values)
                TryActionOrEnqueue(() => componentMap.Remove(id));
        }

        public void PersistEntity(int id)
        {
            persistentEntityIds.Add(id);
        }

        public Vector2 DirectionToLink()
        {
            Vector2 directionToLink = Vector2.Zero;
            foreach (IEntity entity in entities.Values)
            {
                if (entity.GetType().Equals(typeof(Player)))
                {
                    directionToLink = (entity as Player).Position;
                }
            }

            return directionToLink;
        }

        /*
         * Methods for updating and drawing components.
         */

        public void Update(GameTime gameTime)
        {
            isIterating = true;
            foreach (Dictionary<int, IComponent> componentMaps in mapOfComponentMaps.Values)
                foreach (IComponent component in componentMaps.Values)
                    component.Update(gameTime);
            isIterating = false;

            FlushUpdateQueue();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (KeyValuePair<Type, Dictionary<int, IComponent>> componentMaps in mapOfComponentMaps)
            {
                if (!typeof(IDrawableComponent).IsAssignableFrom(componentMaps.Key))
                    continue;

                foreach (KeyValuePair<int, IComponent> component in componentMaps.Value)
                {
                    Vector2 position;
                    if (entities.ContainsKey(component.Key))
                    {
                        position = entities[component.Key].Position;
                        (component.Value as IDrawableComponent)?.Draw(spriteBatch, position);
                    }
                }
            }
        }

        /*
         * Methods for adding, overriding, and removing components.
         */

        public T GetComponent<T>(int id) where T : IComponent
        {
            if (mapOfComponentMaps.TryGetValue(typeof(T), out Dictionary<int, IComponent> value))
                if (value.TryGetValue(id, out IComponent component))
                    return (T)component;
            return default;
        }

        public void SetComponent<T>(int id, T component) where T : IComponent
        {
            Type type = typeof(T);

            if (!mapOfComponentMaps.ContainsKey(type))
                TryActionOrEnqueue(() => mapOfComponentMaps.TryAdd(type, new Dictionary<int, IComponent>()));
            TryActionOrEnqueue(() => mapOfComponentMaps[type][id] = component);
        }

        public void RemoveComponent<T>(int id) where T : IComponent
        {
            if (mapOfComponentMaps.TryGetValue(typeof(T), out Dictionary<int, IComponent> value))
                TryActionOrEnqueue(() => value.Remove(id));
        }

        // Returns a collection of entities that are of the generic type
        private List<T> GetEntityList<T>()
        {
            List<T> list = new List<T>();
            foreach (IEntity entity in entities.Values)
                if (entity is T)
                    list.Add((T)entity);
            return list;
        }

        /*
         * If the the list of components or entities is currently being iterated, adds the action to a queue.
         * Otherwise, invokes it immediately.
         */
        private void TryActionOrEnqueue(Action action)
        {
            if (isIterating)
                updateQueue.Enqueue(action);
            else
                action.Invoke();
        }

        // Helper method to flush the update queue.
        private void FlushUpdateQueue()
        {
            while (updateQueue.TryDequeue(out Action action)) action.Invoke();
        }
    }
}
