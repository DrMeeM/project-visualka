using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIKontroller : MonoBehaviour
{   [SerializeField] GameObject Menu;
    private void OnEnable()
    {
        if (Bool.Blok == true)
        {
            Menu.SetActive(false);
            MapInistilation.Map.SetActive(false);
        }
    }
}
