using UnityEngine;
using UnityEngine.SceneManagement;

public static class SingleGameManager{
#region startgame
	public static void startgame(){
		//Play first cutscene + wait until it's done
		SceneManager.LoadScene("Scenes/1stCutscene");
		GameObject d = GameObject.Find("DialogueBackground");
		DialogueManager dm = d.GetComponent<DialogueManager>();
		string cutscenedialogue = dm.loadDialogueFromFile("1stCutsceneDialogue.txt")
		dm.PlayLines();

		//Play first scene + wait for interaction to occur
	}
#endregion
}
