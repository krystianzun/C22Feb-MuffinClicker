using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class MuffinClicker : MonoBehaviour
{
    [SerializeField]
    TMP_Text textRewardPrefab;

    [SerializeField]
    float minXPos, maxXPos, minYPos, maxYPos;

    [SerializeField]
    AudioSource biscuitBiteSound;


    public void OnMuffinClicked()
    {
        Debug.Log("Muffin Clicked");

        float addedMuffins = GameManager.Singleton.AddMuffins();

        CreateTextReward(addedMuffins);
    }

    private void CreateTextReward(float addedMuffins)
    {
        // Create reward prefab
        TMP_Text muffinRewardText = Instantiate(textRewardPrefab, transform);
        muffinRewardText.text = $"+{addedMuffins}";
        muffinRewardText.transform.localPosition = Tools.GetRandomVector2(minXPos, maxXPos, minYPos, maxYPos);

        biscuitBiteSound.PlayOneShot(biscuitBiteSound.clip);
    }
}
