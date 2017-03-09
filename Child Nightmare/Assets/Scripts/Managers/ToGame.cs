using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToGame : MonoBehaviour {

	public float restartDelay = 5f;
	float restartTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		restartTimer += Time.deltaTime;

		if (restartTimer >= restartDelay) {
			Application.LoadLevel ("Level 01");
		}
	}
}
