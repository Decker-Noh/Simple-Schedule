using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using sgSchedule;
using TMPro;
public class main : MonoBehaviour
{
    string path;
    static WorkerList currentWorkerList;
    // Start is called before the first frame update
    void Start()
    {
        path = Path.Combine(Application.dataPath, "database.json");
        

        DateTime date = new DateTime(2022,01, 02);

        SaveDataFile();
        LoadDataFile();
    }

    public void LoadDataFile()
    {
        WorkerList saveData = new WorkerList();
        string loadJson = File.ReadAllText(path);
        saveData = JsonUtility.FromJson<WorkerList>(loadJson);
        if(saveData == null)
            return;
        currentWorkerList = saveData;
    }
    public void SaveDataFile()
    {
        // WorkerList saveData = new WorkerList();

        // Worker newWorker = new Worker();
        // newWorker._name = "순건";
        // newWorker.SetWeekScore("mon", 3);
        // DateTime date = new DateTime(2021,2,2);
        // string sDate = date.ToString("yyyy-MM-dd");
        // newWorker.vacationData.Add(sDate);
        // date = Convert.ToDateTime(sDate);
        
        // saveData.workerList.Add(newWorker);
        
        string json = JsonUtility.ToJson(currentWorkerList, true);

        File.WriteAllText(path, json);
    }
}
