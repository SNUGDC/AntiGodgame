using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventControl : MonoBehaviour {

    public int maxMineCount, badBound, normalBound, goodBound;
    public float timerStart;

    public static Element[,] mineElements;
    public Text timerText;
    public Text bugCountText;

    private Element[,] elements;
    private int mineCount = 0;
    private int bugCount = 0;
    private float timer;
    private bool gameEnd = false;

    private GameObject endObject;

	// Use this for initialization
	void Start () {
        timer = timerStart;
        endObject = GameObject.Find("GameEnd");
        endObject.SetActive(false);
        elements = GridControl.elements;
        if(mineCount != maxMineCount)
        {
            ModifyMineCount();
        }
	}

    private void ModifyMineCount()
    {
        Element elem;
        if (mineCount > maxMineCount)
        {
            elem = elements[Random.Range(0, GridControl.w), Random.Range(0, GridControl.h)];
            while (!elem.mine && mineCount > 0)
            {
                elem = elements[Random.Range(0, GridControl.w), Random.Range(0, GridControl.h)];
            }
            elem.mine = false;
            MineCountDown();
            ModifyMineCount();
        }
        else if (mineCount < maxMineCount)
        {
            elem = elements[Random.Range(0, GridControl.w), Random.Range(0, GridControl.h)];
            elem.mine = true;
            MineCountUp();
            ModifyMineCount();
        }
    }

    public void MineCountDown()
    {
        mineCount--;
    }

    public void MineCountUp()
    {
        mineCount++;
    }

    // Update is called once per frame
    void Update () {
        timerText.text = timer.ToString() + "초";
        bugCountText.text = "BUGS: " + bugCount.ToString() + "/" + maxMineCount.ToString();
		if(timer > 0 && !gameEnd)
        {
            timer -= Time.deltaTime;
        }
        else
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

        Text resultText = endObject.transform.Find("Result").gameObject.GetComponentInChildren<Text>();
        GridControl.UncoverMines();
        if (bugCount > 0 && bugCount <= badBound)
        {
            resultText.text = "BAD";
        }
        else if (bugCount <= normalBound)
        {
            resultText.text = "NORMAL";
        }
        else if (bugCount <= goodBound)
        {
            resultText.text = "GOOD";
        }
        else if (bugCount <= maxMineCount)
        {
            resultText.text = "OVER";
        }
        endObject.SetActive(true);
    }

    public void TimerModify(float time)
    {
        timer += time;
    }

    public float GetTimer()
    {
        return timer;
    }

    public void BugCountUp()
    {
        bugCount++;
    }

    public void BugCountDown()
    {
        bugCount--;
    } 

    public int GetBugCount()
    {
        return bugCount;
    }
}
