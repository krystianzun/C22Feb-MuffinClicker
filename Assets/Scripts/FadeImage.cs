using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    float timer;

    Color startColor;

    [SerializeField]
    Image candyImage;

    private void Awake()
    {
        candyImage = GetComponent<Image>();
    }

    public void FadeClick()
    {
        // Fade it
        timer += Time.deltaTime;
        candyImage.color = Color.Lerp(startColor, Color.clear, timer);
    }
}
