

using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public float deathDistance = 1f;

    void Update()
    {
        Camera cam = Camera.main;

        if (cam == null)
            return;

        float cameraBottom = cam.transform.position.y - cam.orthographicSize;

        if (transform.position.y < cameraBottom - deathDistance)
        {
          

            Die();
        }
    }

    void Die()
    {
        Debug.Log("OYUN DURDU!");

        Time.timeScale = 0f;
    }
}