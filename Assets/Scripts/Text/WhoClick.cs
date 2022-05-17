using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoClick : MonoBehaviour
{
    private GameObject QP;
    public bool Iclick = false;
    
    public void Maybe()
    {
        Iclick = true;
    }
    public void CheckOpenQuestPanel()
    {
        QP = TablStatic.QuestPanel;
        if (QP.activeSelf == true)
        {
            Debug.Log("A");
            QP.SetActive(false);
        }
        else QP.SetActive(true);

       
    }
}
