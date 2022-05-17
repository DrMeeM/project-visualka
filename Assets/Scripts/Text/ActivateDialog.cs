using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialog : MonoBehaviour
{
    public int Num;
    public void ActiveDial()
    {
        GameObject Dial = GameObject.Find("UI_TXT");
        Dial.GetComponent<InstanceDialogue>().StartScene(Num);
    }
}
