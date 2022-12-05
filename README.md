# GG3902
Greasy Game's CSE3902 repository.

# Controls

- Use the "wasd" keys to move Link in all directions.
- Use the left mouse button or 'space' to shoot (hold it down or tap).
- Use the right mouse button or 'f' to stab.
- Use 'e' to switch guns.
- Use 'i' to enter/exit inventory.
- When in the inventory, use 'f10' as a cheat code to give yourself every gun in the game.
- Use 'escape' to pause.
- Press 'm' to mute the music.
- Press 'n' to mute sound FX.
- When in menus, use 'q' to quit and 'r' to reset.

# Architecture
Greasy Games uses an entity component system for their project's code architecture. The two main interfaces to
explore would be IEntity and IComponent; the former is implemented in Entity.cs and the latter is implemented
in every component in the game.

# Entity
The main entities in the game (which the team found unique enough to segregate) are:

- Player
- Enemy
- ItemPickup
- Projectile
- Tile

If you want to learn more about an entity, please explore its dot cs file.

# Component
Some components are considered drawable while others are not. The main components in the game are:

- Movement (velocity go vrooom)
- Sprite
- State (it has an update method, so we consider it a component like the rest of them!)
- Animation

In hindsight there's really not that many components... But what we have gets the job done :D

# Where are all the components stored?
All entities must go through EntityManager to add new components, remove old ones, and look at existing ones. We
think this was a good software design choice for performance reasons. Cache-coherency something or other.

# Important classes
If you're feeling lost, here's some important classes to look at that are well documented:

- ChangeRoomGameState (For changing rooms.)
- RoomManager (For managing rooms - see Room.cs for information about Room objects).
- SoundManager (For managing all the different sounds and songs in the game - utilizing Song and SoundEffect, as well as SoundEffectInstance classes.)
- Camera (For camera things :D .)

# A note about Factory classes
Yes they're disgusting. Yes we still love them. They localize a vast majority of our magic numbers to a few
related classes and updating them is most likely just as tedious as updating XML. Also working code rules so
sue us.

# A note about the background music
Use the 'M' key to mute the background music. Also, Cade took it upon himself to make a short little song to use instead of the original music. To keep from going insane as we all have this sprint while still hearing music, change line 20 in State/GameStates/PlayGameState to pull "linkReggae" instead of "Dungeon".
