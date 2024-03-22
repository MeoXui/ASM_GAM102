using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPColosChenging : MonoBehaviour
{
    public Slider hp;
    public Image fillImage;

    float r = 0, g = 1;
    void FixedUpdate()
    {
        if (r > 1) r = 1;
        if (r < 0) r = 0;
        if (g > 1) g = 1;
        if (g < 0) g = 0;
        fillImage.color = new Color(r, g, 0f);
        r = (hp.maxValue - hp.value) * 2 / hp.maxValue;
        g = hp.value * 2 / hp.maxValue;
    }
}
