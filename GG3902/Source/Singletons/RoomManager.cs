using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GG3902
{
    public class RoomManager
    {
        // List of rooms with integer for indexing
        private Dictionary<int, Room> rooms;
        // Current room that is being played in
        private int currentRoom;

        public static RoomManager Instance { get; } = new RoomManager();

        private RoomManager()
        {
            // Initialize
            rooms = new Dictionary<int, Room>();
            Initialize();
        }

        public void Reset()
        {
            rooms = new Dictionary<int, Room>();
            Initialize();
        }

        public void Initialize()
        {
            // Fills room list with initialized rooms and empty object lists
            for (int i = 1; i <= 11; i++)
            {
                rooms.Add(i, new Room(i));
            }
            currentRoom = 1;
        }

        // Returns whether or not the direction goes to a valid room or not
        // If it does, the current room is switched to the new one and its data is saved
        public bool SwitchRooms(Direction direction)
        {
            // Calculates room number to transition into
            int tempRoom = rooms[currentRoom].neighbors[direction];
            if (tempRoom != 0)
            {
                // Iterates through all objects to check what still exists in the room 
                List<object> temp = new List<object>();
                foreach (IEntity entity in EntityManager.Instance.Entities)
                {
                    if (rooms[currentRoom].roomObjects.Contains(entity))
                        temp.Add(entity);
                }

                // Saves the data to the room's object list
                rooms[currentRoom].roomObjects = temp;

                currentRoom = tempRoom;
                return true;
            }
            else
                return false;
        }

        public void LoadRoom()
        {
            // Builds room either from xml or from previously saved object list
            if (rooms[currentRoom].roomObjects == null)
                rooms[currentRoom].BuildRoomFromScratch();
            else
                rooms[currentRoom].BuildRoomFromSave(rooms[currentRoom].roomObjects);
        }
    }
}
