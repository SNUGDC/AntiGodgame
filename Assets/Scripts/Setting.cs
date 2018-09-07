using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour {

    public int DDay;

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Day",1);
        PlayerPrefs.SetInt("DDay", DDay);
        PlayerPrefs.SetInt("Progress", 0);
        PlayerPrefs.SetInt("PM", 100);
        PlayerPrefs.SetInt("Programmer", 100);
        PlayerPrefs.SetInt("Art", 100);
        PlayerPrefs.SetInt("Sound", 100);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
