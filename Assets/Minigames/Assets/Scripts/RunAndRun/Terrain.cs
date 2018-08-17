using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour {

    public float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameControl.isGameEnd)
        {
            Move();
        }
        if(transform.position.x < -15.0f)
        {
            Destroy(gameObject);
        }
	}

    private void Move()
    {
        transform.position += new Vector3(1.0f, 0, 0) * moveSpeed;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}
