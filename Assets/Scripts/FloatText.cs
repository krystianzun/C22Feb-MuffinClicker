using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatText : MonoBehaviour
{
    [SerializeField]
    float minMoveSpeed = 100;

    [SerializeField]
    float maxMoveSpeed = 400;

    float moveSpeed;


    private void Awake()
    {
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

    void Update()
    {
        // Float it upwards
        transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
    }
}
