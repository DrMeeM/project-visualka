using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public GameObject OptPanel;
    public GameObject[] Kostil;
    public GameObject Dio;
    public Toggle toggle;
    private bool act = false;
    private void Start()
    {
        //OptPanel = GameObject.Find("UI_tablichka");
        //Dio.GetComponent<InstanceDialogue>().StartScene();
        //InstanceMonologue.instance.startScene();
    }
    void Update()
    {
        EscOpt(act);
    }
    public void EscOpt(bool active)
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            /*
            if (OptPanel.activeInHierarchy == false)
            {
                OptPanel.SetActive(true);
                for (int i = 0; i < Kostil.Length; i++)
                {
                    Kostil[i].SetActive(false);
                }
                toggle.GetComponent<Toggle>().isOn = Screen.fullScreen;
            }
            else
            {
                OptPanel.SetActive(false);
                for (int i = 0; i < Kostil.Length; i++)
                {
                    Kostil[i].SetActive(true);
                }
            }
            */
            OptPanel.SetActive(!active);
            toggle.GetComponent<Toggle>().isOn = Screen.fullScreen;
        }
    }
    public void ExitOnTable()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
    }
    public void Close()
    {
        OptPanel.SetActive(false);
        for (int i = 0; i < Kostil.Length; i++)
        {
            Kostil[i].SetActive(true);
        }
    }
}
