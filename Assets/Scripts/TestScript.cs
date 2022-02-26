using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    private void Awake() =>
        GetComponent<Button>().onClick.AddListener(OnClick);

    [SerializeField] int y = 7;

    [SerializeField] int x = 6;

    void OnClick()
    {
        Add(x, y);
        Add(6, 7);

        y = Add(5, 1);
    }

    int Add(int xValue, int yValue)
    {
        int result = xValue + yValue;
        return result;
    }
}
