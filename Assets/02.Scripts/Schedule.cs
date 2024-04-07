using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class DayData
{
    public string day;
    public string worker;
    public int dayWeek;
    //0~6 월~일
    //8 holiday;
}
[Serializable]
public class Schedule
{
    public List<string> holidayTotal = new List<string>();
    public List<DayData> dayDataList = new List<DayData>();

}
