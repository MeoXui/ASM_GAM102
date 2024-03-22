using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textmanage : MonoBehaviour
{
    public TextMeshProUGUI title;
    string oldText;

    // Start is called before the first frame update
    void Start()
    {
        oldText = title.text;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            title.text = "LAM BOI HUYNK PH38086";
            title.fontSize = 180;
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            title.text = oldText;
            title.fontSize = 300;
        }
    }
}
