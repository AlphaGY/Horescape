using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    private int maxHP = 100;
    private int currentHP;
    private bool isDead = false;
    public Slider hpBar;
    public Text hpText;

    PlayerMotor playerMotor;

    // Use this for initialization
    void Start()
    {
        playerMotor = GetComponent<PlayerMotor>();
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void takeDamage(int amount)
    {
        currentHP -= amount;
        hpBar.value = currentHP;
        if (currentHP <= 0 & !isDead)
        {
            death();
        }
    }
    private void death()
    {
        isDead = true;
        hpText.text = "dead";
        playerMotor.enabled = false;
    }
}
