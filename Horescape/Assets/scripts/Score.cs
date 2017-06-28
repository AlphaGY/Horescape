using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

	public Text scoreStr;
	private int scoreInt = 0;
	private float scoreAddGap = 0.2f;
	private float countdown;

	// Use this for initialization
	void Start ()
	{
		scoreStr.text = scoreInt.ToString ();
		countdown = scoreAddGap;
	}
	
	// Update is called once per frame
	void Update ()
	{
		countdown -= Time.deltaTime;
		if (countdown <= 0) {
			scoreInt += 1;
			scoreStr.text = scoreInt.ToString ();
			countdown = scoreAddGap;
		}
	}
}