using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    public Transform player, transform;
    public List<GameObject> lg, lo;
    int endPos, range, nextPos;

    void FixedUpdate()
    {
        if ((nextPos - player.position.x) <= 20 || lo.Count == 0) spawn();

        if (lo[0] == null) lo.RemoveAt(0);
        else if (Vector2.Distance(player.position, lo[0].transform.position) > 30)
            Destroy(lo[0]);
    }

    void spawn()
    {
        if (lo.Count == 0) endPos = 10;
        range = Random.Range(2, 6);
        nextPos = endPos + range;
        int id = Random.Range(0, lg.Count);
        GameObject newGO = Instantiate(lg[id], new Vector3(nextPos, Random.Range(0, 2), 0), Quaternion.identity, transform);
        lo.Add(newGO);

        switch (id)
        {
            case 0: endPos = nextPos + 20; break;
            case 1: endPos = nextPos + 9; break;
            case 2: endPos = nextPos + 17; break;
        }
    }
}
