using UnityEngine;

public class ObstacleQueueManager : MonoBehaviour
{
    public Transform[] obstacles;
    public float speed = 3f;
    public float buffer = 2f;

    private float[] initialX;
    private float totalWidth;
    private float distanceTraveled = 0f;

    void Start()
    {
        initialX = new float[obstacles.Length];
        for (int i = 0; i < obstacles.Length; i++)
            initialX[i] = obstacles[i].position.x;

        float minX = Mathf.Infinity, maxX = -Mathf.Infinity;
        foreach (float x in initialX)
        {
            if (x < minX) minX = x;
            if (x > maxX) maxX = x;
        }

        float gap = (maxX - minX) / (obstacles.Length - 1);
        totalWidth = gap * obstacles.Length;
    }

    void Update()
    {
        distanceTraveled += speed * Time.deltaTime;

        Camera cam = Camera.main;
        float camHalfWidth = cam.orthographicSize * cam.aspect;
        float leftBound = cam.transform.position.x - camHalfWidth - buffer;

        for (int i = 0; i < obstacles.Length; i++)
        {
            float rawX = initialX[i] - distanceTraveled;
            float wrappedX = Mathf.Repeat(rawX - leftBound, totalWidth) + leftBound;

            Vector3 pos = obstacles[i].position;
            pos.x = wrappedX;
            obstacles[i].position = pos;
        }
    }
}