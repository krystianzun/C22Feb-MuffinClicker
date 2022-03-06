using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools
{
    /// <summary>
    /// Returns a random value for Vector 2 between min and max. 
    /// </summary>
    public static Vector2 GetRandomVector2(float minX, float maxX, float minY, float maxY)
    {
        Vector2 randomVector;
        randomVector.x = Random.Range(minX, maxX);
        randomVector.y = Random.Range(minY, maxY);
        return randomVector;
    }
}
