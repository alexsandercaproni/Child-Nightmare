using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntretelasManager : MonoBehaviour {

	public void retryButton(string newGameLevel){

		SceneManager.LoadScene (newGameLevel);

	}

	public void NextButton(string newGameLevel){

		SceneManager.LoadScene (newGameLevel);

	}
}
