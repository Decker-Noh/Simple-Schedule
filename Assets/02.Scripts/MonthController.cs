using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using sgSchedule;
using System.Linq;
public class MonthController : MonoBehaviour
{
    public ScheduleList scheduleList;
    public Text _yearNumText;
    public Text _monthNumText;

    private DateTime _dateTime;


    void OnEnable()
    {
       
        _dateTime = DateTime.Now;
        CreateCalendar();
    }

    public void CreateSchedule()
    {
        if(Main.currentWorkerList.workerList.Count <= 3)
        {
            Main.AlertAction("근무자가 부족합니다");
            return;
        }
        int dayInMonth = DateTime.DaysInMonth(_dateTime.Year, _dateTime.Month);//월 일수 파악
        List<DayData> dayDataList = new List<DayData>();
        for (int i=1; i<dayInMonth+1; i++) //일수만큼 일데이터 만든 후 날짜, 요일 데이터 삽입
        {
            DateTime thatTime = new DateTime(_dateTime.Year, _dateTime.Month, i);
            DayData dayData = new DayData();

            dayData.day = thatTime.ToString("yyyy-MM-dd");
            dayData.dayWeek = GetDays(thatTime.DayOfWeek);
      
            if (Main.currentSchedule.holidayTotal.Contains(dayData.day))
            {
                dayData.dayWeek = 7;
            }
            dayDataList.Add(dayData);
            for(int m=0; m<Main.currentSchedule.dayDataList.Count; m++)
            {
                if(Main.currentSchedule.dayDataList[m].day == dayData.day)
                {
                    Main.AlertAction("이미 생성된 근무가 있는 달입니다.");
                    return;
                }
            }
        }
        Main.WorkerListLastScoreCal(); //워커 최정근무 다시 계산

        string prev1worker = "fake";
        string prev2worker = "fake";
        DateTime first = new DateTime(_dateTime.Year, _dateTime.Month, 1);
        string prev1Day = first.AddDays(-1).ToString("yyyy-MM-dd");
        string prev2Day = first.AddDays(-2).ToString("yyyy-MM-dd");



        for(int i=0; i<Main.currentSchedule.dayDataList.Count; i++) // 저번달 마지막 2일 찾아서 일한사람 저장.
        {
            if(Main.currentSchedule.dayDataList[i].day == prev1Day)
            {

                prev1worker = Main.currentSchedule.dayDataList[i].worker;
            }
            if(Main.currentSchedule.dayDataList[i].day == prev2Day)
            {
                prev1worker = Main.currentSchedule.dayDataList[i].worker;
            }
        }

        for (int i=0; i<dayDataList.Count; i++)
        {
            //우선 순위
            List<Worker> PriorityWorker = Main.currentWorkerList.workerList;
            PriorityWorker = PriorityWorker.OrderBy
            (
                worker => 
                worker.weekLastScore.Sum()
            ).ToList();
            //깊은 복사
            List<Worker> possibleWorker = Main.currentWorkerList.workerList.Select(worker => new Worker {
                name = worker.name,
                weekScore = new List<int>(worker.weekScore),
                mon = new List<string>(worker.mon),
                tues = new List<string>(worker.tues),
                wednes = new List<string>(worker.wednes),
                thurs = new List<string>(worker.thurs),
                fri = new List<string>(worker.fri),
                satur = new List<string>(worker.satur),
                sun = new List<string>(worker.sun),
                holi = new List<string>(worker.holi),
                monResult = worker.monResult,
                tuesResult = worker.tuesResult,
                wednesResult = worker.wednesResult,
                thursResult = worker.thursResult,
                friResult = worker.friResult,
                saturResult = worker.saturResult,
                sunResult = worker.sunResult,
                holiResult = worker.holiResult,
                vacationData = new List<string>(worker.vacationData),
                weekLastScore = new List<int>(worker.weekLastScore)
            }).ToList();
            List<Worker> tempWorker = possibleWorker.Select(worker => new Worker {
                name = worker.name,
                weekScore = new List<int>(worker.weekScore),
                mon = new List<string>(worker.mon),
                tues = new List<string>(worker.tues),
                wednes = new List<string>(worker.wednes),
                thurs = new List<string>(worker.thurs),
                fri = new List<string>(worker.fri),
                satur = new List<string>(worker.satur),
                sun = new List<string>(worker.sun),
                holi = new List<string>(worker.holi),
                monResult = worker.monResult,
                tuesResult = worker.tuesResult,
                wednesResult = worker.wednesResult,
                thursResult = worker.thursResult,
                friResult = worker.friResult,
                saturResult = worker.saturResult,
                sunResult = worker.sunResult,
                holiResult = worker.holiResult,
                vacationData = new List<string>(worker.vacationData),
                weekLastScore = new List<int>(worker.weekLastScore)
            }).ToList();
            
            for(int k=0; k<possibleWorker.Count; k++) //이전 근무자 제거
            {
                tempWorker.RemoveAll(worker => worker.name == prev1worker);
                tempWorker.RemoveAll(worker => worker.name == prev2worker);
            }
            possibleWorker = tempWorker;

            possibleWorker = possibleWorker.OrderBy(worker => worker.weekLastScore[dayDataList[i].dayWeek]).ToList(); // 요일 기준으로 정렬.
            int weekMin =   possibleWorker.Select(worker => worker.weekLastScore[dayDataList[i].dayWeek]).Min();
            List<Worker> minWorkerList = possibleWorker.Where(worker => worker.weekLastScore[dayDataList[i].dayWeek]==weekMin).ToList();
            minWorkerList = minWorkerList.OrderBy
            (
                worker => 
                worker.weekLastScore.Sum()
            ).ToList();
            if (minWorkerList.Count == 0)
            {
                Main.AlertAction("근무자가 부족합니다");
                return;
            }

            prev2worker = prev1worker;
            prev1worker = minWorkerList[0].name; //최소를 일꾼으로 선정
            dayDataList[i].worker = prev1worker; //오늘의 일꾼 선정
            
            for (int w=0; w<Main.currentWorkerList.workerList.Count; w++)//선정된 일꾼 데이터에 일자, 점수 추가
            {
                if(Main.currentWorkerList.workerList[w].name == dayDataList[i].worker)
                {
                    switch(dayDataList[i].dayWeek)
                    {
                        case 0:
                            Main.currentWorkerList.workerList[w].mon.Add(dayDataList[i].day);
                            Main.currentWorkerList.workerList[w].weekLastScore[0] +=1;
                            break;
                        case 1:
                            Main.currentWorkerList.workerList[w].tues.Add(dayDataList[i].day);
                            Main.currentWorkerList.workerList[w].weekLastScore[1] +=1;
                            break;
                        case 2:
                            Main.currentWorkerList.workerList[w].wednes.Add(dayDataList[i].day);
                            Main.currentWorkerList.workerList[w].weekLastScore[2] +=1;
                            break;
                        case 3:
                            Main.currentWorkerList.workerList[w].thurs.Add(dayDataList[i].day);
                            Main.currentWorkerList.workerList[w].weekLastScore[3] +=1;
                            break;
                        case 4:
                            Main.currentWorkerList.workerList[w].fri.Add(dayDataList[i].day);
                            Main.currentWorkerList.workerList[w].weekLastScore[4] +=1;
                            break;
                        case 5:
                            Main.currentWorkerList.workerList[w].satur.Add(dayDataList[i].day);
                            Main.currentWorkerList.workerList[w].weekLastScore[5] +=1;
                            break;
                        case 6:
                            Main.currentWorkerList.workerList[w].sun.Add(dayDataList[i].day);
                            Main.currentWorkerList.workerList[w].weekLastScore[6] +=1;
                            break;
                        case 7:
                            Main.currentWorkerList.workerList[w].holi.Add(dayDataList[i].day);
                            Main.currentWorkerList.workerList[w].weekLastScore[7] +=1;
                            break;
                    }
                    break;
                }
            }
        }

        
        Main.currentSchedule.dayDataList.AddRange(dayDataList);
        string schedule22 = JsonUtility.ToJson(Main.currentSchedule);
        Debug.Log("근무표 나왔어요 : " + schedule22);
        Main.SaveDataFile();
        scheduleList.InitWorkerList();
    }

    void CreateCalendar()
    {
        _yearNumText.text = _dateTime.Year.ToString();
        _monthNumText.text = _dateTime.Month.ToString("D2");
    }

    public void YearPrev()
    {
        _dateTime = _dateTime.AddYears(-1);
        CreateCalendar();
    }

    public void YearNext()
    {
        _dateTime = _dateTime.AddYears(1);
        CreateCalendar();
    }

    public void MonthPrev()
    {
        _dateTime = _dateTime.AddMonths(-1);
        CreateCalendar();
    }

    public void MonthNext()
    {
        _dateTime = _dateTime.AddMonths(1);
        CreateCalendar();
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
