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
    private int resultParameter = 0;

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
        GridControl.UncoverMines();
        string txt;
        if(bugCount > 0){
            txt = bugCount <= badBound ? "BAD" : bugCount <= normalBound ? "NORMAL" : bugCount <= goodBound ? "GOOD" : bugCount <= maxMineCount ? "OVER";
            resultParameter = bugCount <= badBound ? +3 : bugCount <= normalBound ? 0 : bugCount <= goodBound ? -3 : bugCount <= maxMineCount ? -5;
        }
        SetResult(txt, resultParameter);
        endObject.SetActive(true);
        ModifyProgrammerParameter(resultParameter);
    }

    private void ModifyProgrammerParameter(int param){
        PlayerPref.SetInt("Programmer", PlayerPref.GeInt("Programmer") + param);
    }

    private void SetResult(string rsltTxt, int rsltPrm){
        Text resultText = endObject.transform.Find("Result").gameObject.GetComponentInChildren<Text>();
        resultText.text = rsltText;
        resultParameter = rsltPrm;
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
