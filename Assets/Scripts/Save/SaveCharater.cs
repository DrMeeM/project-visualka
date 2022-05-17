using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCharater : MonoBehaviour
{
    private Transform Char;
    private float X, Y, Z;

    private void Start()
    {
        Char = GetComponent<Transform>();
    }

    public void SaveChar()
    {
        X = Char.transform.position.x;
        Y = Char.transform.position.y;
        Z = Char.transform.position.z;
        PlayerPrefs.SetFloat("X", X);
        PlayerPrefs.SetFloat("Y", Y);
        PlayerPrefs.SetFloat("Z", Z);
        PlayerPrefs.Save();
    }
    
    public void LoadChar()
    {
        if (PlayerPrefs.HasKey("X"))
        {
            X = PlayerPrefs.GetFloat("X");
        }
        if (PlayerPrefs.HasKey("Y"))
        {
            Y = PlayerPrefs.GetFloat("Y");
        }
        if (PlayerPrefs.HasKey("Z"))
        {
            Z = PlayerPrefs.GetFloat("Z");
        }
        Char.transform.position = new Vector3(X, Y, Z);
    }
}
