using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GG3902
{
    /*
     * This class is used to hold the mappings for the game 
     */
    public class GameMappings
    {

        private Game1 Game;
        private Camera Camera;
        private Player Player;

        public GameMappings(Game1 game, Camera camera, Player player)
        {
            Game = game;
            Camera = camera;
            Player = player;
        }
       /*
        * This function setups all the player controls
        */
        public void SetupControls(IController controller)
        {

            if (controller is KeyboardController)
            {
                InsertTitleKeyBindings(controller as KeyboardController);
                InsertPlayKeyBindings(controller as KeyboardController);
                InsertZombieKeyBindings(controller as KeyboardController);
                InsertInventoryKeyBindings(controller as KeyboardController);
                InsertPausedKeyBindings(controller as KeyboardController);
                InsertWinOrDeathKeyBindings(controller as KeyboardController);
                (controller as KeyboardController).StoreAllBindings();
            }
            else if (controller is GamePadController)
            {
                InsertTitleButtonBindings(controller as GamePadController);
                InsertPlayButtonBindings(controller as GamePadController);
                InsertZombieButtonBindings(controller as GamePadController);
                InsertInventoryButtonBindings(controller as GamePadController);
                InsertPausedButtonBindings(controller as GamePadController);
                InsertWinOrDeathButtonBindings(controller as GamePadController);
                (controller as GamePadController).StoreAllBindings();
            } 
            else if (controller is MouseController)
            {
                InsertTitleClickBindings(controller as MouseController);
                InsertPlayClickBindings(controller as MouseController);
                InsertZombieClickBindings(controller as MouseController);
                InsertInventoryClickBindings(controller as MouseController);
                InsertPausedClickBindings(controller as MouseController);
                InsertWinOrDeathClickBindings(controller as MouseController);
                (controller as MouseController).StoreAllBindings();
            }
        }

        /* ---------------------------------- Insert Methods for KeyboardController ---------------------------------- */

        public void InsertTitleKeyBindings(KeyboardController keyboard)
        {
            keyboard.RegisterTitleCommands(Keys.Enter, new GameStateCommand(Game, StateManager.Instance.GetState("PlayState")));
            keyboard.RegisterTitleCommands(Keys.Q, new QuitGameCommand(Game));
            keyboard.RegisterTitleCommands(Keys.M, new ToggleMuteSongsCommand());
        }

        public void InsertPlayKeyBindings(KeyboardController keyboard)
        {
            // Movement Keys
            keyboard.RegisterPlayGameCommands(Keys.W, new MoveTransitionPlayerCommand(Player, Direction.Up));
            keyboard.RegisterPlayGameCommands(Keys.A, new MoveTransitionPlayerCommand(Player, Direction.Left));
            keyboard.RegisterPlayGameCommands(Keys.S, new MoveTransitionPlayerCommand(Player, Direction.Down));
            keyboard.RegisterPlayGameCommands(Keys.D, new MoveTransitionPlayerCommand(Player, Direction.Right));

            // Mute Song Toggle Key
            keyboard.RegisterPlayGameCommands(Keys.M, new ToggleMuteSongsCommand());
            keyboard.RegisterPlayGameCommands(Keys.N, new ToggleMuteSoundsCommand());

            keyboard.RegisterPlayGameCommands(Keys.Space, new UseItemPlayerCommand(Player));
            keyboard.RegisterPlayGameCommands(Keys.E, new SwitchItemPlayerCommand(Player));
            keyboard.RegisterPlayGameCommands(Keys.F, new AttackPlayerCommand(Player));

            // Game Commands
            keyboard.RegisterPlayGameCommands(Keys.Escape, new GameStateCommand(Game, StateManager.Instance.GetState("Menu")));
            keyboard.RegisterPlayGameCommands(Keys.L, new GameStateCommand(Game, StateManager.Instance.GetState("Win")));
            keyboard.RegisterPlayGameCommands(Keys.I, new GameStateCommand(Game, StateManager.Instance.GetState("Inventory")));
        }

        public void InsertZombieKeyBindings(KeyboardController keyboard)
        {
            // Movement Keys
            keyboard.RegisterZombieGameCommands(Keys.W, new MoveTransitionPlayerCommand(Player, Direction.Up));
            keyboard.RegisterZombieGameCommands(Keys.A, new MoveTransitionPlayerCommand(Player, Direction.Left));
            keyboard.RegisterZombieGameCommands(Keys.S, new MoveTransitionPlayerCommand(Player, Direction.Down));
            keyboard.RegisterZombieGameCommands(Keys.D, new MoveTransitionPlayerCommand(Player, Direction.Right));

            // Mute Song Toggle Key
            keyboard.RegisterZombieGameCommands(Keys.M, new ToggleMuteSongsCommand());
            keyboard.RegisterZombieGameCommands(Keys.N, new ToggleMuteSoundsCommand());

            keyboard.RegisterZombieGameCommands(Keys.Space, new UseItemPlayerCommand(Player));
            keyboard.RegisterZombieGameCommands(Keys.E, new SwitchItemPlayerCommand(Player));
            keyboard.RegisterZombieGameCommands(Keys.F, new AttackPlayerCommand(Player));

            // Game Commands
            keyboard.RegisterZombieGameCommands(Keys.Escape, new GameStateCommand(Game, StateManager.Instance.GetState("Menu")));
            keyboard.RegisterZombieGameCommands(Keys.L, new GameStateCommand(Game, StateManager.Instance.GetState("Win")));
            keyboard.RegisterZombieGameCommands(Keys.I, new GameStateCommand(Game, StateManager.Instance.GetState("Inventory")));
        }

        public void InsertInventoryKeyBindings(KeyboardController keyboard)
        {
            keyboard.RegisterInventoryCommands(Keys.E, new SwitchItemPlayerCommand(Player));
            keyboard.RegisterInventoryCommands(Keys.Q, new QuitGameCommand(Game));
            keyboard.RegisterInventoryCommands(Keys.I, new ExitInventoryCommand(StateManager.Instance.GetState("Inventory")));
            keyboard.RegisterInventoryCommands(Keys.F10, new AddAllGunsPlayerCommand(Player));
        }
        
        public void InsertPausedKeyBindings(KeyboardController keyboard)
        {
            keyboard.RegisterPausedCommands(Keys.Q, new QuitGameCommand(Game));
            keyboard.RegisterPausedCommands(Keys.Enter, new GameStateCommand(Game, StateManager.Instance.GetState("PlayState")));
            keyboard.RegisterPausedCommands(Keys.R, new ResetGameCommand(Game));
        }

        public void InsertWinOrDeathKeyBindings(KeyboardController keyboard)
        {
            keyboard.RegisterWinOrDeathCommands(Keys.Q, new QuitGameCommand(Game));
            keyboard.RegisterWinOrDeathCommands(Keys.R, new ResetGameCommand(Game));
        }

        /* ----------------------------------- Insert Methods for MouseController ----------------------------------- */
        public void InsertTitleClickBindings(MouseController mouse) 
        { 
            mouse.RegisterTitleCommands("PlayButton", new GameStateCommand(Game, StateManager.Instance.GetState("PlayState")));
            mouse.RegisterTitleCommands("ExitButton", new QuitGameCommand(Game));
            mouse.RegisterTitleCommands("ToggleMuteSongButton", new ToggleMuteSongButtonCommand());
            mouse.RegisterTitleCommands("ToggleMuteSoundButton", new ToggleMuteSoundButtonCommand());
        }
        public void InsertPlayClickBindings(MouseController mouse) 
        {
            mouse.RegisterPlayGameCommands("LeftClick", new UseItemPlayerCommand(Player));
            mouse.RegisterPlayGameCommands("RightClick", new AttackPlayerCommand(Player));
        }
        public void InsertZombieClickBindings(MouseController mouse) 
        {
            mouse.RegisterZombieGameCommands("LeftClick", new UseItemPlayerCommand(Player));
            mouse.RegisterZombieGameCommands("RightClick", new AttackPlayerCommand(Player));
        }
        public void InsertInventoryClickBindings(MouseController mouse) 
        { }
        public void InsertPausedClickBindings(MouseController mouse) 
        {
            mouse.RegisterPausedCommands("ResumeButton", new ResumeGameCommand(Game));
            mouse.RegisterPausedCommands("ExitButton", new QuitGameCommand(Game));
            mouse.RegisterPausedCommands("ToggleMuteSongButton", new ToggleMuteSongButtonCommand());
            mouse.RegisterPausedCommands("ToggleMuteSoundButton", new ToggleMuteSoundButtonCommand());
        }
        public void InsertWinOrDeathClickBindings(MouseController mouse) 
        {
            mouse.RegisterWinOrDeathCommands("RestartButton", new ResetGameCommand(Game));
            mouse.RegisterWinOrDeathCommands("ExitButton", new QuitGameCommand(Game));
        }

        /* ---------------------------------- Insert Methods for GamePadController ---------------------------------- */

        public void InsertTitleButtonBindings(GamePadController gamepad)
        { }
        public void InsertPlayButtonBindings(GamePadController gamepad)
        { }
        public void InsertZombieButtonBindings(GamePadController gamepad)
        { }

        public void InsertInventoryButtonBindings(GamePadController gamepad)
        { }

        public void InsertPausedButtonBindings(GamePadController gamepad)
        { }

        public void InsertWinOrDeathButtonBindings(GamePadController gamepad)
        { }
    }
}
