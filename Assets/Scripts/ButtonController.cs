using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    public string nextScene;

	public void StartNextDay()
    {
        int day = PlayerPrefs.GetInt("Day");
        PlayerPrefs.SetInt("Day", day + 1);

        SceneManager.LoadScene("StartDialogue");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
