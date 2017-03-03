using UnityEngine;

public class EnemyHealth : MonoBehaviour{
	
    public int startingHealth = 100; //vida maxima
    public int currentHealth; //vida atual
    public float sinkSpeed = 2.5f; //velocidade em que o corpo afunda no cenario e desaparece quando morre
    public int scoreValue = 10; //cada vez que o inimigo morre, este é a pontuação adicionada
    public AudioClip deathClip; //audio da morte


    Animator anim; //animação do imnimigo
    AudioSource enemyAudio;
    ParticleSystem hitParticles; //particula
    CapsuleCollider capsuleCollider; //colider dos objetos
    bool isDead; //morto ?
    bool isSinking; //afundando ?


	void Awake (){
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth;
    }


    void Update (){
        if(isSinking){
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime); //afundando o inimigo
        }
    }

	//amount = dano que recebeu da arma, hitPoint onde o tiro acertou
    public void TakeDamage (int amount, Vector3 hitPoint){
        
		if(isDead)
            return;

        enemyAudio.Play (); //toca o audio de dano

        currentHealth -= amount; //reduz a vida de acordo com o dano
            
        hitParticles.transform.position = hitPoint; //pega onde o tiro acertou
        hitParticles.Play(); //marca onde o tiro acertou

        if(currentHealth <= 0){
            Death ();
        }
    }


    void Death (){
        isDead = true;

        capsuleCollider.isTrigger = true; //perde a colisão, permitindo o o player passar por cima

        anim.SetTrigger ("isEnimyDead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
    }


    public void StartSinking (){
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false; //inimigo desabilitado
        GetComponent <Rigidbody> ().isKinematic = true; //nao fazer mais parte das equações
        isSinking = true; //começar a afundar
        ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f); //destroi o objeto levando 2s
    }
}
