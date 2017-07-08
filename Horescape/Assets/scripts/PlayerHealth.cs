using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

	private int maxHP = 100;
	private int currentHP;
	private bool isDead = false;
	public BloodEffect bldEffect;
	public Camera camera;

	private PlayerMotor playerMotor;
	private MonsterMotor monsterMotor;
	public PickupManager pickupManager;
	public DeathMenu deathMenu;
	public Score score;

	// Use this for initialization
	void Start ()
	{
		playerMotor = GetComponent<PlayerMotor> ();
		monsterMotor = GameObject.FindGameObjectWithTag ("Monster").GetComponent<MonsterMotor> ();
		currentHP = maxHP;
	}

	// Update is called once per frame
	void Update ()
	{
		bldEffect.setEffect (currentHP);
	}

	public void takeDamage (int amount)
	{
		camera.GetComponent<CameraMotor> ().shacking ();
		currentHP -= amount;
		if (currentHP <= 0 & !isDead) {
			death ();
		}
	}

	public void regainHealth (int amount)
	{
		currentHP += amount;
		if (currentHP > maxHP) {
			currentHP = maxHP;
		}
	}

	private void death ()
	{
		isDead = true;
		deathMenu.displayMenu ();
		// stop the player and the monster from moving
		playerMotor.enabled = false;
		monsterMotor.enabled = false;
		pickupManager.enabled = false;
		score.enabled = false;
	}
}
