using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;  //Transform do player
	public float smoothing = 5f; //Para amaciar a transição

	Vector3 offset; //distancia da camera para o player

	// Use this for initialization
	void Start () {

		offset = transform.position - target.position; 
	
	}

	void FixedUpdate(){

		//nova posição da camera com base no movimento do player
		Vector3 targetCamPos = target.position + offset;

		//aplicando nova posição da camera
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);

	}
}
