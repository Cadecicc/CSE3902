using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace GG3902
{
    public class Inventory
    {
        private static Vector2 outOfSight = new Vector2(1000000, 10000000);

        private UIElement baseInventory;

        // Item UI elements
        private UIElement activeItem;
        private UIElement selector;
        private UIElement shotgun;
        private UIElement pistol;
        private UIElement AR;
        private UIElement sniper;
        private UIElement sawbladeGun;
        private UIElement rocketLauncher;
        private UIElement machineGun;
        private UIElement finger;

        // Item offsets
        private Vector2 baseInventoryOffset;
        private Vector2 activeItemOffset;
        private Vector2 selectorOffset;

        private Dictionary<UIElement, Vector2> offsets;

        public Inventory()
        {
            baseInventory = new UIElement("BaseInventory");
            activeItem = new UIElement("");
            selector = new UIElement("RedCursor");
            pistol = new UIElement("Pistol");
            shotgun = new UIElement("Shotgun");
            AR = new UIElement("AR");
            sniper = new UIElement("Sniper");
            sawbladeGun = new UIElement("SawbladeGun");
            rocketLauncher = new UIElement("Rocket Launcher");
            machineGun = new UIElement("MachineGun");
            finger = new UIElement("Finger");

            baseInventoryOffset = new Vector2(0, 352 + 292 + 352);

            offsets = new Dictionary<UIElement, Vector2>()
            {
                { pistol, new Vector2(32, -48) },
                { shotgun, new Vector2(128, -48) },
                { AR, new Vector2(224, -48) },
                { sniper, new Vector2(320, -48) },
                { sawbladeGun, new Vector2(32, -116) },
                { rocketLauncher, new Vector2(128, -116) },
                { machineGun, new Vector2(224, -116) },
                { finger, new Vector2(320, -116) }
            };

            activeItemOffset = new Vector2(-224, -48);
            pistol.Enabled = true;
            SetActiveItem(0, "Pistol");
        }

        // Sets the HUD position to match the camera's position
        public void SetPosition(Vector2 cameraPosition)
        {
            // Set item positions
            baseInventory.Position = cameraPosition + baseInventoryOffset;
            activeItem.Position = baseInventory.Position + activeItemOffset;
            selector.Position = baseInventory.Position + selectorOffset;

            foreach (KeyValuePair<UIElement, Vector2> kvp in offsets)
            {
                if (kvp.Key.Enabled)
                    kvp.Key.Position = baseInventory.Position + kvp.Value;
                else
                    kvp.Key.Position = outOfSight;
            }
        }

        public void Add(string item)
        {
            List<UIElement> elements = new List<UIElement>(offsets.Keys);

            foreach (UIElement element in elements)
            {
                if (item.Equals(element.Type))
                {
                    element.Enabled = true;
                    return;
                }
            }
        }

        public string GetActiveItem()
        {
            return activeItem.Type;
        }

        public void SetActiveItem(int index, string name)
        {
            EntityManager.Instance.RemoveEntity(activeItem.Id);
            activeItem = new UIElement(name);
            selectorOffset = new Vector2(32 + 96 * (index % 4), -48 + -68 * (index / 4));
        }
    }
}