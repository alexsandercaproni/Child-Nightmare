using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFire : MonoBehaviour {

	public List<GameObject> spawnPositions;
	public List<GameObject> spawnObjects;

	void Start(){	
		SpawnObjects ();
	}

	void SpawnObjects(){
		foreach (GameObject spawnPosition in spawnPositions) {
			int selection = Random.Range (0, spawnObjects.Count);
			Instantiate (spawnObjects[selection], spawnPosition.transform.position, spawnPosition.transform.rotation);
		}
	}

}
