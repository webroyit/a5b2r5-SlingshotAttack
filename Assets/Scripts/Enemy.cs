using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Note: drag and drop EnemyDeathEffect prefab to this variable in Unity
    public GameObject deathEffect;

    public float health = 4f;

    public static int EnemiesAlive = 0;

    // When the game start, each enemey ojbect loads which increases EnemiesAlive
    void Start()
    {
        EnemiesAlive++;
    }

    // This is a callback
    void OnCollisionEnter2D(Collision2D colInfo)
    {
        // relativeVelocity is a 2-Dimensional vector
        // It compared the velocity of one object to the other object
        // magnitude convert them into single number
        if(colInfo.relativeVelocity.magnitude > health)
        {
            // Enemy is dead
            Die();
        }
    }

    void Die()
    {
        // Show the particle effect after the enemy is dead
        // First parameter is to called EnemyDeathEffect prefab
        // Second parameter is the Ball position
        // Third parameter is for no rotation
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        EnemiesAlive--;

        Destroy(gameObject);
    }
}
