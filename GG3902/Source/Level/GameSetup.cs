using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace GG3902
{
    public class GameSetup : ContentLoader
    {
        private Game1 game;
        private XmlParser parser;
        private string filepath;
        private Player player;
        private Camera Camera;

        public GameSetup(Game1 game, Camera camera) : base()
        {
            this.game = game;
            Camera = camera;

            // Sets up filepath for the player data
            parser = new XmlParser(new Type[] { typeof(Player), typeof(Tile), typeof(Door) });
            filepath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/Source/Level/";
            RegisterContentCommands();

            // Add player, states and controllers
            AddPersistentObjects();
            SetupGameStates();
            AddControllers();
        }

        public PlayerUI CreatePlayerUI()
        {
            return new PlayerUI(game, player, Camera);
        }

        private void RegisterContentCommands()
        {
            // Player content
            RegisterContentCommand(new AddTextureCommand("damaged_link", "Spritesheets/damaged_link_spritesheet", game.Content));
            RegisterContentCommand(new AddTextureCommand("moving_link", "Spritesheets/moving_link_spritesheet", game.Content));
            RegisterContentCommand(new AddTextureCommand("wooden_sword_attack_link", "Spritesheets/wooden_sword_attack_link_spritesheet", game.Content));
            RegisterContentCommand(new AddTextureCommand("pickup_item_link", "Spritesheets/pickup_item_link_spritesheet", game.Content));
            RegisterContentCommand(new AddTextureCommand("death_flash", "Spritesheets/death_flash_spritesheet", game.Content));

            // Enemy content
            RegisterContentCommand(new AddTextureCommand("armos", "Spritesheets/armos", game.Content));
            RegisterContentCommand(new AddTextureCommand("ghini", "Spritesheets/ghini", game.Content));
            RegisterContentCommand(new AddTextureCommand("leever", "Spritesheets/leever", game.Content));
            RegisterContentCommand(new AddTextureCommand("lynel", "Spritesheets/lynel", game.Content));
            RegisterContentCommand(new AddTextureCommand("lynelflipped", "Spritesheets/lynelflipped", game.Content));
            RegisterContentCommand(new AddTextureCommand("moblin", "Spritesheets/moblin", game.Content));
            RegisterContentCommand(new AddTextureCommand("moblinflipped", "Spritesheets/moblinflipped", game.Content));
            RegisterContentCommand(new AddTextureCommand("moblinarrows", "Spritesheets/moblinarrows", game.Content));
            RegisterContentCommand(new AddTextureCommand("moblinarrowsflipped", "Spritesheets/moblinarrowsflipped", game.Content));
            RegisterContentCommand(new AddTextureCommand("octorok", "Spritesheets/octorok", game.Content));
            RegisterContentCommand(new AddTextureCommand("octorokflipped", "Spritesheets/octorokflipped", game.Content));
            RegisterContentCommand(new AddTextureCommand("octorokupsidedown", "Spritesheets/octorokupsidedown", game.Content));
            RegisterContentCommand(new AddTextureCommand("peahat", "Spritesheets/peahat", game.Content));
            RegisterContentCommand(new AddTextureCommand("tektite", "Spritesheets/tektite", game.Content));

            // Zombie content
            RegisterContentCommand(new AddTextureCommand("walker", "Spritesheets/Zombie_Walker", game.Content));
            RegisterContentCommand(new AddTextureCommand("walkerflipped", "Spritesheets/Zombie_Walker_Flipped", game.Content));
            RegisterContentCommand(new AddTextureCommand("tank", "Spritesheets/Zombie_Tank", game.Content));
            RegisterContentCommand(new AddTextureCommand("spitter", "Spritesheets/Zombie_Spitter", game.Content));
            RegisterContentCommand(new AddTextureCommand("spitterflipped", "Spritesheets/Zombie_Spitter_Flipped", game.Content));
            RegisterContentCommand(new AddTextureCommand("spitterupsidedown", "Spritesheets/Zombie_Spitter_Upsidedown", game.Content));
            RegisterContentCommand(new AddTextureCommand("runner", "Spritesheets/Zombie_Runner", game.Content));
            RegisterContentCommand(new AddTextureCommand("bloodSplatter", "Spritesheets/bloodSplatter", game.Content));


            // Other content
            RegisterContentCommand(new AddTextureCommand("1_level_tilemap", "Spritesheets/1_level_tilemap_spritesheet", game.Content));
            RegisterContentCommand(new AddTextureCommand("items_misc", "Spritesheets/items_misc", game.Content));
            RegisterContentCommand(new AddTextureCommand("player_projectiles", "Spritesheets/player_projectiles_spritesheet", game.Content));
            RegisterContentCommand(new AddTextureCommand("zombieworld", "Spritesheets/zombieworld", game.Content));
            RegisterContentCommand(new AddTextureCommand("guns", "Spritesheets/guns", game.Content));
            RegisterContentCommand(new AddTextureCommand("Rocket", "Spritesheets/Rocket", game.Content));

            // Sound  content
            RegisterContentCommand(new AddSoundCommand("linkSwordAttack", "Sounds/linkSwordAttack", game.Content));
            RegisterContentCommand(new AddSoundCommand("linkArrowAttack", "Sounds/linkArrowAttack", game.Content));
            RegisterContentCommand(new AddSoundCommand("linkBombDrop", "Sounds/linkBombDrop", game.Content));
            RegisterContentCommand(new AddSoundCommand("linkBombExplode", "Sounds/linkBombExplode", game.Content));
            RegisterContentCommand(new AddSoundCommand("linkTakeDamage", "Sounds/linkTakeDamage", game.Content));
            RegisterContentCommand(new AddSoundCommand("linkPickupItem", "Sounds/linkPickupItem", game.Content));
            RegisterContentCommand(new AddSoundCommand("linkPickupHeart", "Sounds/linkPickupHeart", game.Content));
            RegisterContentCommand(new AddSoundCommand("linkPickupRupee", "Sounds/linkPickupRupee", game.Content));
            RegisterContentCommand(new AddSoundCommand("linkDying", "Sounds/linkDying", game.Content));
            RegisterContentCommand(new AddSoundCommand("linkLowHealth", "Sounds/linkLowHealth", game.Content));
            RegisterContentCommand(new AddSoundCommand("enemyDying", "Sounds/enemyDying", game.Content));
            RegisterContentCommand(new AddSoundCommand("enemyScream", "Sounds/enemyScream", game.Content));
            RegisterContentCommand(new AddSoundCommand("enemyGrowl", "Sounds/enemyGrowl", game.Content));
            RegisterContentCommand(new AddSoundCommand("linkPistol", "Sounds/linkPistolSound", game.Content));
            RegisterContentCommand(new AddSoundCommand("linkShotgun", "Sounds/linkShotgunSound", game.Content));
            RegisterContentCommand(new AddSoundCommand("linkFinger", "Sounds/linkFingerGun", game.Content));
            RegisterContentCommand(new AddSoundCommand("linkSaw", "Sounds/linkSawGun", game.Content));
            RegisterContentCommand(new AddSoundCommand("linkWinScreen", "Sounds/linkWinScreen", game.Content));
            RegisterContentCommand(new AddSoundCommand("round1", "Sounds/roundOneAnnounce", game.Content));
            RegisterContentCommand(new AddSoundCommand("round2", "Sounds/roundTwoAnnounce", game.Content));
            RegisterContentCommand(new AddSoundCommand("round3", "Sounds/roundThreeAnnounce", game.Content));
            RegisterContentCommand(new AddSoundCommand("round4", "Sounds/roundFourAnnounce", game.Content));
            RegisterContentCommand(new AddSoundCommand("round5", "Sounds/roundFiveAnnounce", game.Content));
            RegisterContentCommand(new AddSoundCommand("round6", "Sounds/roundSixAnnounce", game.Content));
            RegisterContentCommand(new AddSoundCommand("round7", "Sounds/roundSevenAnnounce", game.Content));
            RegisterContentCommand(new AddSoundCommand("round8", "Sounds/roundEightAnnounce", game.Content));
            RegisterContentCommand(new AddSoundCommand("round9", "Sounds/roundNineAnnounce", game.Content));
            RegisterContentCommand(new AddSoundCommand("round10", "Sounds/roundTenAnnounce", game.Content));
            RegisterContentCommand(new AddSongCommand("Dungeon", "Sounds/Dungeon", game.Content));
            RegisterContentCommand(new AddSongCommand("linkReggae", "Sounds/linkReggae", game.Content));
            RegisterContentCommand(new AddSongCommand("linkZombies1", "Sounds/linkZombies1", game.Content));
            RegisterContentCommand(new AddSongCommand("linkZombies2", "Sounds/linkZombies2", game.Content));
            RegisterContentCommand(new AddSongCommand("linkZombies3", "Sounds/linkZombies3", game.Content));
            RegisterContentCommand(new AddSongCommand("linkZombies4", "Sounds/linkZombies4", game.Content));
            RegisterContentCommand(new AddSongCommand("Damned", "Sounds/DamnedBlops2", game.Content));

            //Title Screen Content
            RegisterContentCommand(new AddTextureCommand("ExitButton", "Spritesheets/ExitButton", game.Content));
            RegisterContentCommand(new AddTextureCommand("ResumeButton", "Spritesheets/ResumeButton", game.Content));
            RegisterContentCommand(new AddTextureCommand("PlayButton", "Spritesheets/PlayButton", game.Content));
            RegisterContentCommand(new AddTextureCommand("RestartButton", "Spritesheets/RestartButton", game.Content));
            RegisterContentCommand(new AddTextureCommand("TitleScreen", "Spritesheets/TitleScreen", game.Content));
            RegisterContentCommand(new AddTextureCommand("LoseScreen", "Spritesheets/LoseScreen", game.Content));
            RegisterContentCommand(new AddTextureCommand("WinScreen", "Spritesheets/WinScreen", game.Content));

            // Toggle Button content

            // This icon is from DenIcon from "https://www.flaticon.com/free-icons/no-sound"
            RegisterContentCommand(new AddTextureCommand("MuteSongButton", "Spritesheets/MuteSongButton", game.Content));
            // This icon is from DenIcon from "https://www.flaticon.com/free-icons/music-and-multimedia" 
            RegisterContentCommand(new AddTextureCommand("UnmuteSongButton", "Spritesheets/UnmuteSongButton", game.Content));
            // This icon is from DenIcon from "https://www.flaticon.com/free-icons/ui" 
            RegisterContentCommand(new AddTextureCommand("MuteSoundButton", "Spritesheets/MuteSoundButton", game.Content));
            // This icon is from DenIcon from "https://www.flaticon.com/free-icons/enable-sound" 
            RegisterContentCommand(new AddTextureCommand("UnmuteSoundButton", "Spritesheets/UnmuteSoundButton", game.Content));


            // HUD Content 
            RegisterContentCommand(new AddTextureCommand("UI", "Spritesheets/ui_screens_and_sprites", game.Content));
        }

        private void AddPersistentObjects()
        {
            // Parses object data from XML specifically for persistent objects and registers them with the Entity Manager
            List<object> persistentObjs = parser.CreateObjectsFromXml(filepath + "PersistentObjects.xml");
            foreach (object obj in persistentObjs)
            {
                if (obj is Player)
                    player = obj as Player;
                else
                    EntityManager.Instance.PersistEntity((obj as IEntity).Id);
            }
        }

        private void SetupGameStates()
        {
            // This holds all the states(ChangeRoomGameState is excluded cause I said so)
            StateManager.Instance.AddState("TitleScreen", new TitleScreenGameState(game, Camera));
            StateManager.Instance.AddState("PlayState", new PlayGameState(game, Camera));
            StateManager.Instance.AddState("Menu", new MenuGameState(game, Camera));
            StateManager.Instance.AddState("Death", new DeathGameState(game, Camera));
            StateManager.Instance.AddState("Win", new WinGameState(game, Camera));
            StateManager.Instance.AddState("Zombies", new ZombieLandGameState(game, Camera, player));
            StateManager.Instance.AddState("Inventory", new InventoryGameState(game, Camera, player));
        }

        private void AddControllers()
        {
            //Controller stuff
            KeyboardController keyboard = new KeyboardController();
            GamePadController gamepad = new GamePadController();   // Needs to be tested with an actual gamePad
            MouseController mouse = new MouseController(Camera);
            GameMappings gameMappings = new GameMappings(game, Camera, player);

            gameMappings.SetupControls(keyboard);
            gameMappings.SetupControls(gamepad);
            gameMappings.SetupControls(mouse);

            game.RegisterController(keyboard);
            game.RegisterController(gamepad);
            game.RegisterController(mouse);
        }
    }
}
