using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
	private Transform playerTransform;
	private Vector3 offset;
	private Vector3 lastPosition;
	private float maxY = 6.0f;

	// Use this for initialization
	void Start ()
	{
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		offset = transform.position - playerTransform.position;
		lastPosition = transform.position;
	}

	// Update is called once per frame
	void Update ()
	{
		Vector3 current = playerTransform.position + offset;
		current.x = 0;

		if (current.y > lastPosition.y) {
			transform.Rotate (0.4f, 0, 0);
		} else if (current.y < lastPosition.y) {
			transform.Rotate (-0.4f, 0, 0);
		}

		if (current.y > maxY) {
			current.y = maxY;
		}

		transform.position = current;
		lastPosition = playerTransform.position + offset;
	}
}
