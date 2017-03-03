using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  	//Velocidade do player
	public float speed = 6f;

	//Vetor responsável pelo movimento 3 eixos
	Vector3 movement;

	//Responsavel pela transição da animação
	Animator anim;

	//Responsavel pela fisica do objeto
	Rigidbody playerRigidbody;

	//Mascara de chão - Componente Quad 
	int floorMask;

	//Comprimento de camera - RayCast
	float camRayLenght = 100f;

	//Sempre chamará esta função, diferente do Start()
	void Awake(){
		floorMask = LayerMask.GetMask ("Floor");	//atribui a mascara da camada

		//atribui as referencias
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
		
	}

	//Chamada a cada vez que a engine de fisica é atualizada
	void FixedUpdate(){

		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
		Turning ();
		Animating (h, v);

	}

	// funcao de movimento
	void Move (float h, float v){

		//determina o movimento
		movement.Set (h, 0f, v);

		//normaliza o movimentoquando duas teclas é clicada de uma vez ao mesmo tempo para que o player nao ande mais rapido
		movement = movement.normalized * speed * Time.deltaTime;

		//aplicando o movimento
		playerRigidbody.MovePosition (transform.position + movement);
	
	}

	//Girar o player
	void Turning(){

		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit floorHit;

		//raio, onde bateu, o tamanho do raio, onde quer checar
		if (Physics.Raycast(camRay, out floorHit, camRayLenght, floorMask)){

			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			playerRigidbody.MoveRotation (newRotation);

		}
			
	}

	//Determinando animação
	void Animating(float h, float v){

		bool walking = (h != 0f || v != 0f);
		anim.SetBool ("IsWalking", walking);

	}


}
