using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DdayManager : MonoBehaviour {

    public int Dday;

	// Use this for initialization
	void Start ()
    {
        PlayerPrefs.SetInt("Day", 1);
        PlayerPrefs.SetInt("Dday", Dday);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
