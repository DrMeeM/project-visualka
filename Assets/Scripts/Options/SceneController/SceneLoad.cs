
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{    
    [SerializeField]
    static public SceneMan[] SceneL;
    [SerializeField]
    static  public SceneMan[] SceneU;
    private Scene thisScene;

    private bool IfTheeseSceneLoad; //если такая сцена уже загружена
    public void LoadScene(Button St)
    {
        St.enabled = false;
        thisScene = SceneManager.GetActiveScene();
       
        
        foreach (var scene in SceneL)
        {
           
            SceneManager.LoadSceneAsync(scene.SceneName, LoadSceneMode.Additive);
            
        
            

        }
        StartCoroutine(TestCoroutine());
       

    }


    System.Collections.IEnumerator TestCoroutine()
    { 
        while (thisScene.name == SceneManager.GetActiveScene().name)
        {
          
            
                yield return new WaitForSeconds(0.5f);
                SceneManager.UnloadSceneAsync(thisScene);
             
           
        }
    }

        public void UnloadScene()
    {
        thisScene = SceneManager.GetActiveScene();
       
    }

    public void UnloadScenes()
    {
        foreach (var scene in SceneU)
        {

            SceneManager.UnloadSceneAsync(scene.SceneName);




        }
    }


    public void LoadNotMainScene()
    {
        StaticUI.LoadScreen.SetActive(true);
        foreach (var scene in SceneL)
        {
            Scene scene1;
            string sceneName = scene.name;
            scene1 = SceneManager.GetSceneByName(sceneName);

            if (scene1.name == scene.name)
            {
                Debug.Log("не дал задублировать сцену");
                return;

            }
            else { SceneManager.LoadSceneAsync(scene.SceneName, LoadSceneMode.Additive); }
            


        }
    }
     public void SetFalse()
    {
        TablStatic.TablChangeLoc.SetActive(false);
        TablStatic.DoorSwitchButton.SetActive(false);
    }


    public void ProverkaScene(Scene scene)
    {


        if (scene.isLoaded)
       
            IfTheeseSceneLoad = true;
       
        else IfTheeseSceneLoad = false;

            
    }



}