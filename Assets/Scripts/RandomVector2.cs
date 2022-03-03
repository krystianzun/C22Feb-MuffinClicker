using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVector2 : MonoBehaviour
{
    public static Vector2 RandomVector2(float minX, float maxX, float minY, float maxY)
    {
        Vector2 randomVector;
        randomVector.x = Random.Range(minX, maxX);
        randomVector.y = Random.Range(minY, maxY);
        return randomVector;
    }
}
