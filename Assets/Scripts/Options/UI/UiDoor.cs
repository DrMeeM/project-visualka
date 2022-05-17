using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiDoor : MonoBehaviour
{  [SerializeField] private GameObject _door;
    [SerializeField] private GameObject _blockDoorPanel;
    private void OnEnable()
    {
        if (_door.activeSelf)
        {
            _blockDoorPanel.SetActive(true);
        }
        else
        {
            _blockDoorPanel.SetActive(false);   
        }
    }

}
