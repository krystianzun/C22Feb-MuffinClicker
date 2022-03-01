using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVector : MonoBehaviour
{
    public static RandomVector Singleton;

    [SerializeField]
    float minXPos, maxXPos, minYPos, maxYPos;


    private void Awake()
    {
        Singleton = this;
    }

    public Vector2 GetRandomVector2(float minX, float maxX, float minY, float maxY)
    {
        Vector2 randomVector;
        randomVector.x = Random.Range(minX, maxX);
        randomVector.y = Random.Range(minY, maxY);
        return randomVector;
    }
}
