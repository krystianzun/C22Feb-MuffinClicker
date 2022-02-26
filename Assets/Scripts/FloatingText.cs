using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [SerializeField]
    float minMoveSpeed = 100;

    [SerializeField]
    float maxMoveSpeed = 400;

    float moveSpeed;

    [SerializeField]
    TMP_Text tmp;

    float timer;

    Color startColor;


    private void Awake()
    {
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
        startColor = tmp.color;    
    }


    void Update()
    {
        // Float it upwards
        transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);

        // Fade it
        timer += Time.deltaTime;
        tmp.color = Color.Lerp(startColor, Color.clear, timer);

        // Destroy it
        if (tmp.color.a <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
