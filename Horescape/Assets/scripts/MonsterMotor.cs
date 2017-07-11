using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMotor : MonoBehaviour
{

	private CharacterController controller;
	// orginal distance between the monster and the player
	private PlayerMotor playerMotor;
	// attack time gap of the monster
	private Transform playerTransform;
	private float offset;
	private float monsterHeight = 0.55f;
	private Vector3 movement;
	private float verticalSpeed;
	// speed of jumping foward
	private float dashSpeed;
	private float jumpHeight = 6.0f;
	private float gravity = 0.4f;
	// monster will attack every at most [shortestAttackGap] time & at least [longestAttackGap] time
	private float shortestAttackGap = 5.0f;
	private float longestAttackGap = 15.0f;
	private float countdownS;
	private float countdownL;
	//monster animation
	private Animation anim;

	void Start ()
	{
		controller = GetComponent<CharacterController> ();
		playerMotor = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMotor> ();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		offset = playerTransform.position.z - transform.position.z;
		dashSpeed = offset * 1.2f;
		resetAllCountdonw ();
		anim = GetComponent<Animation> ();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (controller.isGrounded) {
			//anim.Play("walk");
			anim.Play ("zombieRun");
		}

		movement = Vector3.zero;

		// fix x
		movement.x = -1.0f * transform.position.x;

		// forward speed
		movement.z = playerMotor.forwardSpeed;

		countdownS -= Time.deltaTime;
		countdownL -= Time.deltaTime;

		// attack if hasn't attacked for [longestAttackGap] time
		if (countdownL < 0) {
			//animation
			anim.Play ("zombieRun");
			anim.Play ("attack1");
			//movement
			movement.z += dashSpeed;
			verticalSpeed = jumpHeight;
			resetAllCountdonw ();
		} else {
			// 50% chance to attack if hasn't attacked for [shortestAttackGap] time
			if (countdownS < 0) {
				if (Random.value > 0.5f) {
					//animation
					anim.Play ("zombieRun");
					anim.Play ("attack2");
					//movement
					movement.z += dashSpeed;
					verticalSpeed = jumpHeight;
					countdownL = longestAttackGap;
				}
				countdownS = shortestAttackGap;
			}
		}

		// in the air
		// stop countdown during this period
		if (!controller.isGrounded && transform.position.y > monsterHeight) {
			movement.z += dashSpeed;
			verticalSpeed -= gravity;
			resetAllCountdonw ();
		}
        // slow down to maintian the distance
		// stop countdown during this period
        else if ((playerTransform.position.z - transform.position.z) <= offset) {
			movement.z -= dashSpeed;
			resetAllCountdonw ();
		}

		movement.y = verticalSpeed;

		controller.Move (movement * Time.deltaTime);

		// keep the monster from falling into holes
		if (transform.position.y <= monsterHeight) {
			Vector3 onGround = Vector3.zero;
			onGround.x = transform.position.x;
			onGround.z = transform.position.z;
			onGround.y = monsterHeight;
			transform.position = onGround;
		}
	}


	private void resetAllCountdonw ()
	{
		countdownS = shortestAttackGap;
		countdownL = longestAttackGap;
	}

	void OnTriggerEnter (Collider other)
	{
		// distroy any obstacles along the way
		if (other.gameObject.CompareTag ("Hand") || other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
		}
	}
}
