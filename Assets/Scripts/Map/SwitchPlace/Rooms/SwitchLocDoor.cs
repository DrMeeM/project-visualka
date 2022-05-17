using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwitchLocDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject PanelPodtverjdenie;
    [SerializeField] private GameObject ButtonCanMOveloc;
    [SerializeField] public bool NotAfterDoorConnect;
    [SerializeField] private bool CheckPoint;

    //| [SerializeField] public List<InventoryItem> inventory = new List<InventoryItem>();
    public List<GameObject> AllDoors = new List<GameObject>();
    [SerializeField] public int Door;
    private Vector3 coordDoor;
    private NavMeshAgent agent;

    private void OnTriggerEnter2D(Collider2D collision)
    {  if (!CheckPoint)
        {
            PanelPodtverjdenie = TablStatic.TablChangeLoc;
            if (NotAfterDoorConnect && Bool.Blok == false)
            {
                PanelPodtverjdenie.SetActive(true);
            }

          
                ButtonCanMOveloc = TablStatic.DoorSwitchButton;
                ButtonCanMOveloc.SetActive(true);

                Coord.DoorConnect = Door;
            
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {  
        ButtonCanMOveloc = TablStatic.DoorSwitchButton;
        ButtonCanMOveloc.SetActive(false);
        NotAfterDoorConnect = true;
    }

    public void DoorClick()
    {  
        PanelPodtverjdenie = TablStatic.TablChangeLoc;
        PanelPodtverjdenie.SetActive(true);
    }


   public void DoorConnect(int door)
    {
        agent = Coord.Player.GetComponent<NavMeshAgent>();
        agent.Warp(AllDoors[door].transform.position);
    }

    

  


}
