using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace GG3902
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Camera camera;
        private GameSetup gameSetup;
        private StateMachine stateMachine;
        private List<IController> controllers;
        private PlayerUI playerUI;

        public IEnumerable<IController> Controllers => controllers;
        public event Action<IState> OnStateChange;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            camera = new Camera();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            controllers = new List<IController>();
            gameSetup = new GameSetup(this, camera);
            stateMachine = new StateMachine();
        }
        
        public void RegisterController(IController controller)
        {
            controllers.Add(controller);
        }

        /*
         * Methods for room management.
         */

        public void Reset()
        {
            EntityManager.Instance.Reset();
            RoomManager.Instance.Reset();
            SoundManager.Instance.Reset();
            StateManager.Instance.Reset();
            TextureManager.Instance.Reset();
            Round.Reset();
            controllers = new List<IController>();
            gameSetup = new GameSetup(this, camera);
            stateMachine = new StateMachine();
            Initialize();
        }

        public bool ChangeRooms(Direction direction)
        {

            bool success = RoomManager.Instance.SwitchRooms(direction);
            if (success)
            {
                SoundManager.Instance.StopAllSounds();
                EntityManager.Instance.Clear();
                RoomManager.Instance.LoadRoom();
                EntityManager.Instance.Initialize();
            }
            return success;
            
        }

        /*
         * Methods for managing the game state.
         */

        public void SetState(IState state)
        {
            stateMachine.CurrentState = state;
            OnStateChange?.Invoke(state);
        }

        public void ReverseState()
        {
            IState state = stateMachine.LastPlayState();
            OnStateChange?.Invoke(state);
        }

        public IState GetState()
        {
            return stateMachine.CurrentState;
        }

        /*
         * Methods inherited from the Game class.
         */

        protected override void Initialize()
        {
            // Initialize the window
            _graphics.PreferredBackBufferWidth = 1024; 
            _graphics.PreferredBackBufferHeight = 936; // Original 704 + Inventory (88) + Map (88) + Ingame HUD (56) 
            _graphics.ApplyChanges();

            // Initialize the camera
            camera.ViewportWidth = GraphicsDevice.Viewport.Width;
            camera.ViewportHeight = GraphicsDevice.Viewport.Height;
            camera.CenterOn(camera.ViewportCenter);
            camera.MoveCamera(new Vector2(0, -232));

            // Set up game - load textures, sounds, player. [Proven]
            gameSetup.Load();
            playerUI = gameSetup.CreatePlayerUI(); 

            // Start the game at the title screen
            SetState(StateManager.Instance.GetState("TitleScreen"));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            // Update the game based on its current state
            stateMachine.CurrentState.Update(gameTime);
            playerUI.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null, camera.TranslationMatrix);
            EntityManager.Instance.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
