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

        if(program_value - _progress <= 0)
            PlayerPrefs.SetInt("Progress", 0);
        else
            PlayerPrefs.SetInt("Progress", progress_value - _progress);

        if(PM_value - _PM <= 0)
            PlayerPrefs.SetInt("PM", 0);
        else 
            PlayerPrefs.SetInt("PM", PM_value - _PM);

        if(program_value - _program <= 0)
            PlayerPrefs.SetInt("Programmer", 0);
        else 
            PlayerPrefs.SetInt("Programmer", program_value - _program);

        if(art_value - _art <= 0)
            PlayerPrefs.SetInt("Art", 0);
        else
            PlayerPrefs.SetInt("Art", art_value - _art);

        if(sound_value - _sound <= 0)
            PlayerPrefs.SetInt("Sound", sound_value - _sound);

        else
            PlayerPrefs.SetInt("Sound", sound_value - _sound);
    }

}
