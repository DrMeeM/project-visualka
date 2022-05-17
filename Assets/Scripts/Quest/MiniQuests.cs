using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniQuests : MonoBehaviour
{
    public GameObject Papa;
    public Sprite[] OpClos;
    public Transform FaterOfQuest;
    public Transform FaterOfParam;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Short;
    public Toggle[] Toggles;
    public GameObject TextParam;


    private bool Act = false;
    private void Start()
    {
        FaterOfQuest.GetComponent<SpawnQuest>().LoadQuest();
        FaterOfQuest.GetComponent<SpawnQuest>().SpawnParam(TextParam, FaterOfParam, FaterOfQuest.GetComponent<SpawnQuest>().MaxParam());
    }
    public void Kartinka()
    {
        if (Act == false) 
        {
            Papa.transform.GetComponent<Image>().sprite = OpClos[1];
            Papa.transform.GetChild(0).gameObject.SetActive(true);
            
            
        }
        else
        {
            Papa.transform.GetComponent<Image>().sprite = OpClos[0];
            Papa.transform.GetChild(0).gameObject.SetActive(false);
        }
        Act = !Act;
    }

    public void SetText()
    {
        bool buf = false;
        for (int i = 0; i < FaterOfParam.childCount; i++)
        {
            FaterOfParam.GetChild(i).gameObject.SetActive(false);
            FaterOfParam.GetChild(i).GetComponent<TextMeshProUGUI>().color = Color.white;
        }
        if (Toggles[0].isOn == true) {
            for (int i = 0; i < FaterOfQuest.childCount; i++)
            {
                if (FaterOfQuest.GetChild(i).GetComponent<QuestScript>().Active == true & FaterOfQuest.GetChild(i).GetComponent<QuestScript>().BaseOrCringe == true)
                {
                    FaterOfQuest.GetComponent<SpawnQuest>().Proverka(FaterOfQuest.GetChild(i));
                    Name.gameObject.SetActive(true);
                    Name.text = FaterOfQuest.GetChild(i).GetComponent<QuestScript>().Name;
                    Short.text = FaterOfQuest.GetChild(i).GetComponent<QuestScript>().Short;
                    for (int j = 0; j < FaterOfQuest.GetChild(i).GetComponent<QuestScript>().AddTasks.Length; j++)
                    {
                        FaterOfParam.GetChild(j).gameObject.SetActive(true);
                        if (FaterOfQuest.GetChild(i).GetComponent<QuestScript>().Number[j] == 0)
                        {
                            FaterOfParam.GetChild(j).GetComponent<TextMeshProUGUI>().text = FaterOfQuest.GetChild(i).GetComponent<QuestScript>().AddTasks[j];
                            if (FaterOfQuest.GetChild(i).GetComponent<QuestScript>().Done[j] == true)
                            {
                                FaterOfParam.GetChild(j).GetComponent<TextMeshProUGUI>().color = Color.gray;
                            }
                        }
                        else
                        {
                            FaterOfParam.GetChild(j).GetComponent<TextMeshProUGUI>().text = FaterOfQuest.GetChild(i).GetComponent<QuestScript>().AddTasks[j] + ": " + FaterOfQuest.GetChild(i).GetComponent<QuestScript>().BaseNumber[j] + "/" + FaterOfQuest.GetChild(i).GetComponent<QuestScript>().Number[j];
                            if (FaterOfQuest.GetChild(i).GetComponent<QuestScript>().Done[j] == true)
                            {
                                FaterOfParam.GetChild(j).GetComponent<TextMeshProUGUI>().color = Color.gray;
                            }
                        }
                    }
                    buf = true;
                }
            }
            if (buf == false)
            {
                Name.gameObject.SetActive(false);
                Short.text = "Основной квест не выбран";
            }
        }
        else
        {
            for (int i = 0; i < FaterOfQuest.childCount; i++)
            {
                if (FaterOfQuest.GetChild(i).GetComponent<QuestScript>().Active == true & FaterOfQuest.GetChild(i).GetComponent<QuestScript>().BaseOrCringe == false)
                {
                    FaterOfQuest.GetComponent<SpawnQuest>().Proverka(FaterOfQuest.GetChild(i));
                    Name.gameObject.SetActive(true);
                    Name.text = FaterOfQuest.GetChild(i).GetComponent<QuestScript>().Name;
                    Short.text = FaterOfQuest.GetChild(i).GetComponent<QuestScript>().Short;
                    for (int j = 0; j < FaterOfQuest.GetChild(i).GetComponent<QuestScript>().AddTasks.Length; j++)
                    {
                        FaterOfParam.GetChild(j).gameObject.SetActive(true);
                        if (FaterOfQuest.GetChild(i).GetComponent<QuestScript>().Number[j] == 0)
                        {
                            FaterOfParam.GetChild(j).GetComponent<TextMeshProUGUI>().text = FaterOfQuest.GetChild(i).GetComponent<QuestScript>().AddTasks[j];
                            if (FaterOfQuest.GetChild(i).GetComponent<QuestScript>().Done[j] == true)
                            {
                                FaterOfParam.GetChild(j).GetComponent<TextMeshProUGUI>().color = Color.gray;
                            }
                        }
                        else
                        {
                            FaterOfParam.GetChild(j).GetComponent<TextMeshProUGUI>().text = FaterOfQuest.GetChild(i).GetComponent<QuestScript>().AddTasks[j] + ": " + FaterOfQuest.GetChild(i).GetComponent<QuestScript>().BaseNumber[j] + "/" + FaterOfQuest.GetChild(i).GetComponent<QuestScript>().Number[j];
                            if (FaterOfQuest.GetChild(i).GetComponent<QuestScript>().Done[j] == true)
                            {
                                FaterOfParam.GetChild(j).GetComponent<TextMeshProUGUI>().color = Color.gray;
                            }
                        }
                    }
                    buf = true;
                }
            }
            if (buf == false)
            {
                Name.gameObject.SetActive(false);
                Short.text = "Дополнительный квест не выбран";
            }
        }
    }



}
