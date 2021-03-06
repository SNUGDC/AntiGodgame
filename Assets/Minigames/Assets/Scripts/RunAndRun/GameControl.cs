﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static bool isGameEnd = false;
    public static bool isGameStart = false;

    public float timerStart;
    public GameObject endObject;
    public float badBound, normalBound, goodBound;

    private float timer;
    private int resultParameter = 0;
    private string resultText;
    private bool isGameEndOver = false;

    private void Start()
    {
        timer = timerStart;
    }

    private void Update()
    {
        if (isGameStart)
        {
            if (timer > 0)
            {
                OnGameNotEnd();
            }
            else
            {
                if (!isGameEndOver)
                {
                    OnGameEnd();
                }
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        ShowEndDialogue();
                    }
                }
            }
        }
    }

    private void OnGameNotEnd(){
        timer -= Time.deltaTime;
    }

    private void OnGameEnd()
    {
        isGameEndOver = true;
        timer = 0;
        isGameEnd = true;
        SetResultParameter();
        endObject.SetActive(true);
        ModifyPMParameter(resultParameter);
    }

    private void ShowEndDialogue()
    {
        SceneManager.LoadScene("EndDialogue");
    }

    private void SetResultParameter(){
        float runMeter = GetComponent<UITextControl>().GetRunMeter();
        if(runMeter > 0){
            if(runMeter <= badBound){
                SetResult("BAD", +3);
            }
            else if(runMeter <= normalBound){
                SetResult("NORMAL", 0);
            }
            else if(runMeter <= goodBound){
                SetResult("GOOD", -3);
            }
            else if(runMeter <= timerStart){
                SetResult("OVER", -5);
            }
        }
    }

    private void SetResult(string txt, int param){
        Text resultText = endObject.transform.Find("Result").transform.Find("Text").GetComponent<Text>();
        resultText.text = txt;
        resultParameter = param;
    }

    private void ModifyPMParameter(int param){
        PlayerPrefs.SetInt("PM", PlayerPrefs.GetInt("PM") + param);
    }

    public float GetTimer()
    {
        return timer;
    }
    public void ModifyTimer(float time)
    {
        timer += time;
    }
}
