using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMap : MonoBehaviour
   {
    public SceneMan[] SceneLo;
    public SceneMan[] SceneUn;
    public SceneLoad SL;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
       MapInistilation.InfoPanelAboutLocation.SetActive(true);
        LoadUnloadScenesToManager();
    }
    public void ClassicSetActiveFalse()
    {
        MapInistilation.InfoPanelAboutLocation.SetActive(false);    
    }
    public void LoadUnloadScenesToManager()
    {
        SceneLoad.SceneL = SceneLo;
        SceneLoad.SceneU = SceneUn;
    }
    private void OnTriggerExit(Collider other)
    {
        LoadUnloadScenesToManager();
        SL.UnloadScenes();
    }
}
