using UnityEngine;

public class PlayerShooting : MonoBehaviour{
	
    public int damagePerShot = 20; //quanto de dano cada tiro vai dar
    public float timeBetweenBullets = 0.15f; //tempo entre tiros
    public float range = 100f; //range de tiro


    float timer; // timer para variacao de tempo
    Ray shootRay = new Ray(); //raio para calculo se o tiro aconteceu
    RaycastHit shootHit; // calculo da posição do espaço onde o tiro acertou
    int shootableMask; // mascara 
    ParticleSystem gunParticles; // pega as particulas da arma
    LineRenderer gunLine; // line renderer
    AudioSource gunAudio; // audio da arma
    Light gunLight; // luz do disparo
    float effectsDisplayTime = 0.2f; //duração do efeito


    void Awake (){
		
		shootableMask = LayerMask.GetMask ("Shootable"); //pega a mascara com a tag Shootable (tudo que da pra mirar)
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
    }


    void Update (){
		
        timer += Time.deltaTime; //a cada frama, pega a variação do tempo

		//se apertei o botão de tiro e se deu o tempo entre tiros
		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0){
            Shoot (); //atira
        }

		//tempo entre balas multiplica a duração dos efeitos
        if(timer >= timeBetweenBullets * effectsDisplayTime){
            DisableEffects ();
        }
    }


    public void DisableEffects (){
        gunLine.enabled = false; //apaga a linha de tiro
        gunLight.enabled = false; //apaga a luz do disparo
    }


    void Shoot (){
        timer = 0f; //time resetado

        gunAudio.Play (); // audio de tiro ativo

        gunLight.enabled = true; // luz 

		//garante que o efeito sai
        gunParticles.Stop ();
        gunParticles.Play ();

        gunLine.enabled = true; //habilita linha
        gunLine.SetPosition (0, transform.position); //seta a localização da linha

        shootRay.origin = transform.position; //bico da arma
        shootRay.direction = transform.forward; // direção da arma

		//se o raio acertou alguma coisa
        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> (); //se pegar o inimigo
            if(enemyHealth != null){
                enemyHealth.TakeDamage (damagePerShot, shootHit.point); //aplica o tiro, passando o dano e o local
            }
            gunLine.SetPosition (1, shootHit.point); // se nao pegou no inimigo, só desenha o tiro
        }
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range); // se nao pegou em nada, só a linha é desenhada
        }
    }
}
