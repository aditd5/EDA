using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpcomMovement : MonoBehaviour
{

    private Rigidbody2D body;
    public float speed;
    private Animator animator;

    // Start is called before the first frame update
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
    }
}
