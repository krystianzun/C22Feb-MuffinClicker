using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    
    
    const string SaveSlot = "SaveData";

    public static GameManager Singleton;

    int totalMuffins;

    [SerializeField]
    Button candyButton;



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

    [SerializeField]
    int candyPerClick = 100;


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

    //public int AddCandies => TotalMuffins += candyPerClick;

    public int AddCandies()
    {
        int addedCandies;
        addedCandies = muffinsPerClick * 100;

        TotalMuffins += addedCandies;
        return addedCandies;
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
            muffinsPerClick = 1;
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
        saveData.muffinsPerClick = muffinsPerClick;
        saveData.candyPerClick = candyPerClick;

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
        muffinsPerClick = desesrializedData.muffinsPerClick;
        candyPerClick = desesrializedData.candyPerClick;
    }

    [System.Serializable]
    private struct SaveData
    {
        public int totalMuffins;
        public int muffinsPerClick;
        public int candyPerClick;
    }
}
