using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Note: drag and drop Ball's Rigidbody2D component to this variable in Unity
    public Rigidbody2D rb;

    public float releaseTime = .15f;

    private bool isPressed = false;

    void Update()
    {
        if(isPressed)
        {
            // Move the ball based on the mouse position
            // ScreenToWorldPoint to get the coordinates of the mouse position
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void OnMouseDown()
    {
        isPressed = true;

        // To move the ball
        rb.isKinematic = true;
    }

    void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;

        // Must use StartCoroutine() when calling IEnumerable function
        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        // Delay the time to excute this
        yield return new WaitForSeconds(releaseTime);

        // Release the book from the hook
        GetComponent<SpringJoint2D>().enabled = false;
    }

}
