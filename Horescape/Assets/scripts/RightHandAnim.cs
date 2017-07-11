using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandAnim : MonoBehaviour
{
	private PlayerMotor player;
	private Vector3 teleportPoint;
	private Transform playerTransform;
	// distance between the right hand and the player
	private float distance;
	// display the animation when the right hand is within the display zone of the player
	private float displayZone = 8.0f;
	// the length of the hand that will be on the screen
	private float displayLength = -4.5f;
	private float movingSpeed = 8.0f;
	private float playerspeed;


	void Start ()
	{
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMotor> ();
		playerspeed = player.getSpeed ();


	}

	void FixedUpdate ()
	{
		distance = transform.position.z - playerTransform.position.z;
		// within the display zone
		if (distance <= displayZone) {
			// stop moving after the whole hand on the screen
			if (transform.position.x <= displayLength) 
			{
				movingSpeed = playerspeed * 2.0f;
				transform.position += Vector3.right * Time.deltaTime * movingSpeed;
			}
		}
	}
}