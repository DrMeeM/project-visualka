using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryStart : MonoBehaviour
{
    public GameObject Dio;
    private void Start()
    {
        Dio = GameObject.Find("UI_TXT");
        
        Dio.GetComponent<InstanceDialogue>().StartScene(0);
    }
}
