using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace GG3902
{
    public class Map
    {
        private static Vector2 outOfSight = new Vector2(1000000, 10000000);

        private UIElement baseMap;
        private UIElement map;
        private UIElement compass;

        // Room UI elements
        private UIElement firstRoom;
        private UIElement secondRoom;
        private UIElement thirdRoom;
        private UIElement fourthRoom;
        private UIElement fifthRoom;
        private UIElement sixthRoom;
        private UIElement seventhRoom;
        private UIElement eighthRoom;
        private UIElement ninthRoom;
        private UIElement tenthRoom;

        private Vector2 baseMapOffset;
        private Vector2 mapOffset;
        private Vector2 compassOffset;

        // Room offsets
        private Vector2 firstRoomOffset;
        private Vector2 secondRoomOffset;
        private Vector2 thirdRoomOffset;
        private Vector2 fourthRoomOffset;
        private Vector2 fifthRoomOffset;
        private Vector2 sixthRoomOffset;
        private Vector2 seventhRoomOffset;
        private Vector2 eighthRoomOffset;
        private Vector2 ninthRoomOffset;
        private Vector2 tenthRoomOffset;

        public bool HasMap => map != null;
        public bool HasCompass => compass != null;

        public Map()
        {
            baseMap = new UIElement("BaseMap");

            firstRoom = new UIElement("Top_and_Right_Door");
            secondRoom = new UIElement("Top_and_Left_Door");
            thirdRoom = new UIElement("Bottom_and_Left_Doors");
            fourthRoom = new UIElement("Top_Bottom_and_Right_Doors");
            fifthRoom = new UIElement("Top_and_Bottom_Door");
            sixthRoom = new UIElement("Top_Bottom_and_Right_Doors");
            seventhRoom = new UIElement("Top_Bottom_and_Right_Doors");
            eighthRoom = new UIElement("Bottom_Door");
            ninthRoom = new UIElement("Top_and_Left_Door");
            tenthRoom = new UIElement("Bottom_and_Left_Doors");

            map = null;
            compass = null;
            
            baseMapOffset = new Vector2(0, 352 + 292);
            mapOffset = new Vector2(-304, 692);
            compassOffset = new Vector2(-308, 532);

            firstRoomOffset = new Vector2(112, 352 + 196);
            secondRoomOffset = new Vector2(144, 352 + 196);
            thirdRoomOffset = new Vector2(144, 352 + 196 + 32);
            fourthRoomOffset = new Vector2(112, 352 + 196 + 32);
            fifthRoomOffset = new Vector2(112, 352 + 196 + 64);
            sixthRoomOffset = new Vector2(112, 352 + 196 + 96);
            seventhRoomOffset = new Vector2(112, 352 + 196 + 128);
            eighthRoomOffset = new Vector2(112, 352 + 196 + 160);
            ninthRoomOffset = new Vector2(144, 352 + 196 + 96);
            tenthRoomOffset = new Vector2(144, 352 + 196 + 128);

        }

        public void AddMap()
        {
            if (HasMap)
                return;

            map = new UIElement("Map");
            EntityManager.Instance.PersistEntity(map.Id);
        }

        public void AddCompass()
        {
            if (HasCompass)
                return;

            compass = new UIElement("Compass");
            EntityManager.Instance.PersistEntity(compass.Id);
        }

        // Sets the map position to match the camera's position
        public void SetPosition(Vector2 cameraPosition)
        {
            baseMap.Position = cameraPosition + baseMapOffset;
            if (HasMap)
            {
                map.Position = cameraPosition + mapOffset;

                // Set room positions
                firstRoom.Position = cameraPosition + firstRoomOffset;
                secondRoom.Position = cameraPosition + secondRoomOffset;
                thirdRoom.Position = cameraPosition + thirdRoomOffset;
                fourthRoom.Position = cameraPosition + fourthRoomOffset;
                fifthRoom.Position = cameraPosition + fifthRoomOffset;
                sixthRoom.Position = cameraPosition + sixthRoomOffset;
                seventhRoom.Position = cameraPosition + seventhRoomOffset;
                eighthRoom.Position = cameraPosition + eighthRoomOffset;
                ninthRoom.Position = cameraPosition + ninthRoomOffset;
                tenthRoom.Position = cameraPosition + tenthRoomOffset;
            }
            else
            {
                // Set room positions
                firstRoom.Position = outOfSight;
                secondRoom.Position = outOfSight;
                thirdRoom.Position = outOfSight;
                fourthRoom.Position = outOfSight;
                fifthRoom.Position = outOfSight;
                sixthRoom.Position = outOfSight;
                seventhRoom.Position = outOfSight;
                eighthRoom.Position = outOfSight;
                ninthRoom.Position = outOfSight;
                tenthRoom.Position = outOfSight;
            }

            if (HasCompass)
                compass.Position = cameraPosition + compassOffset;
        }
    }
}