using UnityEngine;

public class GameOverManager : MonoBehaviour{
    
	public PlayerHealth playerHealth; //vida do player
	//public float restartDelay = 5f; //tempo para reiniciar o jogo quando o player morrer


    Animator anim; //animação do game over
	//float restartTimer;


    void Awake(){
        anim = GetComponent<Animator>();
    }


    void Update(){
        if (playerHealth.currentHealth <= 0){
            anim.SetTrigger("GameOver");

			//restartTimer += Time.deltaTime;

			//if (restartTimer >= restartDelay) {
			//	Application.LoadLevel (Application.loadedLevel);
			//}
        }
    }
}
