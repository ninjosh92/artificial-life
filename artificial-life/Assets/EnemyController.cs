using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private bool dirRight = true;
    public float speed = 3;
    private SpriteRenderer sprite;
    private float startingX;

    // Use this for initialization
    void Start()
    {
        startingX = transform.position.x;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (dirRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            sprite.flipX = true;
        }
        else
        {
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
            sprite.flipX = false;
        }

        if (startingX - transform.position.x < 0)
        {
            dirRight = false;
        }

        if (startingX - transform.position.x > 8)
        {
            dirRight = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
