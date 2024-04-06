using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using sgSchedule;
using System;
public class ScheduleHolidayItem : MonoBehaviour
{
    public Text textComponent;
    DateTime myDate;
    public bool holiday;
    public DateTime _myDate
    {
        get
        {
            return myDate;
        }
        set
        {
            myDate = value;
            string dataString = myDate.ToString("yyyy-MM-dd");
            if (Main.currentSchedule.holidayTotal.Contains(dataString))
            {
                Debug.Log("안들어오나?");
                holiday = true;
                textComponent.color = Color.blue;
            }
        }
    }

    public void clickItem()
    {
        holiday = !holiday;
        if (holiday)
        {
            Main.currentSchedule.holidayTotal.Add(myDate.ToString("yyyy-MM-dd"));
            textComponent.color = Color.blue;
        }
        else
        {
            Main.currentSchedule.holidayTotal.Remove(myDate.ToString("yyyy-MM-dd"));
            textComponent.color = Color.white;
        }
        Main.SaveDataFile();
    }

    
}
