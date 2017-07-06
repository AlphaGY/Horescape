using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{

	public Button start;
	public PauseMenu pauseMenu;
	public Score score;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void clickStart ()
	{
		gameObject.SetActive (false);
		pauseMenu.displayPauseButton ();
		score.gameObject.SetActive (true);
	}

}
