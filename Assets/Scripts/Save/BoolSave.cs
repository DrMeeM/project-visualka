using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolSave : MonoBehaviour
{
    public static bool Save;
    
    public void Begin()
    {
        Save = false;
    }

    public void Continue()
    {
        Save = true;
    }
}
