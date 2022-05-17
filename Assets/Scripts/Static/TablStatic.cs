using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablStatic : MonoBehaviour
{
    public static GameObject TablChangeLoc;

    public static GameObject PlayerLocationInWorld;


    public static GameObject QuestPanel;    

    public static bool PlayerCanMoveAnother; //блокирует перемещение игрока в зависимости от комнаты
    public static bool PanelDontBlockMove;   //блокирует перемещение игрока в зависимости от открытой закрытой какой-либо панели


    public static GameObject DoorSwitchButton; //переход на другую локацию через кнопку
}
