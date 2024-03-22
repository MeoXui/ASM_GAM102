using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boar : MonoBehaviour
{
    public Transform transform;
    public Rigidbody2D rigidbody2d;

    public float moveSpeed;

    int scale;

    bool isWalking;

    void Start()
    {
        scale = -1;
        isWalking = false;
    }

    void Update()
    {
        if (isWalking) walking();
    }

    public void flix()
    {
        scale *= -1;
    }

    public void idle()
    {
        isWalking = false;
        rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
    }

    public void walk()
    {
        isWalking = true;
    }
    
    void walking()
    {
        transform.localScale = new Vector3(-scale, 1, 1);
        rigidbody2d.velocity = new Vector2(moveSpeed * scale, rigidbody2d.velocity.y);
    }
}
