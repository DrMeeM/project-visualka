using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBlokCheck : MonoBehaviour
{   [SerializeField]
    private GameObject Black;
    void Update()
    {
        if (Bool.Blok == true)
        {
            Black.SetActive(true); 
        }
        else Black.SetActive(false);
    }
}
