using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSave : MonoBehaviour
{
    public GameObject Quest;
    public GameObject Dialog;
    public GameObject Perss;
    private void Awake()
    {
        Quest.transform.GetComponent<SpawnQuest>().LoadQuest();
        Perss = GameObject.Find("PlayerLoc");
        Debug.Log(Perss);
        if (BoolSave.Save == true)
        {
            Quest.transform.GetComponent<SpawnQuest>().LoadQuest();
            Quest.transform.GetComponent<SpawnQuest>().SpawnSavesoQuest();
        }
    }
    private void Start()
    {
        Perss = GameObject.Find("PlayerLoc");
        if (BoolSave.Save == true)
        {
            Debug.Log(Perss);
            PersSave();
            SpawnPers();
        }
    }

    public void PersSave()
    {
        Perss.GetComponent<SaveCharater>().SaveChar();
    }
    
    public void SpawnPers()
    {
        Perss.GetComponent<SaveCharater>().LoadChar();
    }
}
