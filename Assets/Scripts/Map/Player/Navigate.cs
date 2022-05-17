using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigate : MonoBehaviour
{
    private NavMeshAgent agent;
    public bool showPath;
    public bool showAhead;
    public GameObject Blok;
    [SerializeField] private GameObject Zone;
    [SerializeField] private LayerMask layerMask;
   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

  
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
           // if (Bool.Blok) return;
           
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit Infohit;
                
                if (Physics.Raycast(ray, out Infohit, Mathf.Infinity, layerMask))
                {
                    if (Infohit.collider.gameObject.GetInstanceID() == Zone.GetInstanceID())
                    {
                       
                        var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        target.z = 0;
                   // Debug.Log("Двинул");
                         agent.destination = target;
                    }
                }
                
           
        }
    }

   
    public void TisheAgent()
    {
        agent.ResetPath();
    }



    public static void DebugDrawPath(Vector3[] corners)
    {
        if (corners.Length < 2) { return; }
        int i = 0;
        for (; i < corners.Length - 1; i++)
        {
            Debug.DrawLine(corners[i], corners[i + 1], Color.blue);
        }
        Debug.DrawLine(corners[0], corners[1], Color.red);
    }

    private void OnDrawGizmos()
    {
        DrawGizmos(agent, showPath, showAhead);
    }

    public static void DrawGizmos(NavMeshAgent agent, bool showPath, bool showAhead)
    {
        if (Application.isPlaying)
        {
            if (showPath && agent.hasPath)
            {
                var corners = agent.path.corners;
                if (corners.Length < 2) { return; }
                int i = 0;
                for (; i < corners.Length - 1; i++)
                {
                    Debug.DrawLine(corners[i], corners[i + 1], Color.blue);
                    Gizmos.color = Color.blue;
                    Gizmos.DrawSphere(agent.path.corners[i + 1], 0.03f);
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(agent.path.corners[i], agent.path.corners[i + 1]);
                }
                Debug.DrawLine(corners[0], corners[1], Color.blue);
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(agent.path.corners[1], 0.03f);
                Gizmos.color = Color.red;
                Gizmos.DrawLine(agent.path.corners[0], agent.path.corners[1]);
            }

            if (showAhead)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawRay(agent.transform.position, agent.transform.up * 0.5f);
            }
        }
    }
}
