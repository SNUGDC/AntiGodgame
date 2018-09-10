using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleList : MonoBehaviour {

    public List<string> _schedules = new List<string>();

    public ScheduleList()
    {
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Home");
        _schedules.Add("Runandrun");
        _schedules.Add("Minesweeper");
        _schedules.Add("Clicker");
        _schedules.Add("Home");

        _schedules.Add("Home");
        _schedules.Add("SelectMiniGame");
        _schedules.Add("EventDialogue");
        _schedules.Add("SelectMiniGame");
        _schedules.Add("EventDialogue");
        _schedules.Add("EndDialogue");
        _schedules.Add("EventDialogue");

        _schedules.Add("Home");
        _schedules.Add("SelectMiniGame");
        _schedules.Add("EventDialogue");
        _schedules.Add("SelectMiniGame");
        _schedules.Add("EventDialogue");
        _schedules.Add("EndDialogue");
        _schedules.Add("EventDialogue");

        _schedules.Add("SelectMiniGame");
        _schedules.Add("SelectMiniGame");
        _schedules.Add("SelectMiniGame");
        _schedules.Add("SelectMiniGame");
        _schedules.Add("SelectMiniGame");
        _schedules.Add("EventDialogue");

       
        /* rest of elements */
    }

    public string GetSchedule(int n)
    {
        return _schedules[n];
    }
    
}
