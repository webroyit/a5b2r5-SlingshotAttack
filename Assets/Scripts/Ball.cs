using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool isPressed = false;

    void OnMouseDown()
    {
        isPressed = true;
    }

    void OnMouseUp()
    {
        isPressed = false;
    }

}
