using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour 
{

	// Update is called once per frame
	void Update ()
	{
		transform.Rotate (new Vector3 (45, 15, 30) * Time.deltaTime);
	}
}