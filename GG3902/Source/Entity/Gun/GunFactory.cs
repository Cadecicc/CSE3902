using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace GG3902
{
    public class GunFactory
    {
        private static Dictionary<string, int> gunCapacities = new Dictionary<string, int>()
        {
            { "MachineGun", 200 },
            { "Shotgun", 60 },
            { "Rocket Launcher", 15 },
            { "AR", 120 }, 
            { "Pistol", 80 },
            { "Finger", 999 },
            { "Sniper" , 30 },
            { "SawbladeGun", 20 }
        };

        public static bool IsAGun(string name)
        {
            return gunCapacities.ContainsKey(name);
        }

        public static int GetCapacity(string name)
        {
            return gunCapacities[name];
        }

        public static Gun SpawnGun(string type, Player player)
        {
            Gun gun = null;

            switch (type)
            {
                case "MachineGun":
                    gun = new Gun(new Vector2(4, 4), type, 20f, ShootBehaviours.ShootOnce, player, 1);
                    break;
                case "Shotgun":
                    gun = new Gun(new Vector2(16, 16), type, 1f, ShootBehaviours.ScatterShot, player, 4);
                    break;
                case "AR":
                    gun = new Gun(new Vector2(4, 4), type, 5f, ShootBehaviours.ShootOnce, player, 2);
                    break;
                case "Finger":
                    gun = new Gun(new Vector2(-12, -12), type, 3f, ShootBehaviours.ShootPenetration, player, 999);
                    break;
                case "Pistol":
                    gun = new Gun(new Vector2(-12, -12), type, 2f, ShootBehaviours.ShootOnce, player, 3);
                    break;
                case "Rocket Launcher":
                    gun = new Gun(new Vector2(0, 0), type, 0.75f, ShootBehaviours.ShootRocket, player, 99);
                    break;
                case "Sniper":
                    gun = new Gun(new Vector2(0, 0), type, 1f, ShootBehaviours.ShootPenetration, player, 5);
                    break;
                case "SawbladeGun":
                    gun = new Gun(new Vector2(16, 16), type, 1f, ShootBehaviours.ShootSaw, player, 3);
                    break;
                default:
                    break;
            }

            return gun;
        }
    }
}
