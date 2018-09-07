using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    public string nextScene;

	public void StartNextDay()
    {
        int day = PlayerPrefs.GetInt("Day");

        int progress = PlayerPrefs.GetInt("Progress");
        int pm = PlayerPrefs.GetInt("PM");
        int programmer = PlayerPrefs.GetInt("Programmer");
        int art = PlayerPrefs.GetInt("Art");
        int sound = PlayerPrefs.GetInt("Sound");

        PlayerPrefs.SetInt("Progress", progress + 5);
        PlayerPrefs.SetInt("PM", pm + 5);
        PlayerPrefs.SetInt("Programmer", programmer + 5);
        PlayerPrefs.SetInt("Art", art + 5);
        PlayerPrefs.SetInt("Sound", sound + 5);

        if (CheckEnding() || day + 1 == PlayerPrefs.GetInt("DDay"))
        {
            SceneManager.LoadScene("Ending");
        }

        else
        {
            PlayerPrefs.SetInt("Day", day + 1);
            SceneManager.LoadScene("StartDialogue");
        }
        
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public bool CheckEnding()
    {
        if (PlayerPrefs.GetInt("PM") <= 0) return true;
        else if (PlayerPrefs.GetInt("Programmer") <= 0) return true;
        else if (PlayerPrefs.GetInt("Art") <= 0) return true;
        else if (PlayerPrefs.GetInt("Sound") <= 0) return true;

        else if (PlayerPrefs.GetInt("Progress") >= 100) return true;

        else return false;

    }
}
