using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaliseMove : MonoBehaviour
{
    public float speed;
    public float speedUp;
    public float massUp;
    public float animateUp;

    public float animSpeed;

    Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        Move();
    }

    private void Update()
    {
        Accelerate();
    }

    void Move()
    {
        rb.velocity = new Vector3(-speed, 0, 0);
    }

    void Accelerate()
    {
        rb.velocity += new Vector2(-speedUp, 0);
        rb.mass += massUp;
        animSpeed += animateUp;
        animator.speed = animSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            AdaliseGame.instance.Finish();
        }
    }
}
