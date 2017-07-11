using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMotor : MonoBehaviour
{

	private CharacterController controller;
	private Vector3 movement;
	public float forwardSpeed = 5.0f;
	// accelerated speed
	private float accelerated = 5.0f;
	// countdown for accelerating
	private float countdown;
	private float verticalSpeed;
	private float gravity = 0.4f;
	private bool possibleJump = false;
	private bool jumpFlag = false;
	private float jumpHeight = 9.0f;
	private float minMoveDis = 100.0f;
	// ios touch
	private Vector3 touchOrigin = Vector3.zero;
	PlayerHealth playerHealth;
	//player animator
	private Animator anim;

	void Start ()
	{
		controller = GetComponent<CharacterController> ();
		playerHealth = GetComponent<PlayerHealth> ();
		countdown = accelerated;
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		//initial animator
		anim.SetBool ("hit", false);
		anim.SetBool ("afraidrun", false);
		anim.SetBool ("collect", false);

		movement = Vector3.zero;
		// speed up every [accelerated] seconds
		countdown -= Time.deltaTime;
		if (countdown <= 0) {
			forwardSpeed *= 1.2f;
			accelerated += 1.0f;
			countdown = accelerated;
		}
		movement.z = forwardSpeed;
		// left & right movement from input
		movement.x = Input.GetAxisRaw ("Horizontal") * -5.0f;

		// touch
		if (Input.touchCount > 0) {
			Touch myTouch = Input.GetTouch (0);
			TouchPhase phase = myTouch.phase;

			if (phase == TouchPhase.Began) {
				//If so, set touchOrigin to the position of that touch
				touchOrigin = myTouch.position;
			} else if (phase == TouchPhase.Moved) {
				possibleJump = true;
			} else if (phase == TouchPhase.Ended && phase == TouchPhase.Stationary) {
				possibleJump = false;
			} else if (phase == TouchPhase.Ended && possibleJump) {
				possibleJump = false;
				if ((myTouch.position.y - touchOrigin.y) > minMoveDis && controller.isGrounded) {
					jumpFlag = true;
				}
			}

			// if not jump, then may be left/right
			if (!jumpFlag) {
				if (myTouch.position.y < Screen.height / 2) {
					if (myTouch.position.x > Screen.width / 2) {
						movement.x = -3.0f;
					} else {
						movement.x = 3.0f;
					}
				}
			}
		}

        
		// gravity
		if (controller.isGrounded) {
			if (jumpFlag || Input.GetButton ("Jump")) {
				verticalSpeed = jumpHeight;
				jumpFlag = false;
			} else {
				// a small force to keep the player on the ground
				verticalSpeed = -0.1f;
			}
		} else {
			verticalSpeed -= gravity;
		}

		movement.y = verticalSpeed;

		controller.Move (movement * Time.deltaTime);

		// falling into the fall =death
		if (controller.transform.position.y < 0) {
			playerHealth.takeDamage (100);
		}

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Hand")) {
			anim.SetBool ("hit", true);
			other.gameObject.SetActive (false);
			playerHealth.takeDamage (20);
		} else if (other.gameObject.CompareTag ("Monster")) {
			anim.SetBool ("afraidrun", true);
			playerHealth.takeDamage (40);
		} else if (other.gameObject.CompareTag ("Pickup")) {
			anim.SetBool ("collect", true);
			other.gameObject.SetActive (false);
			playerHealth.regainHealth (20);
		}
	}
}
