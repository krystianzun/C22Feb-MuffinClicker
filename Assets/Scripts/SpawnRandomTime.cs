using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomTime : MonoBehaviour
{

    [SerializeField]
    float minXPos, maxXPos, minYPos, maxYPos;

    [SerializeField]
    float minTime, maxTime;

    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject Spawnee;

    float timer = 0f;

    [SerializeField]
    float spawnFrequency;


    private void Start()
    {
        GetRandomSpawnTime();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnFrequency)
        {
            GetRandomSpawnTime();

            SpawnObject();

            timer = 0f;
        }
    }

    private void SpawnObject()
    {
        Instantiate(Spawnee, transform);
        Spawnee.transform.localPosition = Tools.GetRandomVector2(minXPos, maxXPos, minYPos, maxYPos);
    } 

    private void GetRandomSpawnTime() => 
        spawnFrequency = Random.Range(minTime, maxTime);

            
}
