using UnityEngine;

public class Ball : MonoBehaviour
{
    // Note: drag and drop Ball's Rigidbody2D component to this variable in Unity
    public Rigidbody2D rb;

    private bool isPressed = false;

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
    }

}
