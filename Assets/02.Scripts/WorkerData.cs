using UnityEngine;
using TMPro;
public class WorkerData : MonoBehaviour
{
    string workerName;
    public int index;
    public TMP_Text tmpName;
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
}
