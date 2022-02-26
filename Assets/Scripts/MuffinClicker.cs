using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MuffinClicker : MonoBehaviour
{

    int totalMuffins;

    int startSpinPosition;

    [SerializeField]
    int muffinsPerClick = 1;

    [Range(0, 1)]
    [SerializeField]
    float critChance = 0.01f;

    [SerializeField]
    TMP_Text totalMuffinsText;

    [SerializeField]
    RectTransform[] spinLights;

    [SerializeField]
    float spinSpeed = 1;

    [SerializeField]
    float scaleOffset = 1;

    [SerializeField]
    float scaleAmplitude = 0.1f;

    [SerializeField]
    float scaleTime = 5f;

    [SerializeField]
    TMP_Text textRewardPrefab;

    [SerializeField]
    float minXPos, maxXPos, minYPos, maxYPos;

    [SerializeField]
    AudioSource biscuitBiteSound;


    private void Start()
    {
        // Challenge Session 3 - Random Spin Position on Start
        //foreach (RectTransform spinLight in spinLights)
        //{
        //    startSpinPosition = Random.Range(-360, 360);
        //    spinLight.Rotate(0, 0, startSpinPosition);
        //}

        UpdateUI();
    }


    public void OnMuffinClicked()
    {
        Debug.Log("Muffin Clicked");

        int addedMuffins;

        if (Random.value <= critChance)
        {
            addedMuffins = muffinsPerClick * 10;
            //totalMuffins += muffinsPerClick * 10;
        }
        else
        {
            addedMuffins = muffinsPerClick;
            //totalMuffins += muffinsPerClick;
        }

        totalMuffins += addedMuffins;

        UpdateUI();

        TMP_Text muffinRewardText = Instantiate(textRewardPrefab, transform);
        muffinRewardText.text = $"+{addedMuffins}";
        muffinRewardText.transform.localPosition = GetRandomVector2(minXPos, maxXPos, minYPos, maxYPos);

        biscuitBiteSound.PlayOneShot(biscuitBiteSound.clip);
    }


    Vector2 GetRandomVector2(float minX, float maxX, float minY, float maxY)
    {
        Vector2 randomVector;
        randomVector.x = Random.Range(minX, maxX);
        randomVector.y = Random.Range(minY, maxY);
        return randomVector;
    }


    private void UpdateUI()
    {
        // != == > <
        if (totalMuffins == 1)
        {
            // true
            totalMuffinsText.text = "1 Muffin";
        }
        else
        {
            // false
            totalMuffinsText.text = $"{totalMuffins} Muffins";
        }
    }

    private void Update()
    {

        float time = Time.time;
        float wave = Mathf.Sin(time * scaleTime) * scaleAmplitude;
        wave += scaleOffset;

        Vector3 lightPulseScale = Vector3.one * wave;

        for (int i = 0; i < spinLights.Length; i++)
        {
            RectTransform spinLight = spinLights[i];
            spinLight.Rotate(0, 0, spinSpeed * Time.deltaTime);
            spinLight.localScale = lightPulseScale;
        }

    }
}
