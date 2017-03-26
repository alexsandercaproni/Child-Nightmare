using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f; //tempo entre ataques
	public int attackDamage = 10; //dano


	//Animator anim; //animação do personagem
	GameObject player; //para pegar os scripts do player 
	PlayerHealth playerHealth; 
	bool playerInRange; //checa se o player esta no alcance pra levar dano
	float timer; //checa o tempo entre ataques

	void Awake (){
		player = GameObject.FindGameObjectWithTag ("Player"); //busca o objeto com a tag Player
		playerHealth = player.GetComponent <PlayerHealth> (); //pega o componente vida do player
		//anim = GetComponent <Animator> (); //pega a animação do personagem
	}

	//quando o objeto entra na area do inimigo
	void OnTriggerEnter (Collider other){
		if(other.gameObject == player){ //se for o player no alcance
			playerInRange = true;
		}
	}

	//quando o objeto sai da area do inimigo
	void OnTriggerExit (Collider other){
		if(other.gameObject == player){
			playerInRange = false;
		}
	}

	void Update (){
		timer += Time.deltaTime;

		//ja passou o tempo entre ataques, player esta no range e o inimigo esta vivo?
		if(timer >= timeBetweenAttacks && playerInRange){
			Attack (); //ataco o player
		}

		//o player esta com a vida menor que 0 ?
		if(playerHealth.currentHealth <= 0){
			//anim.SetTrigger ("isPlayerDead"); //aimação de morte do player
		}
	}


	void Attack (){
		timer = 0f;

		//se a vida do player é maior que 0
		if(playerHealth.currentHealth > 0){
			playerHealth.TakeDamage (attackDamage); //atribui o ataque damage na vida do player
		}
	}

}
