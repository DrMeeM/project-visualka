using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coord : MonoBehaviour
{
    [Header("Текущая локация которая отображается на экране")]
    public static GameObject NowLoc; //Определяет комнату в которой находится персонаж
    public static int DoorConnect;   //С помощью этой переменной мы определяем к какой двери ведет другая дверь. 
    [SerializeField] public static GameObject Player;       //хз по рофлу
    [SerializeField] private GameObject PlayerInit;
    private void Awake()
    {
        Player = PlayerInit;
    }

}
