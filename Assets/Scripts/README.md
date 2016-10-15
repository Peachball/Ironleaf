# Scripts
This file documents the general purpose of each script. But before that...

## What are scripts use for anyways?
The way Unity works is that everything operates inside of "scenes", which all
contain a bunch of "gameobjects." Gameobjects are by themselves, just objects
with a name and position, but you can add "components" to make them more
interesting. These scripts are the "components"

## Script List
* ChangeScene
	* Code to change the room within the scene
	* Used to change the setting
* CharacterControl
	* Read input to control the character's movement
* DialogueManager
	* Display dialogue to the dialogue gameobject
* FlowerManager
	* WIP
	* Eventually should define interactions with the flower...
* Globals
	* Class containing all global static variables
	* Why? Because this is the simplest way to store the state of a game (e.g.
	  inventory, completed objectives, etc.)
* SceneData
	* Definitions for attributes of a room
	* E.g:
		* Default spawn position
		* That's it...
* SingleGameManager
	* Runs the game
	* E.g. loads the relevant scenes + plays cutscenes when necessary
* UpScript
	* Literally only used to move the image up in the 1st cutscene

For more detailed documentation, they will be found within the scripts
themselves
## Misc
Useful function list:
~~~
GameObject g;
g.GetComponent&lt;TypeName&gt;(); //Returns a component of type TypeName
~~~

Style Guide
* All method documentation should be written in comments before the method
* Class documentation is written before the class declaration
* All lines should not exceed 80 characters in length
