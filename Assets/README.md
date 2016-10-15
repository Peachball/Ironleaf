# The Assets Folder

### What is this folder?
Literally anything that is going to be packaged into the game, is in this
folder.

### WTF are \*.meta files?
They are how unity keeps track of the random files you put in here.

TBH I'm not sure what they are either. But nonetheless, they are generated, and
you don't really need to worry about them, because they are changed from within
unity editor anyways, so you don't need to look at them directly.

### What are the subfolders for?
* Audio
	* Literally just stores audio files for the project.
	* Currently only has undertale music used in the "Kitchen" scene
* Dialogue
	* Stores dialogue for character interactions
	* For information on how to write dialogue files, refer to the existing
	  example or read the documentation in the file,
	  "Assets/Scripts/DialogueManager"
* Fonts
	* Store custom fonts for ui text
* Images
	* Store misc images
	* For example:
		* Sprites
		* Backgrounds
		* Title Screen images
* JSON Tests
	* Remains of an external library
	* Probably useless
	* Too scared to remove
* plugins
	* Contains the external json library
	* Probably where future external libraries will be stored
* Resources
	* Unity is dumb af, so you literally cannot load any "Prefabs" unless they
	  are in a folder named "Resources"
	* Contains the rooms (e.g. Kitchen, Bedroom, etc.)
* Scenes
	* Organization of game
	* They kinda correspond to the storyboard of the game
* Scripts
	* Misc scripts for use in the game engine
	* More information about them is located in the README inside that folder
