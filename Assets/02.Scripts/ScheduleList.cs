using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sgSchedule;
using System;
public class ScheduleList : MonoBehaviour
{
    public GameObject Schedule;
    public GameObject Contents;
    // Start is called before the first frame update
    void OnEnable()
    {
        
        InitWorkerList();
    }

    public void InitWorkerList()
    {
        foreach (Transform child in Contents.transform)
        {
            Destroy(child.gameObject);
        }
        
        List<string> month = new List<string>();
        for (int i=0; i<Main.currentSchedule.dayDataList.Count; i++)
        {
            DateTime monthDate = Convert.ToDateTime(Main.currentSchedule.dayDataList[i].day);
            string monthString = monthDate.ToString("yyyy-MM");
            if (!month.Contains(monthString))
            {
                month.Add(monthString);
            }
        }
        for (int i=0; i<month.Count; i++)
        {
            GameObject game = GameObject.Instantiate(Schedule, Vector3.zero, Quaternion.identity);
            ScheduleBtnData data = game.GetComponent<ScheduleBtnData>();
            data._name = month[i];
            data.transform.parent = Contents.transform;
        }

    }
}
