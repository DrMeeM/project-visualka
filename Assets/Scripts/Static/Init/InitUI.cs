using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitUI : MonoBehaviour
{
    public GameObject tablChangeLoc;
    public GameObject ButtonDoor;
    public GameObject QuestPanel;
    [SerializeField] public GameObject LoadScreenAwake;

    void Awake()
    {
        TablStatic.TablChangeLoc = tablChangeLoc;
        TablStatic.DoorSwitchButton = ButtonDoor;
        TablStatic.QuestPanel= QuestPanel;  
        StaticUI.LoadScreen = LoadScreenAwake;

    }
}
