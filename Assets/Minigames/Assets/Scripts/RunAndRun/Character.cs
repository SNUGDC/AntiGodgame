using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float moveSpeed;

    public bool isHit = false;
    public bool isInvincible = false;

    private Rigidbody2D rb;
    private GameControl gc;
    private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        gc = GameObject.Find("GameControl").GetComponent<GameControl>();
        sr = transform.Find("Sprite").GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!GameControl.isGameEnd)
        {
            Move();
            if (isHit && !isInvincible)
            {
                isHit = false;
                StartCoroutine("TemporaryInvincibility");
            }
        }
	}

    private void Move()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * moveSpeed;
    }

    IEnumerator TemporaryInvincibility()
    {
        Color originalColor = sr.color;

        isInvincible = true;
        sr.color = Color.white;
        yield return new WaitForSecondsRealtime(1.0f);
        isInvincible = false;
        sr.color = originalColor;
    }

    public bool GetIsInvincible()
    {
        return isInvincible;
    }
}
