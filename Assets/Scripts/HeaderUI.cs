using TMPro;
using UnityEngine;

public class HeaderUI : MonoBehaviour
{

    [SerializeField]
    TMP_Text totalMuffinsText;


    private void Awake()
    {
        
    }

    private void OnDestroy()
    {
        GameManager.Singleton.OnTotalMuffinsChanged -= UpdateUI;
    }

    private void Start()
    {
        GameManager.Singleton.OnTotalMuffinsChanged += UpdateUI;
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
