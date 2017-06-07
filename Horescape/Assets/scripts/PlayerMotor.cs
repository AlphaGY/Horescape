using System.Collections;
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
    private float fallingSpeed = 0.0f;
    private float gravity = 1.0f;

    private int hp = 100;
    public Text hpText;
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        countdown = accelerated;
        setHPText();
    }

    // Update is called once per frame
    void Update()
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
            fallingSpeed = 0.0f;
        }
        else
        {
            fallingSpeed -= gravity;
        }
        movement.y = fallingSpeed;

        controller.Move(movement * Time.deltaTime);

        if (hp > 0)
        {
            setHPText();
        }
        else
        {
            setHPText("death");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            other.gameObject.SetActive(false);
        }
        forwardSpeed -= 1.0f;
        hp -= 40;
    }
    void setHPText(string status = "")
    {
        if (status == "")
        {
            hpText.text = "HP:" + hp.ToString();
        }
        else
        {
            hpText.text = status;
        }
    }
}
