using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject playerObject;
    private SpriteRenderer spriteRend;
    private Rigidbody2D rigid;
    private Collider2D collider;

    public float walkSpeed = 10;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        FlipSprite();
    }

    void Walk()
    {
        float HMovement = Input.GetAxis("Horizontal") * walkSpeed;
        float VMovement = Input.GetAxis("Vertical") * walkSpeed;
        rigid.velocity = new Vector2(HMovement, VMovement);
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
}
