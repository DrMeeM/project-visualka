using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Windows : MonoBehaviour
{
    public Toggle toggle;
    private void Start()
    {
        toggle.GetComponent<Toggle>().isOn = Screen.fullScreen;
    }
    public void FullScreen(bool is_foolscreen)
    {
        Screen.fullScreen = is_foolscreen;
        
    }
}
