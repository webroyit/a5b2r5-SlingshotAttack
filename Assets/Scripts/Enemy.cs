using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 4f;

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
        Destroy(gameObject);
    }
}
