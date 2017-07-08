using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodEffect : MonoBehaviour
{

	public GameObject blood1;
	public GameObject blood2;

	// Use this for initialization
	void Start ()
	{
		blood1.SetActive (false);
		blood2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void setEffect (int hp)
	{
		if (hp <= 20) {
			displayBlood (blood1, 2);
			displayBlood (blood2, 2);
		} else if (hp <= 40) {
			displayBlood (blood1, 2);
			displayBlood (blood2, 1);
		} else if (hp <= 60) {
			displayBlood (blood1, 1);
			displayBlood (blood2, 1);
		} else if (hp <= 80) {
			displayBlood (blood1, 1);
			blood2.SetActive (false);
		} else {
			blood1.SetActive (false);
			blood2.SetActive (false);
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
		blood.GetComponent<Image>().color = new Color32(255,255,255,50);
	}

	// a little bit transparent
	private void transparency50 (GameObject blood)
	{
		blood.SetActive (true);
		blood.GetComponent<Image>().color = new Color32(255,255,255,100);
	}
}
