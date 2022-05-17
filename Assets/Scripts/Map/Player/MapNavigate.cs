using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
public class MapNavigate : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private GameObject StopPanel;
    [SerializeField] private GameObject Zone;
    [SerializeField] private LayerMask layerMask;
    private bool PlayerCanMoveAnothere;
  
    public GameObject NowPlayerLoc;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        

    }


    void Update()
    {
      
        if (Input.GetMouseButtonDown(0) )
        {
            
           PlayerCanMoveAnothere = TablStatic.PlayerCanMoveAnother;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit Infohit;
            if (Physics.Raycast(ray, out Infohit, Mathf.Infinity, layerMask))
            {
                if (Infohit.collider.gameObject.GetInstanceID() == Zone.GetInstanceID())
                {
                    if (PlayerCanMoveAnothere)
                    {
                        var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        target.z = 0;
                        Debug.Log("’хаха сдвинулс€ лол");
                        agent.destination = target;
                    }
                    else
                    {
                        StopPanel.SetActive(true);



                    }

                }
            }

           
               





           
            
            
             
           

        }





        
    }
    public void StopPanelExit()
    {
        StopPanel.SetActive(false);
        
    }
}