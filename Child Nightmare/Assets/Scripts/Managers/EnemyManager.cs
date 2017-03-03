using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth; //vida do player 
    public GameObject enemy; //tipo de inimigo a ser criado
    public float spawnTime = 3f; //tempo para ser criado os inimigos
    public Transform[] spawnPoints; // array de pontos de para serem criados os inimigos


    void Start (){
        InvokeRepeating ("Spawn", spawnTime, spawnTime); //nome do método, intervalo de tempo e a frequencia de repetições
    }


    void Spawn (){
        if(playerHealth.currentHealth <= 0f){ //se o player morrer, nao precisa mais criar inimigo
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length); //pega o ponto aleatorio do meu array

		//instancia um inimigo qualquer, com sua posição e sua rotação.
        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
