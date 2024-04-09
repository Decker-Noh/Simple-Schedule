using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WorkerChangeBtn : MonoBehaviour {
    public WorkerChange workerChange;
    public void ClickWorkerBtn () {
        ScheduleHolidayItem item = gameObject.GetComponent<ScheduleHolidayItem> ();
        string workerName = gameObject.GetComponentInChildren<TMP_Text>().text;
        workerChange.ClickWorker = workerName;
        workerChange.thatDate = item.myDate;
        workerChange.gameObject.SetActive (true);
        workerChange.gameObject.transform.position = transform.position;

        Debug.Log($"현재 {workerChange.thatDate.ToString("yyyy-MM-dd")}의 근무자는 {workerChange.ClickWorker}입니다");
    }
}