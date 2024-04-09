using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using sgSchedule;
using System;
public class ScheduleHolidayItem : MonoBehaviour
{
    public Text textComponent;
    [HideInInspector]
    public DateTime myDate;
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
            for(int i=0;i<Main.currentSchedule.dayDataList.Count;i++)
            {
                if(myDate.ToString("yyyy-MM-dd") == Main.currentSchedule.dayDataList[i].day)//휴일로 고른 날이 근무일정이 있다면
                {
                    Debug.Log("근무 있는 휴일이에요.");
                    string thatWorker = Main.currentSchedule.dayDataList[i].worker;
                    for (int j=0; j<Main.currentWorkerList.workerList.Count;j++)//근무자 목록을 순회하고
                    {
                        if (Main.currentWorkerList.workerList[j].name == thatWorker)//해당 근무자를 찾아서
                        {
                            Debug.Log("근무자는 : " + Main.currentWorkerList.workerList[j].name);
                            switch(Main.currentSchedule.dayDataList[i].dayWeek)//근로자의 근무요일에서 공휴일로 이동
                            {
                                case 0:
                                    Main.currentWorkerList.workerList[j].mon.RemoveAll(day => day==Main.currentSchedule.dayDataList[i].day);
                                    Main.currentWorkerList.workerList[j].holi.Add(Main.currentSchedule.dayDataList[i].day);
                                    Main.currentSchedule.dayDataList[i].dayWeek = 7;
                                    Debug.Log("빠진요일은 월요일");
                                    return;
                                case 1:
                                    Main.currentWorkerList.workerList[j].tues.RemoveAll(day => day==Main.currentSchedule.dayDataList[i].day);
                                    Main.currentWorkerList.workerList[j].holi.Add(Main.currentSchedule.dayDataList[i].day);
                                    Main.currentSchedule.dayDataList[i].dayWeek = 7;
                                    Debug.Log("빠진요일은 화요일");
                                    return;
                                case 2:
                                    Main.currentWorkerList.workerList[j].wednes.RemoveAll(day => day==Main.currentSchedule.dayDataList[i].day);
                                    Main.currentWorkerList.workerList[j].holi.Add(Main.currentSchedule.dayDataList[i].day);
                                    Main.currentSchedule.dayDataList[i].dayWeek = 7;
                                    Debug.Log("빠진요일은 수요일");
                                    return;
                                case 3:
                                    Main.currentWorkerList.workerList[j].thurs.RemoveAll(day => day==Main.currentSchedule.dayDataList[i].day);
                                    Main.currentWorkerList.workerList[j].holi.Add(Main.currentSchedule.dayDataList[i].day);
                                    Main.currentSchedule.dayDataList[i].dayWeek = 7;
                                    Debug.Log("빠진요일은 목요일");
                                    return;
                                case 4:
                                    Main.currentWorkerList.workerList[j].fri.RemoveAll(day => day==Main.currentSchedule.dayDataList[i].day);
                                    Main.currentWorkerList.workerList[j].holi.Add(Main.currentSchedule.dayDataList[i].day);
                                    Main.currentSchedule.dayDataList[i].dayWeek = 7;
                                    Debug.Log("빠진요일은 금요일");
                                    return;
                                case 5:
                                    Main.currentWorkerList.workerList[j].satur.RemoveAll(day => day==Main.currentSchedule.dayDataList[i].day);
                                    Main.currentWorkerList.workerList[j].holi.Add(Main.currentSchedule.dayDataList[i].day);
                                    Main.currentSchedule.dayDataList[i].dayWeek = 7;
                                    Debug.Log("빠진요일은 토요일");
                                    return;
                                case 6:
                                    Main.currentWorkerList.workerList[j].sun.RemoveAll(day => day==Main.currentSchedule.dayDataList[i].day);
                                    Main.currentWorkerList.workerList[j].holi.Add(Main.currentSchedule.dayDataList[i].day);
                                    Main.currentSchedule.dayDataList[i].dayWeek = 7;
                                    Debug.Log("빠진요일은 일요일");
                                    return;
                            }
                        }
                    }
                }
            }
            
        }
        else
        {
            Main.currentSchedule.holidayTotal.Remove(myDate.ToString("yyyy-MM-dd"));
            textComponent.color = Color.white;
            for(int i=0;i<Main.currentSchedule.dayDataList.Count;i++)
            {
                if(myDate.ToString("yyyy-MM-dd") == Main.currentSchedule.dayDataList[i].day)//휴일 제거한 날이 근무일정이 있다면
                {
                    DateTime thatWeek = Convert.ToDateTime(Main.currentSchedule.dayDataList[i].day);
                    int dayWeek = GetDays(thatWeek.DayOfWeek);
                    Debug.Log("근무 있는 휴일이에요. 뺄게요~");
                    string thatWorker = Main.currentSchedule.dayDataList[i].worker;
                    for (int j=0; j<Main.currentWorkerList.workerList.Count;j++)//근무자 목록을 순회하고
                    {
                        if (Main.currentWorkerList.workerList[j].name == thatWorker)//해당 근무자를 찾아서
                        {
                            Debug.Log("근무자는 : " + Main.currentWorkerList.workerList[j].name + " " + Main.currentSchedule.dayDataList[i].dayWeek);
                            Main.currentWorkerList.workerList[j].holi.RemoveAll(day => day==Main.currentSchedule.dayDataList[i].day);
                            
                            switch(dayWeek)//근로자의 근무요일에서 공휴일로 이동
                            {
                                case 0:
                                    Main.currentWorkerList.workerList[j].mon.Add(Main.currentSchedule.dayDataList[i].day);
                                    Debug.Log("빠진휴일은 월요일");
                                    break;
                                case 1:
                                    Main.currentWorkerList.workerList[j].tues.Add(Main.currentSchedule.dayDataList[i].day);
                                    Debug.Log("빠진요일은 화요일");
                                    break;
                                case 2:
                                    Main.currentWorkerList.workerList[j].wednes.Add(Main.currentSchedule.dayDataList[i].day);
                                    Debug.Log("빠진요일은 수요일");
                                    break;
                                case 3:
                                    Main.currentWorkerList.workerList[j].thurs.Add(Main.currentSchedule.dayDataList[i].day);
                                    Debug.Log("빠진요일은 목요일");
                                    break;
                                case 4:
                                    Main.currentWorkerList.workerList[j].fri.Add(Main.currentSchedule.dayDataList[i].day);
                                    Debug.Log("빠진요일은 금요일");
                                    break;
                                case 5:
                                    Main.currentWorkerList.workerList[j].satur.Add(Main.currentSchedule.dayDataList[i].day);
                                    Debug.Log("빠진요일은 토요일");
                                    break;
                                case 6:
                                    Main.currentWorkerList.workerList[j].sun.Add(Main.currentSchedule.dayDataList[i].day);
                                    Debug.Log("빠진요일은 일요일");
                                    break;
                            }
                            Main.currentSchedule.dayDataList[i].dayWeek = dayWeek;
                        }
                    }
                }
            }
        }
        Main.SaveDataFile();
    }

    int GetDays(DayOfWeek day)
    {
        switch (day)
        {
            case DayOfWeek.Monday: return 0;
            case DayOfWeek.Tuesday: return 1;
            case DayOfWeek.Wednesday: return 2;
            case DayOfWeek.Thursday: return 3;
            case DayOfWeek.Friday: return 4;
            case DayOfWeek.Saturday: return 5;
            case DayOfWeek.Sunday: return 6;
        }

        return 0;
    }
}
