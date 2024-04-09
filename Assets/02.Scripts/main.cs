using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

namespace sgSchedule {
    public class Main : MonoBehaviour {
        #region alert
        public GameObject alertPannel;
        public TMP_Text alertText;
        public static Action<string> AlertAction;
        public void AlertFunc (string text) {
            alertText.text = text;
            alertPannel.SetActive (true);
            Invoke ("AlertOff", 1.5f);
        }
        public void AlertOff () {
            alertPannel.SetActive (false);
        }
        #endregion
        public static Action WorkerRegisterPannelAction;
        public static Action WorkerListPannelAction;
        public static Action<int> WorkerDetailPannelAction;
        static string path;
        static string pathScehdule;
        public static WorkerList currentWorkerList;
        public static Action UIClickAction;
        public static Schedule currentSchedule;
        // Start is called before the first frame update
        void Start () {

            path = Path.Combine (Application.dataPath, "database.json");
            pathScehdule = Path.Combine (Application.dataPath, "scheduleDatabase.json");

            DateTime date = new DateTime (2022, 01, 02);

            // SaveDataFile();
            LoadDataFile ();

            AlertAction += AlertFunc;
            TimeEnd ();
            // InitWorkerData();
        }
        public void TimeEnd () {
            DateTime end = new DateTime (2027, 1, 5);
            int result = end.CompareTo (DateTime.Now);
            if (result < 1) {
                Debug.Log ("종료");
                Application.Quit ();
            }
        }
        public void LoadDataFile () {
            WorkerList saveData = new WorkerList ();
            Schedule saveSchedule = new Schedule ();
            try {
                string loadJson = File.ReadAllText (path);
                saveData = JsonUtility.FromJson<WorkerList> (loadJson);
                string loadJson2 = File.ReadAllText (pathScehdule);
                Debug.Log (loadJson2);
                saveSchedule = JsonUtility.FromJson<Schedule> (loadJson2);
            } catch (Exception ex) {
                Debug.Log ("파일이 없습니다 : " + ex);
            }
            currentWorkerList = saveData;
            currentSchedule = saveSchedule;
        }
        public static void SaveDataFile () {
            Debug.Log ("저장됩니다");
            string json = JsonUtility.ToJson (currentWorkerList, true);

            File.WriteAllText (path, json);

            json = JsonUtility.ToJson (currentSchedule, true);
            Debug.Log (json);
            File.WriteAllText (pathScehdule, json);
        }
        public void InitWorkerData () {
            WorkerList saveData = new WorkerList ();
            string json = JsonUtility.ToJson (saveData, true);
            File.WriteAllText (path, json);

        }
        public static Worker WorkerLastScoreCalculate (Worker worker) {
            int total;
            for (int i = 0; i < 8; i++) {
                total = 0;
                switch (i) {
                    case 0: //mon
                        total = worker.weekScore[i];
                        total += worker.mon.Count;
                        break;
                    case 1: //tues
                        total = worker.weekScore[i];
                        total += worker.tues.Count;
                        break;
                    case 2: //wednes
                        total = worker.weekScore[i];
                        total += worker.wednes.Count;
                        break;
                    case 3: //thurs
                        total = worker.weekScore[i];
                        total += worker.thurs.Count;
                        break;
                    case 4: //fri
                        total = worker.weekScore[i];
                        total += worker.fri.Count;
                        break;
                    case 5: //satur
                        total = worker.weekScore[i];
                        total += worker.satur.Count;
                        break;
                    case 6: //sun
                        total = worker.weekScore[i];
                        total += worker.sun.Count;
                        break;
                    case 7: //holi
                        total = worker.weekScore[i];
                        total += worker.holi.Count;
                        break;
                }
                worker.weekLastScore[i] = total;
            }
            return worker;
        }

        public static void WorkerListLastScoreCal () {
            for (int i = 0; i < currentWorkerList.workerList.Count; i++) {
                currentWorkerList.workerList[i] = WorkerLastScoreCalculate (currentWorkerList.workerList[i]);
            }
        }
        private void OnApplicationQuit () {
            SaveDataFile ();
        }
    }

}