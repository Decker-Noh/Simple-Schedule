using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sgSchedule;
using System;
public class WorkerChangeItem : MonoBehaviour
{
    public string ClickWorker;
    public DateTime thatDate;
    public Worker ChoicedWorker;
    public DayData myDayData;
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
    }

    public void ChangeWorker()
    {
        for (int i=0; i<Main.currentSchedule.dayDataList.Count; i++) //스케줄 리스트에서 날짜 데이터 변경
        {
            if(Main.currentSchedule.dayDataList[i].day == thatDate.ToString("yyyy-MM-dd"))
            {
                Main.currentSchedule.dayDataList[i].worker = ChoicedWorker.name;
                myDayData = Main.currentSchedule.dayDataList[i];
                 //workerdata에서 정보 변경
                for (int j=0; j<Main.currentWorkerList.workerList.Count; j++) //워커리스트에서 워커 찾아서
                {
                    if(Main.currentWorkerList.workerList[j].name == ClickWorker) //원래 있던 워커에서 일한 날짜 빼주고
                    {
                        switch(myDayData.dayWeek)
                        {
                            case 0: //mon
                                for (int h=0; h<Main.currentWorkerList.workerList[j].mon.Count; h++)
                                {
                                    if(Main.currentWorkerList.workerList[j].mon[h] == myDayData.day)
                                    {
                                        Main.currentWorkerList.workerList[j].mon.Remove(myDayData.day);
                                    }
                                }
                                break;
                            case 1: //tues
                                for (int h=0; h<Main.currentWorkerList.workerList[j].tues.Count; h++)
                                {
                                    if(Main.currentWorkerList.workerList[j].tues[h] == myDayData.day)
                                    {
                                        Main.currentWorkerList.workerList[j].tues.Remove(myDayData.day);
                                    }
                                }
                                break;
                            case 2: //wednes
                                for (int h=0; h<Main.currentWorkerList.workerList[j].wednes.Count; h++)
                                {
                                    if(Main.currentWorkerList.workerList[j].wednes[h] == myDayData.day)
                                    {
                                        Main.currentWorkerList.workerList[j].wednes.Remove(myDayData.day);
                                    }
                                }
                                break;
                            case 3: //thurs
                                for (int h=0; h<Main.currentWorkerList.workerList[j].thurs.Count; h++)
                                {
                                    if(Main.currentWorkerList.workerList[j].thurs[h] == myDayData.day)
                                    {
                                        Main.currentWorkerList.workerList[j].thurs.Remove(myDayData.day);
                                    }
                                }
                                break;
                            case 4: //fri
                                for (int h=0; h<Main.currentWorkerList.workerList[j].fri.Count; h++)
                                {
                                    if(Main.currentWorkerList.workerList[j].fri[h] == myDayData.day)
                                    {
                                        Main.currentWorkerList.workerList[j].fri.Remove(myDayData.day);
                                    }
                                }
                                break;
                            case 5: //satur
                                for (int h=0; h<Main.currentWorkerList.workerList[j].satur.Count; h++)
                                {
                                    if(Main.currentWorkerList.workerList[j].satur[h] == myDayData.day)
                                    {
                                        Main.currentWorkerList.workerList[j].satur.Remove(myDayData.day);
                                    }
                                }
                                break;
                            case 6: //sun
                                for (int h=0; h<Main.currentWorkerList.workerList[j].sun.Count; h++)
                                {
                                    if(Main.currentWorkerList.workerList[j].sun[h] == myDayData.day)
                                    {
                                        Main.currentWorkerList.workerList[j].sun.Remove(myDayData.day);
                                    }
                                }
                                break;
                            case 7: //holi
                                for (int h=0; h<Main.currentWorkerList.workerList[j].holi.Count; h++)
                                {
                                    if(Main.currentWorkerList.workerList[j].holi[h] == myDayData.day)
                                    {
                                        Main.currentWorkerList.workerList[j].holi.Remove(myDayData.day);
                                    }
                                }
                                break;
                        }
                    }
                    else if(Main.currentWorkerList.workerList[j].name == ChoicedWorker._name) //고른 워커에서 일한 날짜 더해주고
                    {
                        switch(myDayData.dayWeek)
                        {
                            case 0: //mon
                                Main.currentWorkerList.workerList[j].mon.Add(myDayData.day);
                                break;
                            case 1: //tues
                                Main.currentWorkerList.workerList[j].tues.Add(myDayData.day);
                                break;
                            case 2: //wednes
                                Main.currentWorkerList.workerList[j].wednes.Add(myDayData.day);
                                break;
                            case 3: //thurs
                                Main.currentWorkerList.workerList[j].thurs.Add(myDayData.day);
                                break;
                            case 4: //fri
                                Main.currentWorkerList.workerList[j].fri.Add(myDayData.day);
                                break;
                            case 5: //satur
                                Main.currentWorkerList.workerList[j].satur.Add(myDayData.day);
                                break;
                            case 6: //sun
                                Main.currentWorkerList.workerList[j].sun.Add(myDayData.day);
                                break;
                            case 7: //holi
                                Main.currentWorkerList.workerList[j].holi.Add(myDayData.day);
                                break;
                        }

                    }
                }
                    Main.ChartUpdate.Invoke();
                    Main.UIClickAction.Invoke();
                    return;
                
            }
        }
       Debug.Log("뭔가 잘못됐다.");
    }
}
