using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private float[] rotationOptions = {0f, 90f, 180f, 270f};
    private bool isRotating = false;
    private float start = 0f;
    private float end = 0f;

    IEnumerator RotateOverTime(float angle, float duration)
    {
        isRotating = true;

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(angle, 0, 0);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;
        isRotating = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && !isRotating)
        {

            float randomAngle = rotationOptions[Random.Range(0, rotationOptions.Length)];

            float rotationDuration = Mathf.Abs(transform.eulerAngles.x - randomAngle / 90f) * 2f;

            StartCoroutine(RotateOverTime(randomAngle, 2f));
        }
    }
}
