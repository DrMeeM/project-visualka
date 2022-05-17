using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleKostil : MonoBehaviour
{
    public Toggle toggle;
    private void Start()
    {
        toggle.GetComponent<Toggle>().isOn = Screen.fullScreen;
        
    }
}
