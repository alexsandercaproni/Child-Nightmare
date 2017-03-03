using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour{
    
	public static int score; //pontuação única
    
	Text text;

    void Awake (){
        text = GetComponent <Text> ();
        score = 0;
    }


    void Update (){
		//a cada arualização do frame, pego o texto do texto e + o score
        text.text = "Score: " + score;
    }
}