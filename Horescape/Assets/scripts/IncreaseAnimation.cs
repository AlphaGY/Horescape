using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseAnimation : MonoBehaviour 
{
	public ParticleSystem ps;

	// Use this for initialization
	void Start () 
	{
		ps = GetComponent<ParticleSystem> (); 
		ps.Stop ();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	public void displayEffect()
	{
		ps.Play ();
	}
}
