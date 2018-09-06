using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventList : MonoBehaviour {

    public static List<EventPara> _eventList;
    
    public EventList()
    {
        //기획 이벤트
        _eventList.Add(new EventPara(5, 5, 0, 0, 0));
        _eventList.Add(new EventPara(5, 5, 0, 0, 0));
        _eventList.Add(new EventPara(3, 5, 0, 0, 0));
        _eventList.Add(new EventPara(7, 5, 0, 0, 0));
        _eventList.Add(new EventPara(5, 5, 0, 0, 0));
        
        //프로그래밍 이벤트
        _eventList.Add(new EventPara(10, 0, 5, 0, 0));
        _eventList.Add(new EventPara(7, 0, 10, 0, 0));
        _eventList.Add(new EventPara(5, 0, 15, 0, 0));
        _eventList.Add(new EventPara(5, 0, 15, 0, 0));
        _eventList.Add(new EventPara(7, 0, 5, 0, 0));

        //아트 이벤트
        _eventList.Add(new EventPara(10, 0, 0, 10, 0));
        _eventList.Add(new EventPara(5, 0, 0, 5, 0));
        _eventList.Add(new EventPara(5, 0, 0, 5, 0));
        _eventList.Add(new EventPara(5, 0, 0, 10, 0));
        _eventList.Add(new EventPara(5, 0, 0, 5, 0));

        //사운드 이벤트
        _eventList.Add(new EventPara(3, 0, 0, 0, 10));
        _eventList.Add(new EventPara(3, 0, 0, 0, 15));
        _eventList.Add(new EventPara(5, 0, 0, 0, 10));
        _eventList.Add(new EventPara(3, 0, 0, 0, 10));
        _eventList.Add(new EventPara(3, 0, 0, 0, 5));
    }

    public EventPara GetEvent(int n)
    {
        return _eventList[n];
    }
}
