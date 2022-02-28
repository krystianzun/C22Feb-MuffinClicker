using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScaleTransforms : MonoBehaviour
{
    int startSpinPosition;

    [SerializeField]
    RectTransform[] spinTransforms;

    [SerializeField]
    float spinSpeed = 1;

    [SerializeField]
    float scaleOffset = 1;

    [SerializeField]
    float scaleAmplitude = 0.1f;

    [SerializeField]
    float scaleTime = 5f;


    private void Start()
    {
        // Challenge Session 3 - Random Spin Position on Start
        //foreach (RectTransform spinLight in spinLights)
        //{
        //    startSpinPosition = Random.Range(-360, 360);
        //    spinLight.Rotate(0, 0, startSpinPosition);
        //}
    }

    private void Update()
    {
        float wave = GetTransformScale();

        Vector3 lightPulseScale = Vector3.one * wave;

        for (int i = 0; i < spinTransforms.Length; i++)
        {
            RectTransform spinTransform = spinTransforms[i];
            spinTransform.Rotate(0, 0, spinSpeed * Time.deltaTime);
            spinTransform.localScale = lightPulseScale;
        }
    }

    private float GetTransformScale()
    {
        float time = Time.time;
        float wave = Mathf.Sin(time * scaleTime) * scaleAmplitude;
        wave += scaleOffset;
        return wave;
    }
}
