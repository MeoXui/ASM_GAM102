using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    int i;

    void FixedUpdate()
    {
        rigidbody2d.velocity = new Vector2(15, 0);
        i++;
        if (i == 75) Destroy(this.gameObject);
    }
}
