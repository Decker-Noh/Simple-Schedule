using System.Collections;
using System.Collections.Generic;
using sgSchedule;
using UnityEngine;
using TMPro;
using System;
public class WorkerChange : MonoBehaviour {
    public string ClickWorker;
    public DateTime thatDate;
    public GameObject changeBtn;
    public GameObject changeWorkerList;
    public GameObject ListContents;
    public GameObject worekrBtn;

    void OnEnable()
    {
        changeBtn.SetActive(true);
        changeWorkerList.SetActive(false);
    }
    void Start ()
    {
        Main.UIClickAction += () => { gameObject.SetActive (false); };
    }
    public void ChangeWorkerListOpen()
    {
        changeWorkerList.SetActive(true);
        foreach (Transform child in ListContents.transform) //리스트 초기화
        {
            Destroy(child.gameObject);
        }

        for (int i=0; i<Main.currentWorkerList.workerList.Count; i++)
        {
            if (Main.currentWorkerList.workerList[i].name == ClickWorker)
            {
                continue;
            }
            GameObject worker = GameObject.Instantiate(worekrBtn, Vector3.zero, Quaternion.identity);
            TMP_Text workerName = worker.GetComponentInChildren<TMP_Text>();
            WorkerChangeItem itemData = worker.GetComponent<WorkerChangeItem>();
            itemData.ClickWorker = ClickWorker;
            itemData.thatDate = thatDate;
            itemData.ChoicedWorker = Main.currentWorkerList.workerList[i];
            workerName.text =itemData.ChoicedWorker.name;
            worker.transform.SetParent(ListContents.transform);
        }
    }

}