using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood2 : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	public void displayMenu ()
	{
		gameObject.SetActive (true);
	}
	public void disappear()
	{
		gameObject.SetActive (false);
	}
}
