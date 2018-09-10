using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour {

    public int DDay;

	// Use this for initialization
	void Start () {

        PlayerPrefs.SetInt("DDay", DDay);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
