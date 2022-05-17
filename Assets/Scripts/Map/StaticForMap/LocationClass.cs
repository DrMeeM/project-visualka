using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationClass : MonoBehaviour
{
    [SerializeField]
    private bool PlayerCanMoveLoc;
    void Start()
    {
        TablStatic.PlayerCanMoveAnother = PlayerCanMoveLoc;



    }
}