using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveObstacle : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Character"))
        {
            transform.parent.Find("Sprite").localScale = new Vector3(1.5f, 1.5f, 1.0f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Character"))
        {
            transform.parent.Find("Sprite").localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
}
