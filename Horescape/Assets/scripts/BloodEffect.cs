using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodEffect : MonoBehaviour
{

	public GameObject bloodSpot1;
	public GameObject bloodSpot2;
	public GameObject bloodFlash;

	// Use this for initialization
	void Start ()
	{
		bloodSpot1.SetActive (false);
		bloodSpot2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void setEffect (int hp)
	{
		float opacity = (100 - hp) / 5;
		bloodFlash.GetComponent<Image> ().color = new Color32 (255, 0, 0, (byte)opacity);
		if (hp <= 20) {
			displayBlood (bloodSpot1, 2);
			displayBlood (bloodSpot2, 2);
		} else if (hp <= 40) {
			displayBlood (bloodSpot1, 2);
			displayBlood (bloodSpot2, 1);
		} else if (hp <= 60) {
			displayBlood (bloodSpot1, 1);
			displayBlood (bloodSpot2, 1);
		} else if (hp <= 80) {
			displayBlood (bloodSpot1, 1);
			bloodSpot2.SetActive (false);
		} else {
			bloodSpot1.SetActive (false);
			bloodSpot2.SetActive (false);
		}
	}

	// display blood pic
	// mode 1 : a little damaged
	// mode 2 : more damaged
	private void displayBlood (GameObject blood, int mode)
	{
		if (mode == 1) {
			transparency25 (blood);
		} else {
			transparency50 (blood);
		}
	}

	// very transparent
	private void transparency25 (GameObject blood)
	{
		blood.SetActive (true);
		blood.GetComponent<Image> ().color = new Color32 (255, 255, 255, 50);
	}

	// a little bit transparent
	private void transparency50 (GameObject blood)
	{
		blood.SetActive (true);
		blood.GetComponent<Image> ().color = new Color32 (255, 255, 255, 100);
	}
}
