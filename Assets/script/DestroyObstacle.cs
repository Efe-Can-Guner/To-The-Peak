using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    public float destroyDistance = 2f;

    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (transform.position.y < cameraTransform.position.y - destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}