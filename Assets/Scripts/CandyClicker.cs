using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// If the player manages to click the candy, award the player 100 cookies.
/// </summary>

public class CandyClicker : MonoBehaviour
{

    public void OnCandyClicked()
    {
        Debug.Log("Candy Clicked");

        float addedCandies = GameManager.Singleton.AddCandies;

    }
}
