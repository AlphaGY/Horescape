using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	public void StartGame ()
	{
		SceneManager.LoadScene ("Prototype");
	}

	public void Pause ()
	{
		Time.timeScale = 0;

	}

	public void Resume ()
	{
		Time.timeScale = 1;
	}

	public void Restart ()
	{
		SceneManager.LoadScene ("Prototype");
	}

	public void Exit ()
	{
		SceneManager.LoadScene ("MainMenu");
	}
}
