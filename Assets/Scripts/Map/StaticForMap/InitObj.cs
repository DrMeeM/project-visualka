using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class InitObj : MonoBehaviour
{
   public GameObject MapIn;
   public NavMeshAgent Agent;
    public GameObject InfoPanelAboutLoc;
    void Awake()
    {
        MapInistilation.Map = MapIn;
        MapInistilation.PlayerLocAgent = Agent;  
        MapInistilation.InfoPanelAboutLocation = InfoPanelAboutLoc;
    }

 
}
