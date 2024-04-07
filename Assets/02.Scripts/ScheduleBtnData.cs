using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScheduleBtnData : MonoBehaviour
{
    string name;
    public TMP_Text tmp_text;
    public string _name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
            tmp_text.text = name;
        }
    }
    private void Start()
    {
        GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
    }
}
