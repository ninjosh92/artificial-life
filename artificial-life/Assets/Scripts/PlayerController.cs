using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject playerObject;
    private SpriteRenderer spriteRend;
    private Rigidbody2D rigid;
    private Collider2D collide;
    public bool isGround = true;
    public float walkSpeed = 10;
    public float jumpForce = 2;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        collide = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        FlipSprite();
        Jump();
    }

    void Walk()
    {
        float HMovement = Input.GetAxis("Horizontal") * walkSpeed;
        //float VMovement = Input.GetAxis("Vertical") * walkSpeed;
        rigid.velocity = new Vector2(HMovement, rigid.velocity.y);// VMovement);
    }

    void FlipSprite()
    {
        if (spriteRend != null)
        {
            // if left key is pressed
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                // flip the sprite
                spriteRend.flipX = true;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                spriteRend.flipX = false;
            }

        }
    }

    void Jump()
    {
        if (isGround && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 10);

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }
}
