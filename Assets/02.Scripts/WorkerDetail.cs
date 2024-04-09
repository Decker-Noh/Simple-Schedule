using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using sgSchedule;
public class WorkerDetail : MonoBehaviour
{
    public TMP_Text _name;
    public TMP_Text _annual;
    public TMP_Text mon;
    public TMP_Text tues;
    public TMP_Text wednes;
    public TMP_Text thurs;
    public TMP_Text fri;
    public TMP_Text satur;
    public TMP_Text sun;
    public TMP_Text holi;
    // Start is called before the first frame update
    void Start()
    {
        Main.WorkerDetailPannelAction += WorkerDataUpdate;
    }

    void WorkerDataUpdate(int index)
    {
        Worker target = Main.currentWorkerList.workerList[index];
        _name.text = target._name;
        _annual.text = target.GetWeekScore("annual").ToString();
        mon.text = (target.GetWeekScore("mon") + target.mon.Count).ToString();
        tues.text = (target.GetWeekScore("tues") + target.tues.Count).ToString();
        wednes.text = (target.GetWeekScore("wednes") + target.wednes.Count).ToString();
        thurs.text = (target.GetWeekScore("thurs") + target.thurs.Count).ToString();
        fri.text = (target.GetWeekScore("fri") + target.fri.Count).ToString();
        satur.text = (target.GetWeekScore("satur") + target.satur.Count).ToString();
        sun.text = (target.GetWeekScore("sun") + target.sun.Count).ToString();
        holi.text = (target.GetWeekScore("holi") + target.holi.Count).ToString();;
    }
}
