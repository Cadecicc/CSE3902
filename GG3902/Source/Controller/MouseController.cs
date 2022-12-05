using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GG3902
{
	public class MouseController : IController
	{
		private string leftClick = "LeftClick";
		private string rightClick = "RightClick";
		private static Camera Camera;
		private Dictionary<string, Dictionary<string, ICommand>> clickMappings;
		private Dictionary<string, ICommand> titleBindings;
		private Dictionary<string, ICommand> playerBindings;
		private Dictionary<string, ICommand> playerZMBindings;
		private Dictionary<string, ICommand> inventoryBindings;
		private Dictionary<string, ICommand> pausedBindings;
		private Dictionary<string, ICommand> winOrDeathBindings;
		private Dictionary<string, ICommand> nullBindings;
		private Dictionary<string, ICommand> currentBindings;
		private MouseState currentState = Mouse.GetState();
		private MouseState oldState;

		public MouseController(Camera camera)
		{
			Camera = camera;
			clickMappings = new Dictionary<string, Dictionary<string, ICommand>>();
			titleBindings = new Dictionary<string, ICommand>();
			playerBindings = new Dictionary<string, ICommand>();
			playerZMBindings = new Dictionary<string, ICommand>();
			inventoryBindings = new Dictionary<string, ICommand>();
			pausedBindings = new Dictionary<string, ICommand>();
			winOrDeathBindings = new Dictionary<string, ICommand>();
			nullBindings = new Dictionary<string, ICommand>();
			currentBindings = new Dictionary<string, ICommand>();
		}

		// This function registers the bindings when the title screen loads
		public void RegisterTitleCommands(string key, ICommand command)
		{
			titleBindings.Add(key, command);
		}

		// This function registers the players commands when playing
		public void RegisterPlayGameCommands(string key, ICommand command)
		{
			playerBindings.Add(key, command);
		}

		// This function registers the players commands when playing Zombie mode
		public void RegisterZombieGameCommands(string key, ICommand command)
		{
			playerZMBindings.Add(key, command);
		}


		// This function registers commands when player is in inventory
		public void RegisterInventoryCommands(string key, ICommand command)
		{
			inventoryBindings.Add(key, command);
		}

		// This function registers commands when player is paused
		public void RegisterPausedCommands(string key, ICommand command)
		{
			pausedBindings.Add(key, command);
		}

		// This function registers commands when player wins or dies.
		public void RegisterWinOrDeathCommands(string key, ICommand command)
		{
			winOrDeathBindings.Add(key, command);
		}

		public void StoreAllBindings()
		{
			clickMappings.Add("title", titleBindings);
			clickMappings.Add("player", playerBindings);
			clickMappings.Add("inventory", inventoryBindings);
			clickMappings.Add("paused", pausedBindings);
			clickMappings.Add("zombies", playerZMBindings);
			clickMappings.Add("winOrlose", winOrDeathBindings);
			clickMappings.Add("null", nullBindings);
		}

		public void ChangeMappings(string key)
		{
			if (clickMappings.TryGetValue(key, out currentBindings))
			{
				Debug.WriteLine("Debug: Mouse Binding change was successful!");
			}
			else
			{
				Debug.WriteLine("Error: Mouse Binding change was unsuccessful!");
			}
		}

		public static Vector2 MousePositionInWorld()
		{
			return Camera.ScreenToWorldSpace(Mouse.GetState().Position.ToVector2());
		}

		private bool IsLeftMouseClicked()
		{
			return (currentState.LeftButton == ButtonState.Pressed) && (oldState.LeftButton == ButtonState.Released);
		}

		private bool IsLeftMouseReleased()
		{
			return (currentState.LeftButton == ButtonState.Released) && (oldState.LeftButton == ButtonState.Pressed);
		}

		private bool IsRightMouseClicked()
		{
			return (currentState.RightButton == ButtonState.Pressed) && (oldState.RightButton == ButtonState.Released);
		}
		private bool IsRightMouseReleased()
		{
			return (currentState.RightButton == ButtonState.Released) && (oldState.RightButton == ButtonState.Pressed);
		}

		public void Update()
		{
			currentState = Mouse.GetState();

			
			if (IsLeftMouseClicked() && !IsRightMouseClicked())
			{

				if (currentBindings.ContainsKey(leftClick))
				{
					currentBindings[leftClick].Execute();
				} 
				else
                {
					foreach (IClickable clickable in EntityManager.Instance.Clickables)
					{

						if (currentBindings.ContainsKey(clickable.Type))
						{
							if (clickable.IsClicked(MousePositionInWorld()))
								currentBindings[clickable.Type].Execute();
						}
					}
				}
			}
			else if (IsRightMouseClicked() && !IsLeftMouseClicked())
			{
				if (currentBindings.ContainsKey(rightClick))
				{
					currentBindings[rightClick].Execute();
				}
			} 
			else if (IsLeftMouseReleased())
            {
				if (currentBindings.ContainsKey(leftClick))
				{
					currentBindings[leftClick].Undo();
				}
			}
			else if (IsRightMouseReleased())
			{
				if (currentBindings.ContainsKey(rightClick))
				{
					currentBindings[rightClick].Undo();
				}
			}
			oldState = currentState;
		}
	}
}
