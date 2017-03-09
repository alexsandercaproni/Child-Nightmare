using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour {

	public void NewGameButton(string newGameLevel){
	
		SceneManager.LoadScene (newGameLevel);
	
	}

	public void ExitGameButton(){
	
		Application.Quit ();
	}

	public void NextButton(){

		SceneManager.LoadScene ("Level 01");

	}

}
