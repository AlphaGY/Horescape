﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class BloodFlash : MonoBehaviour 
{
	public Color flashColor;
	public Color regular;
	public Image damage_image;
	// Use this for initialization
	void Start () 
	{
		
	}

	// Update is called once per frame
	void Update () 
	{
		
	}
	public void displayEffect()
	{
		damage_image.color = flashColor;

	}  
	public void disappear()
	{
		damage_image.color = regular;
	}

}   
	

