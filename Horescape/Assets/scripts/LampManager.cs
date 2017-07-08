using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampManager : MonoBehaviour
{

	private Transform playerTransform;
	private float spawnZ = 0.0f;
	private float minGap = 15.0f;
	private int lampOnScreen = 10;
	private List<GameObject> activeLamps;

	public GameObject lampPrefab;

	// Use this for initialization
	void Start ()
	{
		activeLamps = new List<GameObject> ();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

		for (int i = 0; i < lampOnScreen; i++) {
			spawnLamp ();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playerTransform.position.z > (spawnZ - minGap * lampOnScreen)) {
			spawnLamp ();
		}
		if (activeLamps.Count > 2 * lampOnScreen) {
			deleteLamp ();
		}
	}

	private void spawnLamp ()
	{
		GameObject go;
		go = Instantiate (lampPrefab) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.up * 6.5f + Vector3.forward * spawnZ;
		//go.transform.Rotate (0,1,0);
		spawnZ += (minGap + Random.Range (0, 10));
		activeLamps.Add (go);
	}

	private void deleteLamp ()
	{
		Destroy (activeLamps [0]);
		activeLamps.RemoveAt (0);
	}
}
