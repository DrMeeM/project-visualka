using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    [Header("Булевы для определения типа и активности")]
    public bool Active;
    public bool BaseOrCringe;
    public bool ActiveNow;
    public bool Addlisten;
    public bool AllDone;
    public int NumberOfTask;

    [Header("Для текста xml файла")]
    public string Name;
    public string Short;
    public string Long;

    [Header("Для пунктов задания")]
    public string[] AddTasks;
    public int[] Number;
    public int[] BaseNumber;
    public bool[] Done;


}
