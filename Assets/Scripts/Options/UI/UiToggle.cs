using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiToggle : MonoBehaviour
{
  
    [SerializeField]
    private GameObject Papashka;
    [SerializeField]
    private GameObject NeedPanel;
    public void AllDeactivate()
    {   
                foreach (Transform child in Papashka.GetComponentInChildren<Transform>())
        {
            child.gameObject.SetActive(false);
        }
        MapInistilation.Map.SetActive(false);
        
    }
    public void BeforeDeactive()
    {
        foreach (Transform child in NeedPanel.GetComponentInChildren<Transform>())
        {
            child.gameObject.SetActive(false);
        }

       
    }

    public void SetAcTr()
    {
       
        Papashka.SetActive(true);
        NeedPanel.SetActive(true);

        foreach (Transform child in NeedPanel.GetComponentInChildren<Transform>())
        {
            child.gameObject.SetActive(true);
        }
    }

    public void MapActivate()
    {
        Bool.Blok = true;
        Papashka.SetActive(true);
        NeedPanel.SetActive(true);

        foreach (Transform child in NeedPanel.GetComponentInChildren<Transform>())
        {
            child.gameObject.SetActive(true);
        }
        MapInistilation.Map.SetActive(true);
    }



   




}
