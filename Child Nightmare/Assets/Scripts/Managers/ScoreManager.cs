using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour{
    
	public static int score; //pontuação única
	public int scoreNextLevel;
	public string nextLevel;
    
	Text text;

    void Awake (){
        text = GetComponent <Text> ();
        score = 0;
    }


    void Update (){
		//a cada arualização do frame, pego o texto do texto e + o score
        text.text = "Score: " + score;

		if(score >= scoreNextLevel){
			SceneManager.LoadScene (nextLevel);
		}

    }
		
}