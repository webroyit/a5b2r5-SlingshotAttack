using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Note: drag and drop Ball's Rigidbody2D component to this variable in Unity
    public Rigidbody2D rb;

    // Note: drag and drop hook object to this variable in Unity
    public Rigidbody2D hook;

    public float releaseTime = .15f;
    public float maxDragDistance = 2f;

    private bool isPressed = false;

    void Update()
    {
        if(isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Check the distance between the mouse position and the hook position
            if(Vector3.Distance(mousePos, hook.position) > maxDragDistance)
            {
                // Get the direction of the mouse position, but set the distance to the maxDragDistance
                // normalized to make sure the length of that vector is 1
                rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
            }
            else
            {
                // Move the ball based on the mouse position
                // ScreenToWorldPoint to get the coordinates of the mouse position
                rb.position = mousePos;
            }

           
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

        // Prevent the user from moving the ball after it is fired
        this.enabled = false;
    }

}
