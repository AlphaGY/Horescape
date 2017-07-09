using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour {

	//music src
	public AudioSource music;
	//volume
	public float musicVolume;	

	void Start() {
		//initial volume
		musicVolume = 0.5F;

	}

	public void AudioOn() {

		music.Play ();

	}
	public void AudioOff(){
		music.Stop();
	}
}
