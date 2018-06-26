using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void OnClickNewGame(){
		Application.LoadLevel ("prologue");
	}

	public void OnClickLevel01(){
		Application.LoadLevel ("level_01");
	}

	public void OnClickLevel02(){
		Application.LoadLevel ("level_02");
	}

	public void OnClickLevel03(){
		Application.LoadLevel ("level_03");
	}

	public void OnClickMainMenu(){
		Application.LoadLevel ("mainMenu");
	}

	public void OnClickEndingScene(){
		Application.LoadLevel ("endingScene");
	}

	public void OnClickExit(){
		Application.Quit ();
	}
}
