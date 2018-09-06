using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPara : MonoBehaviour
{
    public int _progress;
    public int _PM;
    public int _program;
    public int _art;
    public int _sound;

    public EventPara(int progress, int PM, int program, int art, int sound)
    {
        _progress = progress;
        _PM = PM;
        _program = program;
        _art = art;
        _sound = sound;
    }

    public void UpdatePara()
    {
        int progress_value = PlayerPrefs.GetInt("Progress");
        int PM_value = PlayerPrefs.GetInt("PM");
        int program_value = PlayerPrefs.GetInt("Programmer");
        int art_value = PlayerPrefs.GetInt("Art");
        int sound_value = PlayerPrefs.GetInt("Sound");

        PlayerPrefs.SetInt("Progress", progress_value - _progress);
        PlayerPrefs.SetInt("PM", PM_value - _PM);
        PlayerPrefs.SetInt("Programmer", program_value - _program);
        PlayerPrefs.SetInt("Art", art_value - _art);
        PlayerPrefs.SetInt("Sound", sound_value - _sound);
    }

}
