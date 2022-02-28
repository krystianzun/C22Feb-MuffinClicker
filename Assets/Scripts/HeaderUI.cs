using TMPro;
using UnityEngine;

public class HeaderUI : MonoBehaviour
{

    public static HeaderUI Singleton;

    [SerializeField]
    TMP_Text totalMuffinsText;


    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
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
}
