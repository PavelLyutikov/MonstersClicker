using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickCount : MonoBehaviour
{

    public static int Click;
    public Text ClickCountText;

    private void Start()
    {
        Click = 0;
    }

    void Update()
    {
        ClickCountText.text = "Score: " + Click;
    }
}
