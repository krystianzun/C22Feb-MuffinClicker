using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// If the player manages to click the candy, award the player 100 cookies.
/// </summary>

public class CandyClicker : MonoBehaviour
{
    [SerializeField]
    TMP_Text textRewardPrefab;

    [SerializeField]
    float minXPos, maxXPos, minYPos, maxYPos;

    [SerializeField]
    AudioSource biscuitBiteSound;


    private void OnCandyClicked()
    {
        Debug.Log("Candy Clicked");

        float addedCandies = GameManager.Singleton.AddCandies();

        CandyTextReward(addedCandies);

        biscuitBiteSound.PlayOneShot(biscuitBiteSound.clip);
    }

    private void CandyTextReward(float addedCandies)
    {
        // Create reward prefab
        TMP_Text muffinRewardText = Instantiate(textRewardPrefab, transform);
        muffinRewardText.text = $"+{addedCandies}";
        muffinRewardText.transform.localPosition = Tools.GetRandomVector2(minXPos, maxXPos, minYPos, maxYPos);
    }
}
