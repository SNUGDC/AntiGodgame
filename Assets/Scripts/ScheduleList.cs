using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleList : MonoBehaviour {

    private List<string> _schedules = new List<string>();

    public ScheduleList()
    {
        _schedules[0] = "Home";
        _schedules[0] = "Home";
        _schedules[0] = "Clicker";
        _schedules[0] = "Home";
        _schedules[0] = "Home";
        _schedules[0] = "Home";
        /* rest of elements */
    }

    public string getSchedule(int n)
    {
        return _schedules[n];
    }
    
}
