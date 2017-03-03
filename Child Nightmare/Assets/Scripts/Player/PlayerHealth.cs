using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{	
	
	public int startingHealth = 100; //vida inicial
	public int currentHealth; //vida atual
	public Slider healthSlider; //slider
	public Image damageImage; //pisca quando da dano
	public AudioClip deathClip; //audio quando morre
	public float flashSpeed = 5f; //velocidade da imagem piscando
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f); //cor da imagem piscando


    Animator anim; //puxa animação do player
    AudioSource playerAudio; // audio do player
    PlayerMovement playerMovement; // script de movimento do player
    
	PlayerShooting playerShooting;
    bool isDead;
    bool damaged;


    void Awake (){
		
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        playerMovement = GetComponent <PlayerMovement> ();
        playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
    }


    void Update (){
		
        if(damaged){
        
			damageImage.color = flashColour;
        }

        else{
            //quando o player nao toma dano, ele trafega da cor vermelha que piscou para a velocidade do flashSpeed
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

	//o quanto de dano que o player sofreu
    public void TakeDamage (int amount){
		
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        playerAudio.Play ();

        if(currentHealth <= 0 && !isDead){
            Death ();
        }
    }


    void Death (){
        isDead = true;

        playerShooting.DisableEffects ();

        anim.SetTrigger ("Die"); 

        playerAudio.clip = deathClip; //seta o audio de morrer
        playerAudio.Play (); //toca

        playerMovement.enabled = false; //desabilita o script de movimento
        playerShooting.enabled = false; //desabilita o script de tiro
    }


    public void RestartLevel ()
    {
        SceneManager.LoadScene (0);
    }
}
