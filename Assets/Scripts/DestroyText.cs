using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyText : MonoBehaviour
{
    [SerializeField]
    TMP_Text tmp;

    void Update()
    {
        // Destroy it
        if (tmp.color.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
