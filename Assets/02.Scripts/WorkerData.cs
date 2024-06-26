using UnityEngine;
using TMPro;
using sgSchedule;
public class WorkerData : MonoBehaviour
{
    string workerName;
    public int index;
    public TMP_Text tmpName;
    PannelManager pannelManager;
    void Awake() 
    {
        pannelManager = FindObjectOfType<PannelManager>();    
    }
    public string _name
    {
        get
        {
            return workerName;
        }
        set
        {
            workerName = value;
            tmpName.text = workerName;
        }
    }
    private void Start() {
        GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
    }

    public void ClickWorkerBtn()
    {
        pannelManager.PannelControl(4);
        Main.WorkerDetailPannelAction.Invoke(index);
    }
}
