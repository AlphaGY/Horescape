using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
	public PauseMenu pauseMenu;
	public Score score;
	public Text deathMessage;
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
		pauseMenu.gameObject.SetActive (false);
		deathMessage.text = score.scoreStr.text;
		gameObject.SetActive (true);
	}
}
