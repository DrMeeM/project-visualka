using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coord : MonoBehaviour
{
    [Header("������� ������� ������� ������������ �� ������")]
    public static GameObject NowLoc; //���������� ������� � ������� ��������� ��������
    public static int DoorConnect;   //� ������� ���� ���������� �� ���������� � ����� ����� ����� ������ �����. 
    [SerializeField] public static GameObject Player;       //�� �� �����
    [SerializeField] private GameObject PlayerInit;
    private void Awake()
    {
        Player = PlayerInit;
    }

}
