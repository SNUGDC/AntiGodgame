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
    public Text dayNum;

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

        dayNum.text = day.ToString();


        if (sceneName == "Start")
        {
            if (day >= 8 && day <= 21)
            {
                int random = Random.Range(0, 2);
                if (random == 0)
                {
                    SceneManager.LoadScene("EventDialogue");
                }
                else
                {
                    SceneManager.LoadScene("WorkDialogue");
                }
            }

            scenarioLabel = sceneName + "Day" + day;
        }

        else if(sceneName == "Event")
        {
            _eventNum = Random.Range(0, 20);
            scenarioLabel = sceneName + _eventNum;
        }

        else if(sceneName == "Work")
        {
            _endNum = Random.Range(0, 5);
            scenarioLabel = sceneName + _endNum;
        }

        else
        {
            if(day >= 4 && day <=6)
            {
                scenarioLabel = "EndDay" + day;
            }
            
            else if(day>=23 && day<=26)
            {
                scenarioLabel = "EndDay" + day;
            }

            else
            {
                _endNum = Random.Range(0, 5);
                scenarioLabel = sceneName + _endNum;
            }
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
        if (sceneName == "Start" && day == 22) StartCoroutine(Day22());
        else StartCoroutine(StartDialogue());
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

            else if(sceneName == "Work")
            {
                SceneManager.LoadScene("SelectMiniGame");
            }

            else
            {
                SceneManager.LoadScene("Home");
            }
        }

    }

    IEnumerator Day22()
    {
        engine.JumpScenario("StartDay22");

        while(!engine.IsPausingScenario)
        {
            yield return 0;
        }

        if (PlayerPrefs.GetInt("Progress") < 30)
        {
            engine.JumpScenario("Day22-1");

            while (!engine.IsEndScenario) yield return 0;
        }

        else if (PlayerPrefs.GetInt("Progress") > 70)
        {
            engine.JumpScenario("Day22-2");

            while (!engine.IsEndScenario) yield return 0;
        }

        else
        {
            engine.JumpScenario("Day22-3");

            while (!engine.IsEndScenario) yield return 0;
        }

        engine.JumpScenario("Day22End");

        while (!engine.IsEndScenario) yield return 0;

        if (engine.IsEndScenario)
            SceneManager.LoadScene(scheduleList.GetSchedule(day - 1));

    }

}
