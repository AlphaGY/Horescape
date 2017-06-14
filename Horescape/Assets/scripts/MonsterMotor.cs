using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMotor : MonoBehaviour
{

    private CharacterController controller;

    private Transform playerTransform;
    private Vector3 playerLastPosition;
    // orginal distance between the monster and the player
    private Vector3 offset;
    private Vector3 movement;
    private PlayerHealth playerHealth;
    // attack time gap of the monster
    private float attackGap = 3.0f;
    private float countdown;
    private bool isAttacking = false;



    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerLastPosition = playerTransform.position;
        offset = playerLastPosition - transform.position;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        countdown = attackGap;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = Vector3.zero;
        movement.z = playerTransform.position.z - playerLastPosition.z;
        playerLastPosition = playerTransform.position;

        countdown -= Time.deltaTime;
        // if has attacked, jump back
        if (isAttacking)
        {
            Debug.Log("jump back");
            isAttacking = false;
            // jump backward into its previous position
            movement -= jump(offset.z/2);
        }
        else
        {
            // time to attack
            if (countdown <= 0)
            {
                if (!isAttacking)
                {
                    isAttacking = true;
                    // jump forward to catch the player
                    movement += jump(offset.z/2);
                }
                countdown = attackGap;
            }
        }
        controller.Move(movement);
    }

    void OnTriggerEnter(Collider other)
    {
        // distroy any obstacles along the way
        if (other.gameObject.CompareTag("Hand"))
        {
            other.gameObject.SetActive(false);
        }
        // player got caught
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth.takeDamage(100);
        }
    }
    // jump forward [distance] amount of distance
    Vector3 jump(float distance)
    {
        return Vector3.forward * distance;
    }
}
