using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boar : MonoBehaviour
{
    private int hp;

    public Transform self;
    public Rigidbody2D rigidbody2d;
    public Animator animator;

    public LayerMask lmGround, lmPlayer;

    public float moveSpeed;
    float startMS;
    int scale;
    Vector3 pos;
    bool isWalking, isAttacking;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Point")
        {
            idle();
        }
        if (other.gameObject.tag =="Player bullet")
        {
            Destroy(other.gameObject);
            hp--;
        }
    }

    void Start()
    {
        scale = -1;
        startMS = moveSpeed;
        isWalking = false;
        isAttacking = false;
        hp = 3;
    }

    void Update()
    {

        if (isAttacking)
        {
            animator.SetBool("idle", false);
            animator.SetBool("attack", true);
            self.localScale = new Vector3(-scale, 1, 1);
            rigidbody2d.velocity = new Vector2(moveSpeed * scale * 4, rigidbody2d.velocity.y);
        }
        else if (isWalking)
        {
            animator.SetBool("idle", false);
            self.localScale = new Vector3(-scale, 1, 1);
            rigidbody2d.velocity = new Vector2(moveSpeed * scale, rigidbody2d.velocity.y);
        }

        if (!isAttacking)
        {
            animator.SetBool("attack", false);
        }
    }

    void FixedUpdate()
    {
        moveSpeed = startMS + (self.position.x / 100);

        pos = self.position + new Vector3(- 0.875f * -scale, 0.5625f, 0);

        RaycastHit2D seeGround = Physics2D.Raycast(pos, Vector2.left * -scale, 1f, lmGround),
            seePlayer = Physics2D.Raycast(pos, Vector2.left * -scale, 7f, lmPlayer);

        if (seeGround) jump();
        if (seePlayer) isAttacking = true;
        else isAttacking = false;

        if (self.position.y < -15 || hp <= 0) Destroy(this.gameObject);
    }

    public void turn()
    {
        if (!isAttacking) scale *= -1;
    }

    public void idle()
    {
        if (!isAttacking)
        {
            isWalking = false;
            animator.SetBool("idle", true);
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
        }
    }

    public void walk()
    {
        isWalking = true;
    }

    void jump()
    {
        rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, 4);
    }
}