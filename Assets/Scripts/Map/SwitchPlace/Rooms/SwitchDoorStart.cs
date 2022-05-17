using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoorStart : SwitchLocDoor
{
    
    void Start()
    {            

        NotAfterDoorConnect = false;
       
        DoorConnect(Coord.DoorConnect);
    }

   
}
