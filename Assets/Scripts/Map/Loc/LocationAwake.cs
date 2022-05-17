using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationAwake : MonoBehaviour
{
  
    void Awake()
    {  if (StaticUI.LoadScreen == null)
        {
           
        }
    else
        {
            StaticUI.LoadScreen.SetActive(false);
        }
    }

  
}
