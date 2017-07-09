using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCameraMotor : MonoBehaviour {

	private Vector3 offset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 current = transform.position;
		current.x = transform.position.x;

		current.y = transform.position.y;
		if (transform.position.z <= 8) {
			current.z = transform.position.z + Time.deltaTime*6;
		} else {
			current.z = transform.position.z;
		}
		transform.position = current;
	}
}
