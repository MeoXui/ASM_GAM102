using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public Transform self;
    public GameObject SP, EP, plant, boar;
    public int width;
    Vector3 startPos, endPos, spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        float x = self.position.x + 0.5f,
            y = self.position.y - 0.5f;
        if (width > 9)
        {
            int r = Random.Range(0, (width - 6));
            x += r;
            width = Random.Range(6, 9);
        }
        startPos = new Vector3(x, y, 0);
        endPos = new Vector3(x + width, y, 0);
        spawnPos = new Vector3(x + width / 2f, 1, 0);

        Instantiate(SP, startPos, Quaternion.identity, self);
        Instantiate(EP, endPos, Quaternion.identity, self);

        int rate = Random.Range(0, 3);
        if (rate == 0) Instantiate(plant, spawnPos, Quaternion.identity);
        if (rate == 2) Instantiate(boar, spawnPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
