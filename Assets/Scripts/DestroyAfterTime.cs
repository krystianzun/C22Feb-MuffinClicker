using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField]
    float time = 5;

    public void Start()
    {
        Destroy(gameObject, time);
    }
}
