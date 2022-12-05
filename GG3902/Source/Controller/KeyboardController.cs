using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GG3902
{
	public class KeyboardController : IController
	{
		private Dictionary<string, Dictionary<Keys, ICommand>> keyMappings;
		private Dictionary<Keys, ICommand> titleBindings;
		private Dictionary<Keys, ICommand> playerBindings;
		private Dictionary<Keys, ICommand> playerZMBindings;
		private Dictionary<Keys, ICommand> inventoryBindings;
		private Dictionary<Keys, ICommand> pausedBindings;
		private Dictionary<Keys, ICommand> winOrDeathBindings;
		private Dictionary<Keys, ICommand> nullBindings;
		private Dictionary<Keys, ICommand> currentBindings;
		private KeyboardState oldState = Keyboard.GetState();
		private KeyboardState currentState;

		public KeyboardController()
		{
			keyMappings = new Dictionary<string, Dictionary<Keys, ICommand>>();
			titleBindings = new Dictionary<Keys, ICommand>();
			playerBindings = new Dictionary<Keys, ICommand>();
			playerZMBindings = new Dictionary<Keys, ICommand>();
			inventoryBindings = new Dictionary<Keys, ICommand>();
			pausedBindings = new Dictionary<Keys, ICommand>();
			winOrDeathBindings = new Dictionary<Keys, ICommand>();
			nullBindings = new Dictionary<Keys, ICommand>();
			currentBindings = new Dictionary<Keys, ICommand>();
		}

		// This function registers the bindings when the title screen loads
		public void RegisterTitleCommands(Keys key, ICommand command)
		{
			titleBindings.Add(key, command);
		}

		// This function registers the players commands when playing
		public void RegisterPlayGameCommands(Keys key, ICommand command)
		{
			playerBindings.Add(key, command);
		}

		// This function registers the players commands when playing Zombie mode
		public void RegisterZombieGameCommands(Keys key, ICommand command)
		{
			playerZMBindings.Add(key, command);
		}


		// This function registers commands when player is in inventory
		public void RegisterInventoryCommands(Keys key, ICommand command)
		{
			inventoryBindings.Add(key, command);
		}

		// This function registers commands when player is paused
		public void RegisterPausedCommands(Keys key, ICommand command)
		{
			pausedBindings.Add(key, command);
		}

		// This function registers commands when player wins or dies.
		public void RegisterWinOrDeathCommands(Keys key, ICommand command)
		{
			winOrDeathBindings.Add(key, command);
		}

		public void StoreAllBindings()
		{
			keyMappings.Add("title", titleBindings);
			keyMappings.Add("player", playerBindings);
			keyMappings.Add("inventory", inventoryBindings);
			keyMappings.Add("paused", pausedBindings);
			keyMappings.Add("zombies", playerZMBindings);
			keyMappings.Add("winOrlose", winOrDeathBindings);
			keyMappings.Add("null", nullBindings);
		}

		public void ChangeMappings(string key)
		{
			if (keyMappings.TryGetValue(key, out currentBindings))
			{
				Debug.WriteLine("Debug: Keyboard Binding change was successful!");
			}
			else
			{
				Debug.WriteLine("Error: Keyboard Binding change was unsuccessful!");
			}
		}


		// This function checks if a Key is pressed
		public bool IsKeyPressed(Keys key)
		{
			return currentState.IsKeyDown(key) && oldState.IsKeyUp(key);
		}

		// This function checks if a Key is held down
		public bool IsKeyHeldDown(Keys key)
		{
			return currentState.IsKeyDown(key) && oldState.IsKeyDown(key);
		}

		// This function checks if a Key is released
		public bool IsKeyReleased(Keys key)
		{
			return currentState.IsKeyUp(key) && oldState.IsKeyDown(key);
		}

		public void Update()
		{
			// Get the keyboard's current state 
			currentState = Keyboard.GetState();

			// Check if anything happens to the binded keys
			foreach (KeyValuePair<Keys, ICommand> kvp in currentBindings)
			{
				// Execute player actions on key press
				if (IsKeyPressed(kvp.Key))
				{
					kvp.Value.Execute();
				}
				else if (IsKeyReleased(kvp.Key))
				{
					kvp.Value.Undo();
				}
			}
			oldState = currentState;
		}
	}
}
