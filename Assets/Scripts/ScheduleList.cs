using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleList : MonoBehaviour {

    public List<string> _schedules;

    public ScheduleList()
    {
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");

        _schedules.Add("Home");
        _schedules.Add("EventDialogue");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("EventDialogue");
        _schedules.Add("Home");
        _schedules.Add("EventDialogue");

        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");

        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");

        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");

        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");

        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        /* rest of elements */
    }

    public string GetSchedule(int n)
    {
        return _schedules[n];
    }
    
}
