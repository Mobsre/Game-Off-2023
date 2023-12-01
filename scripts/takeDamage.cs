using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class takeDamage : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public float d;

    public healthBar healthBar;

    bool collide;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(d == 2)
        {
            TakeDamage(5);
            Debug.Log(currentHealth);
            d = 1;
        }
        if(currentHealth <= 0)
        {
            FindObjectOfType<end>().EndGame();
        }
        if(currentHealth < 0)
        {
            currentHealth = 5;
        }
    }


    void OnCollisionEnter(Collision collisioninfo)
    {

        if (collisioninfo.collider.tag == "projectile")
        {
            d = 2;
        }

    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log(currentHealth);
        FindObjectOfType<AudioManager>().Play("playerhurt");
    }

}
