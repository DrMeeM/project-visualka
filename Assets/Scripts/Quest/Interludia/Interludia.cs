using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interludia : MonoBehaviour
{
    static int CountInt;
   public List  <GameObject> goList;
    [SerializeField] private GameObject Txt1;
    [SerializeField] private GameObject Txt2;


    [SerializeField] private GameObject But1;
    [SerializeField] private GameObject But2;
    [SerializeField] private GameObject LoadScreen;
    private void Update()
    {
        if (CountInt > 9)
        {
            Txt1.SetActive(false);
            Txt2.SetActive(true);
        }
    }
    private void Awake()
    {
        CountInt = 0;
        
    }

    public void CounterDialoge()
    {  if (CountInt > 11)
        {
            But2.SetActive(true) ;
            But1.SetActive(false) ;  
        }
        else
        {
            goList[CountInt].SetActive(true);
            CountInt++;
        }
        
    }
    public void Screen()
    {
        LoadScreen.SetActive(true);
    }
}
