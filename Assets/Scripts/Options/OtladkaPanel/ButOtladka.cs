using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ButOtladka : MonoBehaviour
{
    [SerializeField]  private GameObject experimental;


  public  void SetActivnich()
    {
        experimental.SetActive(true);  
    }
    public void SetUnActivnich()
    {
        experimental.SetActive(false);
    }
    public void BlokOrNotBlock()
    {
        if (Bool.Blok == true)
        {
            Bool.Blok = false;
        }
        else Bool.Blok = true;
    }
}
