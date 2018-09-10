using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;
using UnityEngine.SceneManagement;


public class EndingManager : MonoBehaviour {

    public AdvEngine engine;
    public GameObject backGround;

    private string scenarioLabel;

    private void Start()
    {
        if(CheckOfferingEnding())
        {
            scenarioLabel = "Offering";
            backGround.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Offering");
        }

        else if(PlayerPrefs.GetInt("Progress") >= 100)
        {
            scenarioLabel = "Doom";
            backGround.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Doom");
        }

        else
        {
            scenarioLabel = "Sabotage";
        }

        StartCoroutine(StartDialogue());
    }

    public bool CheckOfferingEnding()
    {
        if (PlayerPrefs.GetInt("PM") <= 0) return true;
        else if (PlayerPrefs.GetInt("Programmer") <= 0) return true;
        else if (PlayerPrefs.GetInt("Art") <= 0) return true;
        else if (PlayerPrefs.GetInt("Sound") <= 0) return true;

        else return false;

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

        if (engine.IsEndScenario) SceneManager.LoadScene("Main");

    }

}
