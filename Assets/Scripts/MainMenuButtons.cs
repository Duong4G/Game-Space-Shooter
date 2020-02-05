using UnityEngine;
using System.Collections;

public class MainMenuButtons : MonoBehaviour {

	public void PlayGame(){
		Application.LoadLevel (1);
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
