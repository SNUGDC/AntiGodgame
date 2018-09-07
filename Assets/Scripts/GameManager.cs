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
    private EventList eventlist = new EventList();
    private string scenarioLabel;
    private int day;

    private int _eventNum;
    private int _endNum;

    // Use this for initialization
    void Start ()
    {
        day = PlayerPrefs.GetInt("Day");
        ParameterSetting();
        if(sceneName == "Start")
        {
            scenarioLabel = sceneName + "Day" + day;
        }

        else if(sceneName == "Event")
        {
            _eventNum = Random.Range(0, 20);
            scenarioLabel = sceneName + _eventNum;
        }

        else
        {
            _endNum = Random.Range(0, 5);
            scenarioLabel = sceneName + _endNum;
        }
        
        CallDialogue();
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
            if(sceneName == "Start")
            {
                SceneManager.LoadScene(scheduleList.GetSchedule(day - 1));
            }

            else if(sceneName == "Event")
            {
                eventlist.GetEvent(_eventNum).UpdatePara();
                SceneManager.LoadScene("EndDialogue");
            }

            else
            {
                SceneManager.LoadScene("Home");
            }
        }

    }

    
}
