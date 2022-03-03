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
        movement = RandomVector2.GetRandomVector2(minXDir, maxXDir, minYDir, maxYDir).normalized;
        rb.AddForce(movement * Speed);
    }
}
