using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{	
	//posição do player
    Transform player;

    //Pega o componente NavMesh para fazer os calculos
    UnityEngine.AI.NavMeshAgent nav;

	PlayerHealth playerHealth; //vida player
	EnemyHealth enemyHealth; //vida inimigo

    void Awake ()
    {	
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent <EnemyHealth> ();

		//Instancia o componente NavMesh
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


	//navMesh vai atualizar a cada ciclo
    void Update ()
    {
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0){	
			//pega a inteligencia artificial navMesh para seguir o player
            nav.SetDestination (player.position);
        }
        else
        {
            nav.enabled = false; //desabilita o componente de navegação
        }
    }
}
