using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace GG3902
{
    public class Room
    {
        private XmlParser parser;
        public int roomNumber;
        private string filepath;
        private string filename;
        public List<object> roomObjects;
        public Dictionary<Direction, int> neighbors;
        private Vector2 offset;

        public Room(int roomNumber)
        {
            // Saves filepath and generates parser
            roomObjects = null;
            this.roomNumber = roomNumber;
            parser = new XmlParser(new Type[] { typeof(Player), typeof(Enemy), typeof(ItemPickup), typeof(Tile), typeof(Door), typeof(Locale) });
            filename = "Room" + this.roomNumber + ".xml";
            filepath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/Source/Level/";
        }

        public void BuildRoomFromScratch()
        {
            // Generates objects from xml file and adds locale data
            roomObjects = parser.CreateObjectsFromXml(filepath + filename);
            foreach (object obj in roomObjects)
            {
                if (obj is Locale)
                {
                    offset = (obj as Locale).offset;
                    neighbors = (obj as Locale).neighbors;
                }
            }

            // Offsets each entity in the room to be aligned with the room's locale
            foreach (object obj in roomObjects)
            {
                if (obj is IEntity)
                    (obj as IEntity).Position += offset;
            }
        }

        public void BuildRoomFromSave(List<object> newObjects)
        {
            // Sets new room data and adds each object to its respective lists
            roomObjects = newObjects;
            foreach (object obj in roomObjects)
            {
                EntityManager.Instance.RegisterEntity(obj as IEntity);
            }
        }

        public void RemoveObject(object obj)
        {
            if (roomObjects.Contains(obj))
                roomObjects.Remove(obj);
        }
    }
}
