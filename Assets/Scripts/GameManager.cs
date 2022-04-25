using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
   
    const string SaveSlot = "SaveData";

    public static GameManager Singleton;

    public event Action OnTotalMuffinsChanged;
    public event Action<int> OnMuffinsPerSecondChanged;

    int totalMuffins;

    [SerializeField]
    Button candyButton;

    float muffinTimer;
    int muffinsPerSecond = 0;


    public int TotalMuffins
    {
        get
        {
            return totalMuffins;
        }
        private set
        {
            totalMuffins = value;
            OnTotalMuffinsChanged?.Invoke();
        }
    }


    [SerializeField]
    int muffinsPerClick = 1;

    [Range(0, 1)]
    [SerializeField]
    float critChance = 0.01f;

    [SerializeField]
    int candyPerClick = 100;


    public int AddMuffins()
    {
        int addedMuffins;

        if (UnityEngine.Random.value <= critChance)
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

    //public int AddCandies => TotalMuffins += candyPerClick;

    public int AddCandies()
    {
        int addedCandies;
        addedCandies = muffinsPerClick * 100;

        TotalMuffins += addedCandies;
        return addedCandies;
    }

    public bool TryPurchaseUpgrade(int currentCost, int level, UpgradeType upgradeType)
    {
        if (TotalMuffins >= currentCost)
        {
            TotalMuffins -= currentCost;
            level++;

            // Implement Upgrades here
            // muffinsPerClick = currentCost / 4;

            //switch (upgradeType)
            //{
            //    case UpgradeType.Muffin:
            //        muffinsPerClick = 1 + level * 3;
            //        break;
            //    case UpgradeType.SugarRush:
            //        muffinsPerSecond = level * 2;
            //        break;
            //    default:
            //        break;
            //}

            ApplyUpgrade(level, upgradeType);

            //if (upgradeType == UpgradeType.Muffin)
            //    muffinsPerClick = 1 + level * 3;
            //else
            //    muffinsPerSecond = level * 2;

            return true;
        }

        return false;
    }

    private void ApplyUpgrade(int level, UpgradeType upgradeType)
    {
        switch (upgradeType)
        {

            case UpgradeType.Muffin:
                muffinsPerClick = 1 + level * 3;
                break;
            case UpgradeType.SugarRush:
                muffinsPerSecond = level * 2;
                OnMuffinsPerSecondChanged?.Invoke(muffinsPerSecond);
                break;
            case UpgradeType.FancyMuffin:
                muffinsPerClick = 1 + level * 3;
                break;
        }
    }

    private void Awake()
    {
        Singleton = this;    
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            TotalMuffins = 0;

            UpgradeButton[] buttons = FindObjectsOfType<UpgradeButton>();

            foreach (UpgradeButton button in buttons)
            {
                button.Level = 0;
                ApplyUpgrade(button.Level, button.upgradeType);
            }
        }

        muffinTimer += Time.deltaTime;
        if (muffinTimer >= 1)
        {
            // Reward the muffins
            TotalMuffins += muffinsPerSecond;

            muffinTimer--;
        }
    }

    private void Start()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void Save()
    {
        SaveData saveData;
        saveData.totalMuffins = TotalMuffins;
        saveData.candyPerClick = candyPerClick;

        UpgradeButton[] buttons = FindObjectsOfType<UpgradeButton>();

        saveData.upgrades = new List<SavableUpgrade>(buttons.Length);
        foreach (UpgradeButton button in buttons)
        {
            SavableUpgrade upgrade;
            upgrade.upgradeType = button.upgradeType;
            upgrade.level = button.Level;
            saveData.upgrades.Add(upgrade);
        }

        // Serialize 
        string serializedData = JsonUtility.ToJson(saveData);

        // Save to disk
        PlayerPrefs.SetString(SaveSlot, serializedData);
    }

    private void Load()
    {
        if (!PlayerPrefs.HasKey(SaveSlot))
        {
            return;
        }

        // Load from disk
        string loadData = PlayerPrefs.GetString(SaveSlot);

        // Deserialize
        SaveData desesrializedData = JsonUtility.FromJson<SaveData>(loadData);

        // Applying the data
        TotalMuffins = desesrializedData.totalMuffins;
        candyPerClick = desesrializedData.candyPerClick;

        UpgradeButton[] buttons = FindObjectsOfType<UpgradeButton>();

        foreach (UpgradeButton button in buttons)
        {
            SavableUpgrade matchingUpgrade = desesrializedData.upgrades.Find(savableUpgrade => savableUpgrade.upgradeType == button.upgradeType);
            button.Level = matchingUpgrade.level;
            ApplyUpgrade(button.Level, button.upgradeType);
        }
    }

    [Serializable]
    private struct SaveData
    {
        public int totalMuffins;
        public int candyPerClick;
        public List<SavableUpgrade> upgrades;
    }

    [Serializable]
    private struct SavableUpgrade
    {
        public UpgradeType upgradeType;
        public int level;
    }
}
