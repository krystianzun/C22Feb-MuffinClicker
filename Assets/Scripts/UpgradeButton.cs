using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _levelText, _costText;

    //[SerializeField]
    //private int[] _costPerLevel;

    private int _level;

    private int CurrentCost
    {
        get
        {
            // it can be a math equation instead of manual
            return 5 + _level * 5;

            //int arrayLength = _costPerLevel.Length;

            //if (arrayLength == 0)
            //{
            //    return 0;
            //}

            //if (_level >= arrayLength)
            //{
            //    return _costPerLevel[arrayLength - 1];
            //}

            //return _costPerLevel[_level];
        }
    }

    private int Level
    {
        get
        {
            return _level;
        }

        set
        {
            _level = value;
            _levelText.text = _level.ToString();
        }
    }


    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnUpgradeClicked);
        
    }

    private void TotalMuffinsChanged()
    {
        bool canAfford = GameManager.Singleton.TotalMuffins >= CurrentCost;
        _costText.color =
                canAfford ?
                Color.green :
                Color.red;
    }

    private void Start()
    {
        GameManager.Singleton.OnTotalMuffinsChanged += TotalMuffinsChanged;
        Level = 0;
        UpdateCostText();
        
    }


    private void UpdateCostText() =>
        _costText.text = CurrentCost.ToString();

    private void OnUpgradeClicked()
    {
        Debug.Log("Upgrade Clicked");

        if (GameManager.Singleton.TryPurchaseUpgrade(CurrentCost))
        {
            Level++;
            UpdateCostText();
        }
    }
}
