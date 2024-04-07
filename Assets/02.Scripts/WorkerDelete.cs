using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sgSchedule;
using TMPro;
public class WorkerDelete : MonoBehaviour
{
    public TMP_Text name;
    public void DeleteWorker()
    {
        for(int i=0; i<Main.currentWorkerList.workerList.Count; i++)
        {
            Main.currentWorkerList.workerList.RemoveAll(worker => worker.name == name.text);
        }
    }
}
