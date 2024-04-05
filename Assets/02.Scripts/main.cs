using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace sgSchedule
{
    public class Main : MonoBehaviour
    {
#region alert
        public GameObject alertPannel;
        public TMP_Text alertText;
        public static Action<string> AlertAction;
        public void AlertFunc(string text)
        {
            alertText.text = text;
            alertPannel.SetActive(true);
            Invoke("AlertOff", 1.5f);
        }
        public void AlertOff()
        {
            alertPannel.SetActive(false);
        }
#endregion
        static string path;
        public static WorkerList currentWorkerList;
        // Start is called before the first frame update
        void Start()
        {

            path = Path.Combine(Application.dataPath, "database.json");
            

            DateTime date = new DateTime(2022,01, 02);

            // SaveDataFile();
            LoadDataFile();

            AlertAction += AlertFunc;
        }

        public void LoadDataFile()
        {
            WorkerList saveData = new WorkerList();
            try
            {
                string loadJson = File.ReadAllText(path);
                saveData = JsonUtility.FromJson<WorkerList>(loadJson);
            }
            catch(Exception ex)
            {
                Debug.Log("파일이 없습니다 : " + ex);
            }
            currentWorkerList = saveData;
        }
        public static void SaveDataFile()
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
}
