using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Cont : MonoBehaviour
{
    [SerializeField]
    private Button Contin;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Yes") == false)
        {
            Contin.enabled = false;
        }
    }
}
