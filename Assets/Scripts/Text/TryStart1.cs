using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryStart1 : MonoBehaviour
{
    public GameObject Dio;
    private void Start()
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        Dio = GameObject.Find("UI_TXT");
       
        Dio.GetComponent<InstanceDialogue>().StartScene(1);
    }
}
