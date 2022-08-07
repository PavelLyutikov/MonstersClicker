using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySettings : MonoBehaviour
{

    public EnemyMovement movement;
    public Rigidbody enemy;
    [SerializeField] private int maxHealth;
    private int currentHealth;
    public float destoyDelay = 1f;

    public static int enemyHealth;
    public static bool damageAnimate;

    public AudioSource mySound;
    public AudioClip damageSound;
    public AudioClip dieSound;

    private void Start()
    {
     
        if (DifficultyIncrease.time >= 50)
        {
            maxHealth = 10;
        }
        else if (DifficultyIncrease.time >= 40)
        {
            maxHealth = 9;
        }
        else if (DifficultyIncrease.time >= 30)
        {
            maxHealth = 8;
        }
        else if (DifficultyIncrease.time >= 20)
        {
            maxHealth = 7;
        }
        else if (DifficultyIncrease.time >= 10)
        {
            maxHealth = 6;
        }

        currentHealth = maxHealth;
        enemyHealth = maxHealth;
    }

    public void ReceiveDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 1)
        {
            Die();
        }
        else if (currentHealth > 1)
        {
            enemy.AddForce(Vector3.forward * 3, ForceMode.Impulse);
            mySound.PlayOneShot(damageSound);
        }
    }

    public void Die()
    {
        movement.enabled = false;
        movement.DieAnimation();

        mySound.PlayOneShot(dieSound);
        Invoke("DestroyEnemy", destoyDelay);
    }

    void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
