using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using sgSchedule;
public class WorkerManager : MonoBehaviour
{
    public TMP_InputField workerName;
    public TMP_InputField workerAnnual;
    public TMP_InputField mon;
    public TMP_InputField tues;
    public TMP_InputField wednes;
    public TMP_InputField thurs;
    public TMP_InputField fri;
    public TMP_InputField satur;
    public TMP_InputField sun;
    public TMP_InputField holi;
    public Toggle newcomer;
    public Button btn;
    private void Start()
    {
        Main.WorkerRegisterPannelAction += FormInit;
    }

    public void workerRegist()
    {
        if (workerName.text.Length == 0)
        {
            Main.AlertAction("이름을 입력하세요");
            return;
        }

        Worker worker = new Worker();
        worker._name = workerName.text;
        if (newcomer.isOn)
        {
            Debug.Log("신입");
            //전 근무자들의 평균을 구하는 로직이 들어가야함.
        }
        else
        {
            Debug.Log("신입아님");
            worker.SetWeekScore("mon", Int32.Parse(mon.text));
            worker.SetWeekScore("tues", Int32.Parse(tues.text));
            worker.SetWeekScore("wednes", Int32.Parse(wednes.text));
            worker.SetWeekScore("thurs", Int32.Parse(thurs.text));
            worker.SetWeekScore("fri", Int32.Parse(fri.text));
            worker.SetWeekScore("satur", Int32.Parse(satur.text));
            worker.SetWeekScore("sun", Int32.Parse(sun.text));
            worker.SetWeekScore("holi", Int32.Parse(holi.text));
            worker.SetWeekScore("annual", Int32.Parse(workerAnnual.text));
        }
        Main.currentWorkerList.workerList.Add(worker);
        Debug.Log("작성 연차 : " + workerAnnual.text);
        Debug.Log("변경 연차 : " + Int32.Parse(workerAnnual.text));
        Debug.Log("순수 연차 : " + worker.weekScore[8]);

        Debug.Log("등록 연차 : " + worker.GetWeekScore("annual"));
        Main.SaveDataFile();
        FormInit();
        DisableSubmitBtn();
        Main.AlertAction("근무자 등록 완료");
    }
    void FormInit()
    {
        workerName.text = null;
        mon.text = "0";
        tues.text = "0";
        wednes.text = "0";
        thurs.text = "0";
        fri.text = "0";
        satur.text = "0";
        sun.text = "0";
        holi.text = "0";
        workerAnnual.text = "0";
    }
    void DisableSubmitBtn()
    {
        btn.enabled = false;
        Invoke("EnableSubmitBtn", 1.5f);
    }
    void EnableSubmitBtn()
    {
        btn.enabled = true;
    }
}
