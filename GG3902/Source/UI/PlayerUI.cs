using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace GG3902
{
    public class PlayerUI
    {
        // References necessary for info about the player, level, and where to draw
        private Game1 game;
        private Player player;
        private Camera camera;

        // HUD elements
        private Inventory inventory;
        private Map map;
        private HUD hud;

        private Vector2 lastCameraPosition;
        private bool isLocked;


        public PlayerUI(Game1 game, Player player, Camera camera)
        {
            // Cache the references
            this.player = player;
            this.camera = camera;
            this.game = game;

            // Load the UI elements (which are entities, so they will initialize themselves)
            inventory = new Inventory();
            map = new Map();
            hud = new HUD();

            isLocked = false;

            // Register listeners
            game.OnStateChange += GameStateListener;
            player.OnAddItem += PlayerInventoryListener;
            player.OnItemSwitch += PlayerItemSwitchListener;
        }

        public void Update()
        {
            // Update HUD
            ZombieLandGameState zombState = game.GetState() as ZombieLandGameState;

            if (zombState != null)
            {
                hud.UpdateRound(zombState.RoundNum);
                hud.UpdateScore(zombState.Score);
                hud.UpdateKills(zombState.NumOfKills);
            }
            hud.UpdateAmmo(player.GetAmmo());
            hud.UpdateHP(player.CurrentHealth);

            // Move UI with camera
            if (!isLocked)
                lastCameraPosition = camera.WorldPosition;
            SetUIPositions(lastCameraPosition);
        }

        private void SetUIPositions(Vector2 position)
        {
            map.SetPosition(position);
            hud.SetPosition(position);
            inventory.SetPosition(position);
        }

        private void PlayerHealthListener(int health)
        {
            hud.UpdateHP(health);
        }

        private void PlayerInventoryListener(string item)
        {
            inventory.Add(item);
            // Unneeded now
        }

        private void PlayerItemSwitchListener(int index, string name)
        {
            inventory.SetActiveItem(index, name);
            hud.SetEquippedItem(name);
        }

        private void GameStateListener(IState state)
        {
            isLocked = state is InventoryGameState;
        }
    }
}
