using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchroom : MonoBehaviour
{
    public GameObject Room;
   
 
    private void OnTriggerStay2D(Collider2D collision)
    {    if (Coord.NowLoc == null)
        {
            Coord.NowLoc = Room;
            Coord.NowLoc.SetActive(true);
            Room.GetComponent<ActivateDialog>().ActiveDial();
        }
        if (Coord.NowLoc.GetInstanceID() != Room.GetInstanceID())
        {
            
            Coord.NowLoc.SetActive(false);
            Coord.NowLoc = Room;
            Coord.NowLoc.SetActive(true);
            Room.GetComponent<ActivateDialog>().ActiveDial();
        }


    }
}
