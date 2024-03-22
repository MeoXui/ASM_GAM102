using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{
    public Transform transform;
    public GameObject bullet;

    void FixedUpdate()
    {
        if (transform.position.y < -15)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        };
    }

    public void shoot()
    {
        Instantiate(bullet, new Vector3(transform.position.x - 1.375f, transform.position.y + 1.4375f, 0), Quaternion.identity, transform);
    }
}
