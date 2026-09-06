using UnityEngine;

public class RingObstacleGenerator : MonoBehaviour
{
    public GameObject segmentPrefab;   
    public float radius = 2f;
    public int segmentsPerArc = 10;    
    public float gapAngle = 40f;       

    void Start()
    {
       
        CreateArc(90f + gapAngle / 2f, 270f - gapAngle / 2f, segmentsPerArc);

     
        CreateArc(270f + gapAngle / 2f, 360f + 90f - gapAngle / 2f, segmentsPerArc);
    }

    void CreateArc(float startAngle, float endAngle, int segmentCount)
    {
        for (int i = 0; i < segmentCount; i++)
        {
            float t = (float)i / (segmentCount - 1);
            float angle = Mathf.Lerp(startAngle, endAngle, t) * Mathf.Deg2Rad;

            Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * radius;

            GameObject seg = Instantiate(segmentPrefab, transform);
            seg.transform.localPosition = pos;

        
            float angleDeg = angle * Mathf.Rad2Deg;
            seg.transform.localRotation = Quaternion.Euler(0f, 0f, angleDeg + 90f);
        }
    }
}