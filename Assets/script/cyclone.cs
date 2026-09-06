using UnityEngine;
using System.Collections;

public class CylinderGate : MonoBehaviour
{
    public Transform[] cylinders;

    public float extendDistance = 3f;
    public float moveSpeed = 5f;

    public float delayBetweenCylinders = 0.5f;
    public float holdTime = 1f;
    public float passWindowTime = 2f;

    private Vector3[] closedPositions;
    private Vector3[] extendedPositions;

    void Start()
    {
        closedPositions = new Vector3[cylinders.Length];
        extendedPositions = new Vector3[cylinders.Length];

     
        for (int i = 0; i < cylinders.Length; i++)
        {
            float y = i * 1.2f;

            cylinders[i].localPosition = new Vector3(
                0f,
                y,
                0f
            );

            closedPositions[i] = cylinders[i].localPosition;

            extendedPositions[i] =
                closedPositions[i] +
                new Vector3(extendDistance, 0f, 0f);
        }

        StartCoroutine(GateSequence());
    }

    IEnumerator GateSequence()
    {
        while (true)
        {
           
            for (int i = 0; i < cylinders.Length; i++)
            {
                yield return StartCoroutine(
                    MoveCylinder(
                        cylinders[i],
                        extendedPositions[i]
                    )
                );

                yield return new WaitForSeconds(
                    delayBetweenCylinders
                );
            }

           
            yield return new WaitForSeconds(holdTime);

         
            for (int i = 0; i < cylinders.Length; i++)
            {
                yield return StartCoroutine(
                    MoveCylinder(
                        cylinders[i],
                        closedPositions[i]
                    )
                );
            }

         
            yield return new WaitForSeconds(
                passWindowTime
            );
        }
    }

    IEnumerator MoveCylinder(
        Transform cylinder,
        Vector3 target
    )
    {
        while (
            Vector3.Distance(
                cylinder.localPosition,
                target
            ) > 0.01f
        )
        {
            cylinder.localPosition =
                Vector3.MoveTowards(
                    cylinder.localPosition,
                    target,
                    moveSpeed * Time.deltaTime
                );

            yield return null;
        }

       
        cylinder.localPosition = target;
    }
}
