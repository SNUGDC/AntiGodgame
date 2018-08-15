using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerEventControl : MonoBehaviour {

    public float timerStart;
    public GameObject ctrl;

    private bool gameEnd = false;
    private float timer;
    private int count = 0;

    private Text timerText;
    private Text countText;


	// Use this for initialization
	void Start () {
        timer = timerStart;
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
        countText = GameObject.Find("CountText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        timerText.text = timer.ToString() + "초";
        countText.text = "HITS: " + count.ToString();

		if(timer > 0 && !gameEnd)
        {
            timer -= Time.deltaTime;
        }
        else if(timer <= 0)
        {
            timer = 0;
            gameEnd = true;
        }
        if (gameEnd)
        {
            OnGameEnd();
        }
	}

    private void OnGameEnd()
    {
        //TODO: Do something on game end
        Button btn = GameObject.Find("CtrlButton").GetComponent<Button>();
        btn.enabled = false;
    }

    public void ModifyCount(int mdfy)
    {
        count += mdfy;
    }
}
