using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    [Header("������ ��� ����������� ���� � ����������")]
    public bool Active;
    public bool BaseOrCringe;
    public bool ActiveNow;
    public bool Addlisten;
    public bool AllDone;
    public int NumberOfTask;

    [Header("��� ������ xml �����")]
    public string Name;
    public string Short;
    public string Long;

    [Header("��� ������� �������")]
    public string[] AddTasks;
    public int[] Number;
    public int[] BaseNumber;
    public bool[] Done;


}
