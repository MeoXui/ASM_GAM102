using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public Transform player, self;
    public GameObject coin;
    public List<GameObject> lo;
    int nCoin, endPos, nextPos;

    void FixedUpdate()
    {
        if ((nextPos - player.position.x) <= 20 || lo.Count == 0) spawn();

        if (lo[0] == null) lo.RemoveAt(0);
        else if (Vector2.Distance(player.position, lo[0].transform.position) > 26)
            Destroy(lo[0]);
    }

    void spawn()
    {
        if (lo.Count == 0) endPos = 18;
        nCoin = Random.Range(5, 15);

        spawnInASin();

        endPos = nextPos + Random.Range(5, 19);
    }

    void spawnInASin()
    {
        for (int count = 0; count <= nCoin; count++)
        {
            nextPos = endPos + count;
            GameObject newCO = Instantiate(coin, new Vector3(nextPos, Mathf.Sin(nextPos) + 3, 0), Quaternion.identity, self);
            lo.Add(newCO);
        }
    }
}
