using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{
    private int hp;

    public Transform self;
    public Rigidbody2D rigidbody2d;
    public Animator animator;

    public GameObject bullet;
    public LayerMask lmPlayer;

    Vector3 pos;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player bullet")
        {
            Destroy(other.gameObject);
            hp--;
        }
    }

    void Start()
    {
        hp = 2;
    }

        void FixedUpdate()
    {
        pos = self.position + new Vector3(- 1.375f, 1.4375f, 0);
        RaycastHit2D seePlayer = Physics2D.Raycast(pos, Vector2.left, 10f, lmPlayer);

        if (seePlayer) animator.SetBool("attack", true);
        else animator.SetBool("attack", false);

        if (self.position.y < -15 || hp <= 0) Destroy(this.gameObject);
    }

    public void shoot()
    {
        Instantiate(bullet, pos, Quaternion.identity, self);
    }
}
