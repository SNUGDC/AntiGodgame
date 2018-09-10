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

        if (day % 2 == 0)
        {
            PlayerPrefs.SetInt("PM", pm + 1);
            PlayerPrefs.SetInt("Programmer", programmer + 1);
            PlayerPrefs.SetInt("Art", art + 1);
            PlayerPrefs.SetInt("Sound", sound + 1);
            PlayerPrefs.SetInt("Progress", progress + 5);
        }
        else
        {
            PlayerPrefs.SetInt("PM", pm + 2);
            PlayerPrefs.SetInt("Programmer", programmer + 2);
            PlayerPrefs.SetInt("Art", art + 2);
            PlayerPrefs.SetInt("Sound", sound + 2);
            PlayerPrefs.SetInt("Progress", progress + 6);
        }

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

    public void LoadGame()
    {
        SceneManager.LoadScene("StartDialogue");
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("Day", 1);
        PlayerPrefs.SetInt("Progress", 0);
        PlayerPrefs.SetInt("PM", 20);
        PlayerPrefs.SetInt("Programmer", 20);
        PlayerPrefs.SetInt("Art", 20);
        PlayerPrefs.SetInt("Sound", 20);

        SceneManager.LoadScene("StartDialogue");
    }

    public void Quit()
    {
        Application.Quit();
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
