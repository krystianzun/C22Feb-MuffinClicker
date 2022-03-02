using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirection : MonoBehaviour
{
    [SerializeField]
    float minXDir, maxXDir, minYDir, maxYDir;

    public float Speed;

    private Vector2 movement;

    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetRandomDirection(minXDir, maxXDir, minYDir, maxYDir);
        rb.AddForce(movement * Speed);
    }

    Vector2 GetRandomDirection(float minX, float maxX, float minY, float maxY)
    {
        Vector2 randomVector;
        randomVector.x = Random.Range(minX, maxX);
        randomVector.y = Random.Range(minY, maxY);
        return randomVector;
    }
}
