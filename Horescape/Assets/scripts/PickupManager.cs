using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{

	public GameObject[] pickupPrefabs;

	private Transform playerTransform;
	// distance of the pickup ahead of the player
	private float distance = 12.0f;
	private List<GameObject> activePickups;
	private float shortestGap = 5.0f;
	private float longestGap = 10.0f;
	private float countdownS;
	private float countdownL;

	// Use this for initialization
	void Start ()
	{
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		activePickups = new List<GameObject> ();
		countdownS = shortestGap;
		countdownL = longestGap;
	}
	
	// Update is called once per frame
	void Update ()
	{
		countdownS -= Time.deltaTime;
		countdownL -= Time.deltaTime;

		if (countdownL < 0) {
			spwanPickup ();
			countdownL = longestGap;
			countdownS = shortestGap;
			deletePickup ();
		} else {
			if (countdownS < 0) {
				if (Random.value > 0.5f) {
					spwanPickup ();
				}
				countdownS = shortestGap;
			}
		}
	}

	private void spwanPickup (int prefab = -1)
	{
		Debug.Log ("pickup");
		GameObject go;
		if (prefab == -1) {
			go = Instantiate (pickupPrefabs [randomPickupIndex ()]) as GameObject;
		} else {
			go = Instantiate (pickupPrefabs [prefab]) as GameObject;
		}
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * (playerTransform.position.z + distance) + Vector3.up;
		activePickups.Add (go);
	}

	private void deletePickup ()
	{
		if (activePickups.Count > 0) {
			Destroy (activePickups [0]);
			activePickups.RemoveAt (0);
		}
	}

	private int randomPickupIndex ()
	{
		if (pickupPrefabs.Length <= 1) {
			return 0;
		}
		return Random.Range (0, pickupPrefabs.Length);
	}
}
