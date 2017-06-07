﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMotor : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 movement;
    private float forwardSpeed = 5.0f;
    // accelerated speed
    private float accelerated = 5.0f;
    // countdown for accelerating
    private float countdown;
    private float fallingSpeed;
    private float gravity = 2.0f;
    // Use this for initialization

    PlayerHealth playerHealth;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerHealth = GetComponent<PlayerHealth>();
        countdown = accelerated;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = Vector3.zero;
        // speed up every [accelerated] seconds
        if (countdown > 0)
        {
            countdown -= (accelerated * Time.deltaTime);
        }
        else
        {
            forwardSpeed += 0.2f;
            countdown = accelerated;
        }
        movement.z = forwardSpeed;
        // left & right movement from input
        movement.x = Input.GetAxisRaw("Horizontal") * -5.0f;
        // gravity
        if (controller.isGrounded)
        {
            fallingSpeed = -0.1f;
        }
        else
        {
            fallingSpeed -= gravity;
            Debug.Log("not grounded");
        }
        movement.y = fallingSpeed;

        controller.Move(movement * Time.deltaTime);

        // falling into the fall =death
        if (controller.transform.position.y < 0)
        {
            playerHealth.takeDamage(100);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            other.gameObject.SetActive(false);
        }
        forwardSpeed -= 1.0f;
        playerHealth.takeDamage(40);
    }
}
