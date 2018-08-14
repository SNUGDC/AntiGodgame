using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventControl : MonoBehaviour {

    public int maxMineCount, badBound, normalBound, goodBound;
    public bool gameEnd = false;
    public Text timerText;
    public Text bugCountText;
    public GameObject result;
    public Image fade;

    private Element[,] elements;
    private Element elem;
    private int mineCount = 0;
    private int bugCount = 0;
    private float timer = 30.0f;

	// Use this for initialization
	void Start () {
        elements = GridControl.elements;
        if(mineCount != maxMineCount)
        {
            ModifyMineCount();
        }
	}

    public void MineCountUp()
    {
        mineCount++;
    }

    public void MineCountDown()
    {
        mineCount--;
    }

    private void ModifyMineCount()
    {
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
        Text resultText = result.gameObject.GetComponentInChildren<Text>();
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
        fade.gameObject.SetActive(true);
        result.gameObject.SetActive(true);
    }

    public void TimerModify(float time)
    {
        timer += time;
    }

    public float GetTimer()
    {
        return timer;
    }

    private void EndOfTimer()
    {
        print("Time Over!");
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
