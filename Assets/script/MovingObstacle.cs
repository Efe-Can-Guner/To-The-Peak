using UnityEngine;

public class ScrollingObstacle : MonoBehaviour
{
    public float speed = 3f;
    public float buffer = 1f; 

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        Camera cam = Camera.main;
        float camHalfWidth = cam.orthographicSize * cam.aspect;
        float leftLimitX = cam.transform.position.x - camHalfWidth - buffer;
        float resetPositionX = cam.transform.position.x + camHalfWidth + buffer;

        if (transform.position.x < leftLimitX)
        {
            Vector3 pos = transform.position;
            pos.x = resetPositionX;
            transform.position = pos;
        }
    }
}