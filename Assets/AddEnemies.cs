using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnemies : MonoBehaviour {
	public GameObject enemy;
	public GameObject position;
	public GameObject position2;

	void Start () {
		if (GameController.getInstance().puntos > 0) {
			//crear segundo enemigo
			Instantiate(enemy,position.transform.position, position.transform.rotation);
		}
		if (GameController.getInstance().puntos > 1) {
			//crear segundo enemigo
			Instantiate(enemy,position2.transform.position, position2.transform.rotation);
		}
	}

}
