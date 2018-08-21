using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float moveSpeed;

    public bool isHit = false;
    public bool isInvincible = false;

    private UITextControl utc;
    private SpriteRenderer sr;
    private CharacterPhysics cp;
    private Ray ray;
    private RaycastHit hit;
    private bool isHeadingTerrain = false;

	// Use this for initialization
	void Start () {
        utc = GameObject.Find("GameControl").GetComponent<UITextControl>();
        sr = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        cp = GetComponent<CharacterPhysics>();
        ray = new Ray(transform.position, Vector2.right);
    }
	
	// Update is called once per frame
	void Update () {
        if (!GameControl.isGameEnd)
        {
            Move();
            if (isHit && !isInvincible)
            {
                OnCharacterHit();
            }
        }
	}

    private void FixedUpdate()
    {
        if (Physics.Raycast(ray, out hit, 1.0f))
        {
            if (hit.transform.tag == "Enemy")
            {
                isHeadingTerrain = true;
            }
            else
            {
                isHeadingTerrain = false;
            }
        }
    }

    private void Move()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f) * moveSpeed;
    }

    private void OnCharacterHit()
    {
        isHit = false;
        if (!utc.GetIsCreatedText())
        {
            utc.InstantiateText();
            utc.SetIsCreatedText(true);
        }
        StartCoroutine("TemporaryInvincibility");
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

    public bool GetIsHeadingTerrain()
    {
        return isHeadingTerrain;
    }
}
