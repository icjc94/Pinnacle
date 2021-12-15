using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OLDPLAYERMOVEMENT : MonoBehaviour
{
    public int currentHealth = 4;
    public int maxHealth = 4;
    //public HealthBar healthbar;

    public GameObject pauseMenu;
    public GameObject winText;
    public GameObject loseText;

    //public EnemyMovement enemymovement;
    //public int RemainingEnemyCount;

    public float speed;
    //public float jumpspeed;
    public float jumprate = 1f;
    float nextJumpTime = 0f;

    private Vector3 moveHorizontal = Vector3.forward;

    private Vector3 moveVertical = Vector3.right;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //currentHealth = maxHealth;
        //healthbar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(RemainingEnemyCount);
        /*

        if (currentHealth == 0)
        {
            //game over
            pauseMenu.SetActive(true);
            loseText.SetActive(true);
            Time.timeScale = 0;
        }
        */

        if (Time.time >= nextJumpTime)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                transform.position += new Vector3(0, 1f, 0);
                nextJumpTime = Time.time + jumprate;
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(moveHorizontal * speed);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(-moveHorizontal * speed);
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(-moveVertical * speed);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(moveVertical * speed);
        }

        /*
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(1);
        }
        */
        
    }
    /*
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

        Debug.Log("Damage Taken!");
    }
    */
}

