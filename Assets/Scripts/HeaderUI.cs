using TMPro;
using UnityEngine;

public class HeaderUI : MonoBehaviour
{

    [SerializeField]
    TMP_Text totalMuffinsText;

    [SerializeField]
    TMP_Text muffinsPerSecondText;


    private void Start()
    {
        GameManager.Singleton.OnTotalMuffinsChanged += UpdateTotalMuffins;
        GameManager.Singleton.OnMuffinsPerSecondChanged += UpdateMuffinsPerSecond;
        UpdateTotalMuffins();
        UpdateMuffinsPerSecond(0);
    }

    private void OnDestroy()
    {
        GameManager.Singleton.OnTotalMuffinsChanged -= UpdateTotalMuffins;
        GameManager.Singleton.OnMuffinsPerSecondChanged -= UpdateMuffinsPerSecond;
    }


    private void UpdateTotalMuffins()
    {
        // != == > <
        if (GameManager.Singleton.TotalMuffins == 1)
        {
            // true
            totalMuffinsText.text = "1 Muffin";
        }
        else
        {
            // false
            totalMuffinsText.text = $"{GameManager.Singleton.TotalMuffins} Muffins";
        }
    }

    private void UpdateMuffinsPerSecond(int muffinsPerSecond)
    {
        muffinsPerSecondText.text = $"{muffinsPerSecond} Muffins/Sec";
    }
}
