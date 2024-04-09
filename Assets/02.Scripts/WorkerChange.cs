using System.Collections;
using System.Collections.Generic;
using sgSchedule;
using UnityEngine;
public class WorkerChange : MonoBehaviour {
    public string ClickWorker;

    void Start () {
        Main.UIClickAction += () => { gameObject.SetActive (false); };
    }

}