using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float duration = 0.5f;
    public Camera mainCamera;
    public bool start;
    public AnimationCurve curve;

    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking()
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            mainCamera.transform.position = mainCamera.transform.position + Random.insideUnitSphere * strength;
            yield return null;
        }
    }
}
