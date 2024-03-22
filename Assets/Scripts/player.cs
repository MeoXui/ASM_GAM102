using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Transform transform, hpTransform;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody2d;
    public Animator animator;
    public AudioSource audioSource;

    public Slider hp;
    public Image fillImage;

    public float jumpForce, moveSeped;
    public int jumpsNumber;
    int jumpCounter;

    public List<AudioClip> audioClips;

    bool isOnAir = true;

    public gameManager gm;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            gm.AddScore(1);
            audioSource.PlayOneShot(audioClips[0]);
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Bullet")
        {
            takeDmg(0.35f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isOnAir = false;
            jumpCounter = jumpsNumber;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isOnAir = true;
            jumpCounter = jumpsNumber - 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        hp.maxValue = 1;
        hp.value = hp.maxValue;
        gm.Load();
        transform.position = new Vector3(0, 0, 0);
        rigidbody2d.velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)
            || Input.GetKeyDown(KeyCode.UpArrow)
            || Input.GetKeyDown(KeyCode.W)) jump();

        if (Input.GetKey(KeyCode.DownArrow)
            || Input.GetKey(KeyCode.S)) fastFall();

        //if (Input.GetKey(KeyCode.LeftArrow)
        //    || Input.GetKey(KeyCode.A)) run(-1);
        //else if (Input.GetKey(KeyCode.RightArrow)
        //    || Input.GetKey(KeyCode.D)) run(1);
        //else idle();

        run(1);

        AnimProcess();
    }

    // FixedUpdate is called once per 0.02s
    void FixedUpdate()
    {
        moveSeped = 7 + (transform.position.x / 100);

        if (transform.position.x < -15
            || transform.position.y < -15)
            dead();

        if (hp.value == 0) dead();
    }

    void AnimProcess()
    {
        if (rigidbody2d.velocity.x != 0)
        {
            animator.SetBool("idle", false);
            animator.SetBool("run", true);
        } else
        {
            animator.SetBool("idle", true);
            animator.SetBool("run", false);
        }

        if (rigidbody2d.velocity.y < 0 && isOnAir)
        {
            animator.SetBool("jump", false);
            animator.SetBool("fall", true);
        }
        else if (rigidbody2d.velocity.y > 0 && isOnAir)
        {
            animator.SetBool("jump", true);
            animator.SetBool("fall", false);
        }
        else
        {
            animator.SetBool("jump", false);
            animator.SetBool("fall", false);
        }
    }

    void idle()
    {
        rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
    }

    void run(int scale)
    {
        transform.localScale = new Vector3(scale, 1, 1);
        hpTransform.localScale = new Vector3(scale, 1, 1);
        rigidbody2d.velocity = new Vector2(moveSeped * scale, rigidbody2d.velocity.y);
    }

    void jump()
    {
        if (jumpCounter > 0)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpForce);
            audioSource.PlayOneShot(audioClips[2]);
            jumpCounter--;
        }
    }

    void fastFall()
    {
        if (isOnAir)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, rigidbody2d.velocity.y - 0.5f);
        }
    }

    void takeDmg(float dmg)
    {
        hp.value -= dmg;
    }

    void dead()
    {
        audioSource.PlayOneShot(audioClips[1]);
        Start();
    }
}
