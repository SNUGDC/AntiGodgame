﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPhysics : MonoBehaviour {

    public float jumpFactor;
    public bool isOnGround = false;

    private Rigidbody2D rb;
    private Character character;
    private GameControl gc;
    private Quaternion startQuat;
    private GameObject collidedTerrain;
    private bool isHeadingTerrain = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        character = transform.parent.GetComponent<Character>();
        gc = GameObject.Find("GameControl").GetComponent<GameControl>();
        startQuat = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        transform.rotation = startQuat;
        if (!GameControl.isGameEnd)
        {
            if (isOnGround)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
                {
                    Jump();
                }
            }
            if (collidedTerrain != null && transform.position.y > collidedTerrain.transform.position.y + 5.0f)
            {
                gc.SetIsTerrainMoveAvailable(true);
            }
        }
	}

    private void Jump()
    {
        isOnGround = false;
        rb.velocity = new Vector2(0, 1.0f) * jumpFactor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collidedTerrain = collision.gameObject;
            if (!character.GetIsInvincible())
            {
                print("is Hit");
                gc.ModifyTimer(-1.0f);
                character.isHit = true;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground") || collision.transform.CompareTag("Enemy"))
        {
            isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Ground") || collision.transform.CompareTag("Enemy"))
        {
            isOnGround = false;
            collidedTerrain = null;
        }
    }

    public void SetIsHeadingTerrain(bool b)
    {
        isHeadingTerrain = b;
    }
}
