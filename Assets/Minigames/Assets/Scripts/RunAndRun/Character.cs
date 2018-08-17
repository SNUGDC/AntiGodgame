using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float moveSpeed;
    public float jumpFactor;

    private Rigidbody2D rb;
    private bool isOnGround = true;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameControl.isGameEnd)
        {
            if (isOnGround)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
                {
                    Jump();
                }
            }
            Move();
        }
	}

    private void Jump()
    {
        isOnGround = false;
        rb.velocity = new Vector2(0, 1.0f) * jumpFactor;
    }

    private void Move()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            //Decrease timer
        }
        else if (collision.transform.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
