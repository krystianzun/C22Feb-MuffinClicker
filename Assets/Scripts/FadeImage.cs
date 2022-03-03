using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    float timer;

    Color startColor;

    [SerializeField]
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void FadeClick()
    {
        // Fade it
        timer += Time.deltaTime;
        image.color = Color.Lerp(startColor, Color.clear, timer);
    }
}
