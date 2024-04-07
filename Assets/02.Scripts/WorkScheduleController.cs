using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using sgSchedule;
using TMPro;
public class WorkScheduleController : MonoBehaviour
{
    public GameObject _calendarPanel;
    public Text _yearNumText;
    public Text _monthNumText;
    

    public GameObject _item;

    public List<GameObject> _dateItems = new List<GameObject>();
    const int _totalDateNum = 42;

    private DateTime _dateTime;
    public static WorkScheduleController _calendarInstance;

    void OnEnable()
    {
        _calendarInstance = this;
        Vector3 startPos = _item.transform.localPosition;
        _dateItems.Clear();
        _dateItems.Add(_item);

        for (int i = 1; i < _totalDateNum; i++)
        {
            GameObject item = GameObject.Instantiate(_item) as GameObject;
            item.name = "Item" + (i + 1).ToString();
            item.transform.SetParent(_item.transform.parent);
            item.transform.localScale = Vector3.one;
            item.transform.localRotation = Quaternion.identity;
            item.transform.localPosition = new Vector3((i % 7) * 36  + startPos.x, startPos.y - (i / 7) * 30, startPos.z);

            _dateItems.Add(item);
        }

        _dateTime = DateTime.Now;
        Debug.Log(DateTime.Now);

        CreateCalendar();
    }

    void CreateCalendar()
    {
        string thatMonth = _dateTime.ToString("yyyy-MM");
        List<string> month = new List<string>();
        List<DayData> days = new List<DayData>();
        for (int i=0; i<Main.currentSchedule.dayDataList.Count; i++)
        {
            DateTime monthDate = Convert.ToDateTime(Main.currentSchedule.dayDataList[i].day);
            string monthString = monthDate.ToString("yyyy-MM");
            if (!month.Contains(monthString))
            {
                month.Add(monthString);
            }
            if (thatMonth == monthString)
            {
                days.Add(Main.currentSchedule.dayDataList[i]);
            }
        }
        

        DateTime firstDay = _dateTime.AddDays(-(_dateTime.Day - 1));
        int index = GetDays(firstDay.DayOfWeek)-1;

        int date = 0;
        if(!month.Contains(thatMonth))//근무가 계획되지 않은 달인 경우
        {
            for (int i = 0; i < _totalDateNum; i++)
            {
                Text label = _dateItems[i].GetComponentInChildren<Text>();
                label.color = Color.white;
                TMP_Text workerText = _dateItems[i].GetComponentInChildren<TMP_Text>();
                _dateItems[i].SetActive(false);
                if (i >= index)
                {
                    DateTime thatDay = firstDay.AddDays(date);
                    if (thatDay.Month == firstDay.Month)
                    {
                        _dateItems[i].SetActive(true);
                        label.text = (date + 1).ToString();
                        workerText.text = "미정";
                        ScheduleHolidayItem item = label.transform.parent.GetComponent<ScheduleHolidayItem>();
                        item._myDate = thatDay;
                        date++;
                    }
                }
            }
            _yearNumText.text = _dateTime.Year.ToString();
            _monthNumText.text = _dateTime.Month.ToString("D2");
            return;
        }
        for (int i = 0; i < _totalDateNum; i++)
        {
            Text label = _dateItems[i].GetComponentInChildren<Text>();
            label.color = Color.white;
            TMP_Text workerText = _dateItems[i].GetComponentInChildren<TMP_Text>();
            _dateItems[i].SetActive(false);
            if (i >= index)
            {
                DateTime thatDay = firstDay.AddDays(date);
                if (thatDay.Month == firstDay.Month)
                {
                    _dateItems[i].SetActive(true);
                    label.text = (date + 1).ToString();
                    workerText.text = days[date].worker;
                    ScheduleHolidayItem item = label.transform.parent.GetComponent<ScheduleHolidayItem>();
                    item._myDate = thatDay;
                    date++;
                }
            }
        }
        _yearNumText.text = _dateTime.Year.ToString();
        _monthNumText.text = _dateTime.Month.ToString("D2");
    }

    int GetDays(DayOfWeek day)
    {
        switch (day)
        {
            case DayOfWeek.Monday: return 1;
            case DayOfWeek.Tuesday: return 2;
            case DayOfWeek.Wednesday: return 3;
            case DayOfWeek.Thursday: return 4;
            case DayOfWeek.Friday: return 5;
            case DayOfWeek.Saturday: return 6;
            case DayOfWeek.Sunday: return 0;
        }

        return 0;
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

    public void ShowCalendar(Text target)
    {
        _calendarPanel.SetActive(true);
        _target = target;
        //_calendarPanel.transform.position = new Vector3(965, 475, 0);//Input.mousePosition-new Vector3(0,120,0);
    }

    Text _target;

    //Item 클릭했을 경우 Text에 표시.
    public void OnDateItemClick(string day)
    {
        _target.text = _yearNumText.text + "-" + _monthNumText.text + "-" + int.Parse(day).ToString("D2");
        _calendarPanel.SetActive(false);
    }
}
