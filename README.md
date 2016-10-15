# Ironleaf README

## Introduction
If you don't already know, Project Ironleaf is supposed to be a game that helps
teach kids about the importance of environmental conservation. For an in depth
introduction, read the google doc
[here](https://docs.google.com/document/d/1HhQErnrNDoxUpR7yLLR10mJFNeiB26RELpW2iAmQV38/edit).

## Project Structure
Everything that you edit should go under the "Assets" folder. Do not try to edit
the other folders, as they are all generated by Unity, and you'll probably break
something.

If you need more information about a particular folder, read the "README.md"
file in that folder

### Folders (and their purposes)
All folders mentioned below are in the Assets folder.
* Audio
	* Literally just stores audio files for the project.
	* Currently only has undertale music used in the "Kitchen" scene
* Dialogue
	* Stores dialogue for character interactions
	* For documentation on how to write dialogue files, refer to the existing
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
	* External json library
	* You don't really need to know what this is, aside that this project uses
	  it...
	* If you do want to know, it helps with processing json text
* Resources
	* Unity is dumb af, so you literally cannot load any "Prefabs" unless they
	  are in a folder named "Resources"
	* Contains the rooms (e.g. Kitchen, Bedroom, etc.)
* Scenes
	* Organization of game
	* They kinda correspond to the storyboard of the game
* Scripts
	* Misc scripts for use in the game engine
	* More documentation about them is located in the README inside that folder


## Running the Project
To run this project:
1. Open Unity
2. Wait patiently for it to finish loading up everything
3. Click on the open tab, and select the directory containing this file
4. You're done!