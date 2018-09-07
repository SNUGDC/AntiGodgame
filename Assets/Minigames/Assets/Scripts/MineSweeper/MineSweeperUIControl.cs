using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineSweeperUIControl : MonoBehaviour {

    public Text gameStartText;
    public Image gameStartImage;

    // Use this for initialization
    void Start()
    {
        gameStartText.text = "";
        if (!EventControl.isGameStart)
        {
            StartCoroutine(GameStart());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator GameStart()
    {
        gameStartImage.gameObject.SetActive(true);
        for (int i = 3; i >= 0; i--)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            gameStartText.gameObject.SetActive(true);
            if (i == 0)
            {
                gameStartText.text = "START";
                yield return new WaitForSecondsRealtime(1.0f);
            }
            else
            {
                gameStartText.text = i.ToString();
                yield return new WaitForSecondsRealtime(0.5f);
            }
            gameStartText.gameObject.SetActive(false);
        }
        gameStartImage.gameObject.SetActive(false);
        EventControl.isGameStart = true;
    }

}
