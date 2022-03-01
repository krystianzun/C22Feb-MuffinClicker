using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeText : MonoBehaviour
{
    public static FadeText Singleton;

    float timer;

    Color startColor;

    [SerializeField]
    TMP_Text tmp;

    private void Awake()
    {
        startColor = tmp.color;
        Singleton = this;
    }

    void Update()
    {
        // Fade it
        timer += Time.deltaTime;
        tmp.color = Color.Lerp(startColor, Color.clear, timer);
    }
}
