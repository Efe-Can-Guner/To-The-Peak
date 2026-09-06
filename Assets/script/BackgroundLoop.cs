using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public Transform cameraTransform;
    public float backgroundHeight = 10f;

    void Update()
    {
        if (transform.position.y + backgroundHeight / 2 <
            cameraTransform.position.y)
        {
            transform.position += Vector3.up * backgroundHeight * 2;
        }
    }
}