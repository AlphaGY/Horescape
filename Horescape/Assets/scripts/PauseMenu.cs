using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public Button pause;
	public Button resume;
	public Button exit;

	// Use this for initialization
	void Start () {
		pause.gameObject.SetActive (false);
		resume.gameObject.SetActive (false);
		exit.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void clickPause(){
		pause.gameObject.SetActive (false);
		resume.gameObject.SetActive (true);
		exit.gameObject.SetActive (true);
	}

	public void clickResume(){
		pause.gameObject.SetActive (true);
		resume.gameObject.SetActive (false);
		exit.gameObject.SetActive (false);
	}

	public void displayPauseButton(){
		pause.gameObject.SetActive (true);
	}
}
