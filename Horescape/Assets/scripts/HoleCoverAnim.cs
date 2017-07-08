using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleCoverAnim : MonoBehaviour
{
	private Transform playerTransform;
	// distance between the hole and the player
	private float distance;
	// display the animation when the hole is within the display zone of the player
	private float displayZone = 12.0f;
	private float fallingSpeed = 10.0f;

	void Start ()
	{
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void FixedUpdate ()
	{
		distance = transform.position.z - playerTransform.position.z;
		// within the display zone
		if (distance <= displayZone) {
			// stop falling at -5
			if (transform.position.y >= -5.0f) {
				transform.position += Vector3.down * Time.deltaTime * fallingSpeed;
			}

		}
	}
}
