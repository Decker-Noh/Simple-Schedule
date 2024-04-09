using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerChangeBtn : MonoBehaviour {
    public WorkerChange workerChange;
    public void ClickWorkerBtn () {
        ScheduleHolidayItem item = gameObject.GetComponent<ScheduleHolidayItem> ();
        string workerName = item.textComponent.text;
        Debug.Log (workerName);
        workerChange.ClickWorker = workerName;
        workerChange.gameObject.SetActive (true);
        workerChange.gameObject.transform.position = transform.position;
    }
}