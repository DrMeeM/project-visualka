using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayScenesToLoad : MonoBehaviour
{
    public SceneMan[] SceneLo;
    public SceneMan[] SceneUn;




    public void LoadUnloadScenesToManager()
    {
        SceneLoad.SceneL= SceneLo;
        SceneLoad.SceneU = SceneUn;
    }
   
      
    
    public void Awake()
    {
        LoadUnloadScenesToManager();
    }
    
}

