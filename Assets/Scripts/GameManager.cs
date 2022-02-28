using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;

    int totalMuffins;


    public int TotalMuffins
    {
        get
        {
            return totalMuffins;
        }
        private set
        {
            totalMuffins = value;

            // Update Header
            HeaderUI.Singleton.UpdateUI();
        }
    }


    [SerializeField]
    int muffinsPerClick = 1;

    [Range(0, 1)]
    [SerializeField]
    float critChance = 0.01f;


    public int AddMuffins()
    {
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

        TotalMuffins += addedMuffins;
        return addedMuffins;
    }


    private void Awake()
    {
        Singleton = this;    
    }

}
