using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTrueFalse : MonoBehaviour
{
    [SerializeField]
    private GameObject Panelka;

    public void ExitClose()
    { Panelka.SetActive(false);
       
    }

}
