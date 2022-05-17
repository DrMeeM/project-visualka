using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BackgroundVolumeController : MonoBehaviour
{
    [SerializeField] private string volumeTag;
    private void Awake()
    {
        
        GameObject[] aud = GameObject.FindGameObjectsWithTag(this.volumeTag);
        if (aud.Length == 1)
        {
            DontDestroyOnLoad(this.gameObject);
            this.gameObject.name ="aliluia";
        }
        if (aud.Length == 2)
        {
            GameObject abv = GameObject.Find("Audio Source");
            abv.SetActive(false);
        }
        
    }
}
