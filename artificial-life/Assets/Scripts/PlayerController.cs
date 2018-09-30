using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject playerObject;
    private SpriteRenderer spriteRend;
    private Rigidbody2D rigid;
    private Collider2D collide;
    public float walkSpeed = 10;
    public float jumpForce = 2;

    [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character
   
    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.

    public AudioClip[] sounds;
    public AudioSource audioSrc;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        collide = GetComponent<Collider2D>();

        m_GroundCheck = transform.Find("GroundCheck");

    }

    // Update is called once per frame
    void Update()
    {
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.

       /// if (m_GroundCheck != null) { //////////
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                m_Grounded = true;
        }


   /// }///////

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
        if (m_Grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            m_Grounded = false;
            rigid.velocity = new Vector2(rigid.velocity.x, 10);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flashlight"))
        {
            respawn();
        }
    }

    private void respawn()
    {
        Vector3 temp = transform.position; // copy to an auxiliary variable...
        temp.x = 0f; // modify the component you want in the variable...
        temp.y = -6f;
        transform.position = temp; // and save the modified value
                                   // transform.position = startingPosition; // and save the modified value
        playsound(0);
    }

    private void playsound(int index)
    {
        audioSrc.clip = sounds[index];
        audioSrc.Play();
    }
}
