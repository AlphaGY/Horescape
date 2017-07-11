using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

	public Camera camera;
	public GameObject monster;

	private float crawlSpeed = 5.0f;
	private Vector3 shaking = new Vector3 (0, 0.5f, 0);
	private float shakeGap = 0.5f;
	private float countdown;

	// Use this for initialization
	void Start ()
	{
		countdown = shakeGap;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 current = monster.transform.position;
		if (monster.transform.position.z < camera.transform.position.z - 10.0f) {
			current.z += crawlSpeed * Time.deltaTime;
			monster.transform.position = current;
		}
		countdown -= Time.deltaTime;
		if (countdown < 0) {
			shaking *= -1.0f;
			countdown = shakeGap;
		}
		camera.transform.position += shaking * Time.deltaTime;
	}
}
