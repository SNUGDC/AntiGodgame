using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utage;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public List<Slider> sliders;
    public AdvEngine engine;
    public string sceneName;

    private ScheduleList scheduleList = new ScheduleList();
    private string scenarioLabel;
    private int day;

    // Use this for initialization
    void Start ()
    {
        day = 13 - PlayerPrefs.GetInt("Dday");
        ParameterSetting();
        scenarioLabel = sceneName + "Day" + day;
        CallDialogue();
        Debug.Log(scheduleList.getSchedule(day));
	}

    void ParameterSetting()
    {
        sliders[0].value = PlayerPrefs.GetInt("Progress");
        sliders[1].value = PlayerPrefs.GetInt("PM");
        sliders[2].value = PlayerPrefs.GetInt("Programmer");
        sliders[3].value = PlayerPrefs.GetInt("Art");
        sliders[4].value = PlayerPrefs.GetInt("Sound");
    }

    public void CallDialogue()
    {
        StartCoroutine(StartDialogue());
    }

    IEnumerator StartDialogue()
    {
        //Utageのシナリオを呼び出す
        engine.JumpScenario(scenarioLabel);

        //Utageのシナリオ終了待ち
        while (!engine.IsEndScenario)
        {
            yield return 0;
        }

        if (engine.IsEndScenario)
        {
            Debug.Log(scheduleList.getSchedule(day));
            SceneManager.LoadScene(scheduleList.getSchedule(day));
        }

    }

}
