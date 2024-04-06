using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sgSchedule;
public class PannelManager : MonoBehaviour
{
    public GameObject[] pannelList;



    public void PannelControl(int num)
    {
        for (int i=0; i<pannelList.Length; i++)
        {
            pannelList[i].SetActive(false);
        }
        pannelList[num].SetActive(true);
        switch(num)
        {
            case 0://main

                break;
            case 2://WorkerRegister
                Main.WorkerRegisterPannelAction.Invoke();
                break;
            case 3://WorkerRegister
                Main.WorkerListPannelAction.Invoke();
                break;

        }
    }
}
