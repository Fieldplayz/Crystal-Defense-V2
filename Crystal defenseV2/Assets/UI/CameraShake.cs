using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public bool start = false;
    public float duration = 1f;
    public AnimationCurve curve;
    public GameObject cameraObject;

    private void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }

        IEnumerator Shaking()
        {
            Vector3 startPosition = cameraObject.transform.position;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float strength = curve.Evaluate(elapsedTime / duration);
                cameraObject.transform.position = startPosition + Random.insideUnitSphere * strength;
                yield return null;
            }

            cameraObject.transform.position = startPosition;
        }
    }
}
