using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomd : MonoBehaviour
{
    public Transform self;
    public Rigidbody2D rigidbody2d;
    public Animator animator;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            animator.SetBool("on air", false);
        }
        animator.SetBool("explo", true);
        Destroy(this.gameObject, 0.5f);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (self.position.y < -15) Destroy(this.gameObject);
    }
}
