using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InUI : MonoBehaviour
{ 
    private GameObject LoadScreenAwake;
  
    void Awake()
    {
        StaticUI.LoadScreen = LoadScreenAwake;
    }

    
}
