using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleList : MonoBehaviour
{
    public GameObject Schedule;
    public GameObject Contents;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void InitWorkerList()
    {
        foreach (Transform child in Contents.transform)
        {
            Destroy(child.gameObject);
        }
        
        // List<Worker> workerList = Main.currentWorkerList.workerList;

        // for(int i=0; i<workerList.Count; i++)
        // {
        //     GameObject game = GameObject.Instantiate(WorkerBtn, Vector3.zero, Quaternion.identity);
        //     WorkerData data = game.GetComponent<WorkerData>();
        //     data._name = workerList[i].name;
        //     data.index = i;

        //     game.transform.parent = Contents.transform;
        // }
    }
}
