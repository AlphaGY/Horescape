using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
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
		deathMessage.text = "Your Score:\n" + score.scoreStr.text;
		gameObject.SetActive (true);
	}

	public void Restart ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
