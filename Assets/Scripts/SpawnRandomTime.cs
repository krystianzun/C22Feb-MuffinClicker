using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomTime : MonoBehaviour
{

    [SerializeField]
    float minXPos, maxXPos, minYPos, maxYPos;

    [SerializeField]
    float spawnTime;

    [SerializeField]
    float spawnDelay;

    [SerializeField]
    float minTime, maxTime;

    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject Spawnee;


    private void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    private void Update()
    {
        spawnDelay = Random.Range(minTime, maxTime);
    }

    private void SpawnObject()
    {
        Instantiate(Spawnee, transform);
        Spawnee.transform.localPosition = GetRandomVector2(minXPos, maxXPos, minYPos, maxYPos);
    } 

    // This exists in MuffinClicker as well and could be potentially refactored 
    // to not duplicate the code
    Vector2 GetRandomVector2(float minX, float maxX, float minY, float maxY)
    {
        Vector2 randomVector;
        randomVector.x = Random.Range(minX, maxX);
        randomVector.y = Random.Range(minY, maxY);
        return randomVector;
    }
}
