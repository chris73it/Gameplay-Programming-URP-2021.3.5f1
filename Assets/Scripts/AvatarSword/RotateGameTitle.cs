using System.Collections;
using UnityEngine;

public class RotateGameTitle : MonoBehaviour
{
    [SerializeField] Transform titleTransform;
    [SerializeField] float rotationDelay; // Time to rotate the title

    private void Start()
    {
        StartCoroutine("Rotate");
    }

    IEnumerator Rotate()
    {
        const float xInitialAngle = 90;
        const float xFinalAngle = 0;
        float xCurrentAngle = 0;

        float rotationAccumulator = 0;
        while (rotationAccumulator < rotationDelay)
        {
            rotationAccumulator += Time.deltaTime;
            xCurrentAngle = Mathf.LerpAngle(xInitialAngle, xFinalAngle, rotationAccumulator / rotationDelay);
            titleTransform.rotation = Quaternion.Euler(xCurrentAngle, 0, 0);
            yield return null;
        }
        titleTransform.rotation = Quaternion.Euler(0, 0, 0);
        //Debug.Log("Title completely rotated");
    }
}