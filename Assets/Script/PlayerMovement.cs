using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D body;
    public float speed;
    public float jump;
    private Animator animator;
    private bool landed;

    //Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(hInput * speed, body.velocity.y);

        if(hInput > 0.01f)
        {
            animator.SetBool("shooting", false);
            transform.localScale = new Vector2(1,1);
        }

        if(hInput > -0.01f)
        {
            animator.SetBool("shooting", false);
            transform.localScale = new Vector2(-1,1);
        }

        if(Input.GetKey(KeyCode.UpArrow) && landed)
        {
            animator.SetBool("shooting", false);
            Jump();
        }

        animator.SetBool("run", hInput != 0);
        animator.SetBool("landed", landed);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jump);
        animator.SetTrigger("jump");
        landed = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            landed = true;
        }
    }
}
