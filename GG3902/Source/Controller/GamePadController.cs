using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GG3902
{
	public class GamePadController : IController
	{
		private Dictionary<string, Dictionary<Buttons, ICommand>> buttonMappings;
		private Dictionary<Buttons, ICommand> titleBindings;
		private Dictionary<Buttons, ICommand> playerBindings;
		private Dictionary<Buttons, ICommand> playerZMBindings;
		private Dictionary<Buttons, ICommand> inventoryBindings;
		private Dictionary<Buttons, ICommand> pausedBindings;
		private Dictionary<Buttons, ICommand> winOrDeathBindings;
		private Dictionary<Buttons, ICommand> nullBindings;
		private Dictionary<Buttons, ICommand> currentBindings;
		private GamePadState oldState = GamePad.GetState(PlayerIndex.One);
		private GamePadState currentState;

		public GamePadController()
		{
			buttonMappings = new Dictionary<string, Dictionary<Buttons, ICommand>>();
			titleBindings = new Dictionary<Buttons, ICommand>();
			playerBindings = new Dictionary<Buttons, ICommand>();
			playerZMBindings = new Dictionary<Buttons, ICommand>();
			inventoryBindings = new Dictionary<Buttons, ICommand>();
			pausedBindings = new Dictionary<Buttons, ICommand>();
			winOrDeathBindings = new Dictionary<Buttons, ICommand>();
			nullBindings = new Dictionary<Buttons, ICommand>();
			currentBindings = new Dictionary<Buttons, ICommand>();
		}

		// This function registers the bindings when the title screen loads
		public void RegisterTitleCommands(Buttons button, ICommand command)
		{
			titleBindings.Add(button, command);
		}

		// This function registers the players commands when playing
		public void RegisterPlayGameCommands(Buttons button, ICommand command)
		{
			playerBindings.Add(button, command);
		}

		// This function registers the players commands when playing Zombie mode
		public void RegisterZombieGameCommands(Buttons button, ICommand command)
		{
			playerZMBindings.Add(button, command);
		}


		// This function registers commands when player is in inventory
		public void RegisterInventoryCommands(Buttons button, ICommand command)
		{
			inventoryBindings.Add(button, command);
		}

		// This function registers commands when player is paused
		public void RegisterPausedCommands(Buttons button, ICommand command)
		{
			pausedBindings.Add(button, command);
		}

		// This function registers commands when player wins or dies.
		public void RegisterWinOrDeathCommands(Buttons button, ICommand command)
		{
			winOrDeathBindings.Add(button, command);
		}

		public void StoreAllBindings()
		{
			buttonMappings.Add("title", titleBindings);
			buttonMappings.Add("player", playerBindings);
			buttonMappings.Add("inventory", inventoryBindings);
			buttonMappings.Add("paused", pausedBindings);
			buttonMappings.Add("zombies", playerZMBindings);
			buttonMappings.Add("winOrlose", winOrDeathBindings);
			buttonMappings.Add("null", nullBindings);
		}

		public void ChangeMappings(string key)
		{
			if (buttonMappings.TryGetValue(key, out currentBindings))
			{
				Debug.WriteLine("Debug: GamePad Binding change was successful!");
			}else
            {
				Debug.WriteLine("Error: GamePad Binding change was unsuccessful!");
			}
		}


		// This function checks if a Button is pressed
		public bool IsButtonPressed(Buttons button)
		{
			return currentState.IsButtonDown(button) && oldState.IsButtonUp(button);
		}

		// This function checks if a Key is held down
		public bool IsButtonHeldDown(Buttons button)
		{
			return currentState.IsButtonDown(button) && oldState.IsButtonDown(button);
		}

		// This function checks if a Key is released
		public bool IsButtonReleased(Buttons button)
		{
			return currentState.IsButtonUp(button) && oldState.IsButtonDown(button);
		}

		public void Update()
		{
			// Get the keyboard's current state 
			currentState = GamePad.GetState(PlayerIndex.One);

			if (currentState.IsConnected)
			{
				// Check if anything happens to the binded keys
				foreach (KeyValuePair<Buttons, ICommand> kvp in currentBindings)
				{
					// Execute player actions on key press
					if (IsButtonPressed(kvp.Key))
					{
						kvp.Value.Execute();
					}
					else if (IsButtonReleased(kvp.Key))
					{
						kvp.Value.Undo();
					}
				}
				oldState = currentState;
			}
		}
	}
}
