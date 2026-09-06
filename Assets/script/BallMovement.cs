using UnityEngine;
using UnityEngine.InputSystem;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float horizontal = 0f;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            horizontal = -1f;

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            horizontal = 1f;

        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);

        if (transform.position.x > 3f)
        {
            transform.position = new Vector3(-3f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -3f)
        {
            transform.position = new Vector3(3f, transform.position.y, transform.position.z);
        }
    }
}
