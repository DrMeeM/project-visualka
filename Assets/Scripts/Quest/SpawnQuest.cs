using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnQuest : MonoBehaviour
{
    [Header("Для спауна объектов")]
    public Transform Father;
    public GameObject DadParam;
    public GameObject Questobj;
    public TextMeshProUGUI NamePanel;
    public TextMeshProUGUI ShortPanel;
    public TextMeshProUGUI LongPanel;
    public GameObject DadOfTextPanel;
    public Button Chose;
    public TextMeshProUGUI ChoseText;
    public Transform Elsee;
    public GameObject TextParams;

    private ReedQuest reedQuest;
    private int currentQuest;
    private bool HaveAvtive;
    private int chet;
    private int max;
    private bool spawn;
    private int Kolvo = 0;
    //private bool generation = false;

    public TextAsset[] textAsset;

    public void Start()
    {
        currentQuest = 0;
        HaveAvtive = false;
        spawn = false;
        Chose.onClick.AddListener(SortBut);
        Chose.onClick.AddListener(EnFal);
        LoadQuest();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spavnobj(currentQuest);
            currentQuest++;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            TestInt(6, 0);
        }
    }

    public void SaveAll()
    {
        for (int i = 0; i < Father.childCount; i++)
        {
            PlayerPrefs.SetInt("QuestSpawn:" + i, Father.GetChild(i).GetComponent<QuestScript>().NumberOfTask);
            for (int j = 0; j < Father.GetChild(i).GetComponent<QuestScript>().BaseNumber.Length; j++)
            {
                PlayerPrefs.SetInt("QuestSpawn:" + i + j, Father.GetChild(i).GetComponent<QuestScript>().BaseNumber[j]);
            }
        }
        PlayerPrefs.SetInt("Kolvo", Father.childCount);
        PlayerPrefs.SetInt("Yes", 1);
        PlayerPrefs.Save();
    }

    public void SpawnSavesoQuest()
    {
        Kolvo = PlayerPrefs.GetInt("Kolvo");
        for(int i = 0; i < Kolvo; i++)
        {
            Spavnobj(PlayerPrefs.GetInt("QuestSpawn:" + i));
            //for(int )
        }
    }

    public void DeleteAllQuestSave()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("Kolvo"); i++)
        {
            PlayerPrefs.DeleteKey("QuestSpawn:" + i);
        }
        PlayerPrefs.DeleteKey("Kolvo");
        PlayerPrefs.DeleteAll();
    }

    public void Spavnobj(int cur)
    {
       
        Questobj.GetComponent<QuestScript>().Active = false;
        if (reedQuest.quests[cur].typequest == 0)
        {
            Base(cur);
            SetText();
        }
        else
        {
            Cringe(cur);
        }
        HaveAvtive = false;
        Sort();
    }

    public void SetText()
    {
        DadParam.SetActive(true);
        for (int i = 0; i < Elsee.childCount; i++)
        {
            Elsee.GetChild(i).gameObject.SetActive(false);
            Elsee.GetChild(i).GetComponent<TextMeshProUGUI>().color = Color.white;
        }
        for (int i = 0; i < Father.childCount; i++)
        {
            Father.GetChild(i).GetComponent<QuestScript>().ActiveNow = false;
        }
        for (int i = 0; i < Father.childCount; i++)
        {
            if (Father.GetChild(i).GetComponent<WhoClick>().Iclick == true)
            {
                DadOfTextPanel.SetActive(true);
                if (Father.GetChild(i).GetComponent<QuestScript>().Active == true)
                {
                    ChoseText.text = "Выбрано";
                    ChoseText.color = Color.gray;
                    Chose.enabled = false;
                }
                else
                {
                    ChoseText.text = "Выбрать";
                    ChoseText.color = Color.white;
                    Chose.enabled = true;
                }
                NamePanel.text = Father.GetChild(i).GetComponent<QuestScript>().Name;
                ShortPanel.text = Father.GetChild(i).GetComponent<QuestScript>().Short;
                LongPanel.text = Father.GetChild(i).GetComponent<QuestScript>().Long + "\r\n";
                Proverka(Father.GetChild(i));
                if (spawn == false)
                {
                    SpawnParam(TextParams, Elsee, MaxParam());
                    spawn = true;
                }
                for (int j = 0; j < Father.GetChild(i).GetComponent<QuestScript>().AddTasks.Length; j++)
                {
                    Elsee.GetChild(j).gameObject.SetActive(true);
                    if (Father.GetChild(i).GetComponent<QuestScript>().Number[j] == 0)
                    {
                        Elsee.GetChild(j).GetComponent<TextMeshProUGUI>().text = Father.GetChild(i).GetComponent<QuestScript>().AddTasks[j];
                        if (Father.GetChild(i).GetComponent<QuestScript>().Done[j] == true)
                        {
                            Elsee.GetChild(j).GetComponent<TextMeshProUGUI>().color = Color.gray;
                        }
                    }
                    else
                    {
                        Elsee.GetChild(j).GetComponent<TextMeshProUGUI>().text = Father.GetChild(i).GetComponent<QuestScript>().AddTasks[j] + ": " + Father.GetChild(i).GetComponent<QuestScript>().BaseNumber[j] + "/" + Father.GetChild(i).GetComponent<QuestScript>().Number[j];
                        if (Father.GetChild(i).GetComponent<QuestScript>().Done[j] == true)
                        {
                            Elsee.GetChild(j).GetComponent<TextMeshProUGUI>().color = Color.gray;
                        }
                    }
                }
                
                Father.GetChild(i).GetComponent<QuestScript>().ActiveNow = true;
                Father.GetChild(i).GetComponent<WhoClick>().Iclick = false;
            }
        }
    }
    
    public void DoubleClick()
    {
        for (int i = 0; i < Father.childCount; i++)
        {
            if (Father.GetChild(i).GetComponent<QuestScript>().ActiveNow == true)
            {
                DadParam.SetActive(false);
                Father.GetChild(i).GetComponent<QuestScript>().ActiveNow = false;
            }
        }
    }
    public void SpawnParam(GameObject Param, Transform Par, int Max)
    {
        for (int j = 0; j < Max; j++)
        {
            Instantiate(Param, Param.transform.position, Param.transform.rotation, Par);
            Par.GetChild(j).gameObject.SetActive(false);
        }
    }
    public void SortBut()
    {
        for (int i = 0; i < Father.childCount; i++)
        {
            if (Father.GetChild(i).GetComponent<QuestScript>().ActiveNow == true)
            {
                if (Father.GetChild(i).GetComponent<QuestScript>().BaseOrCringe == true)
                {
                    Father.GetChild(0).GetComponent<QuestScript>().Active = false;
                    Father.GetChild(i).GetComponent<QuestScript>().Active = true;
                    Father.GetChild(i).gameObject.transform.SetSiblingIndex(0);
                }
                else
                {
                    Father.GetChild(chet).GetComponent<QuestScript>().Active = false;
                    Father.GetChild(i).GetComponent<QuestScript>().Active = true;
                    Father.GetChild(i).gameObject.transform.SetSiblingIndex(chet);
                }
            }
        }
        for (int i = 0; i < Father.childCount; i++)
        {
            if (Father.GetChild(i).GetComponent<QuestScript>().Active == true)
            {
                Father.GetChild(i).GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                Father.GetChild(i).GetChild(1).gameObject.SetActive(false);
            }
        }
    }
    public void Sort()
    {
        chet = 0;
        for (int i = 0; i < Father.childCount; i++)
        {
            ProverkaAll(Father.GetChild(i));
            Father.GetChild(i).GetChild(1).gameObject.SetActive(false);
            if (Father.GetChild(i).GetComponent<QuestScript>().Addlisten == false)
            {
                Father.GetChild(i).GetComponent<Button>().onClick.AddListener(SetText);
                Father.GetChild(i).GetComponent<QuestScript>().Addlisten = true;
            }
            
            if (Father.GetChild(i).GetComponent<QuestScript>().AllDone == true)
            {
                Father.GetChild(i).gameObject.transform.SetSiblingIndex(Father.childCount - 1);
                Father.GetChild(i).GetComponent<TextMeshProUGUI>().color = Color.gray;
            }
            
            if (Father.GetChild(i).GetComponent<QuestScript>().BaseOrCringe == true)
            {
                Father.GetChild(i).gameObject.transform.SetSiblingIndex(0);
                chet++;
            }
           
        }
        for (int i = 0; i < Father.childCount; i++)
        {
            if (Father.GetChild(i).GetComponent<QuestScript>().Active == true && Father.GetChild(i).GetComponent<QuestScript>().BaseOrCringe == true)
            {
                Father.GetChild(i).gameObject.transform.SetSiblingIndex(0);
            }
            else if(Father.GetChild(i).GetComponent<QuestScript>().Active == true && Father.GetChild(i).GetComponent<QuestScript>().BaseOrCringe == false)
            {
                Father.GetChild(i).gameObject.transform.SetSiblingIndex(chet);
            }
        }
        for (int i = 0; i < Father.childCount; i++)
        {
            
            if (Father.GetChild(i).GetComponent<QuestScript>().Active == true)
            {
                Father.GetChild(i).GetChild(1).gameObject.SetActive(true);
            }
        }
    }

    public void Base(int cur)
    {
        //generation = true;
        Questobj.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = reedQuest.quests[cur].NameText;
        Questobj.GetComponent<QuestScript>().BaseOrCringe = true;
        Questobj.GetComponent<QuestScript>().Name = reedQuest.quests[cur].NameText;
        Questobj.GetComponent<QuestScript>().Short = reedQuest.quests[cur].ShortText;
        Questobj.GetComponent<QuestScript>().Long = reedQuest.quests[cur].LongText;
        Questobj.GetComponent<QuestScript>().NumberOfTask = reedQuest.quests[cur].numberofkvest;
        Questobj.GetComponent<QuestScript>().AddTasks = new string[reedQuest.quests[cur].Parameters.Length];
        Questobj.GetComponent<QuestScript>().Number = new int[reedQuest.quests[cur].Parameters.Length];
        Questobj.GetComponent<QuestScript>().BaseNumber = new int[reedQuest.quests[cur].Parameters.Length];
        Questobj.GetComponent<QuestScript>().Done = new bool[reedQuest.quests[cur].Parameters.Length];
        for (int i = 0; i < reedQuest.quests[cur].Parameters.Length; i++)
        {
            Questobj.GetComponent<QuestScript>().AddTasks[i] = reedQuest.quests[cur].Parameters[i].text;
            Questobj.GetComponent<QuestScript>().Number[i] = reedQuest.quests[cur].Parameters[i].kolvo;
            if (PlayerPrefs.HasKey("Yes"))
            {
                Questobj.GetComponent<QuestScript>().BaseNumber[i] = PlayerPrefs.GetInt("QuestSpawn:" + cur + i);
            }
            else
            {
                Questobj.GetComponent<QuestScript>().BaseNumber[i] = 0;
            }
            Questobj.GetComponent<QuestScript>().Done[i] = false;
        }
        Questobj.transform.GetChild(2).GetComponent<TextMeshProUGUI>().color = Color.yellow;
        for (int i = 0; i < Father.childCount; i++)
        {
            if (Father.GetChild(i).GetComponent<QuestScript>().Active == true && Father.GetChild(i).GetComponent<QuestScript>().BaseOrCringe == true)
            {
                HaveAvtive = true;
            }
        }
        if (HaveAvtive == false)
        {
            Questobj.GetComponent<QuestScript>().Active = true;
        }
        Instantiate(Questobj, Questobj.transform.position, Questobj.transform.rotation, Father);
    }
    public void Cringe(int cur)
    {
        //generation = true;
        Questobj.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = reedQuest.quests[cur].NameText;
        Questobj.GetComponent<QuestScript>().BaseOrCringe = false;
        Questobj.GetComponent<QuestScript>().Name = reedQuest.quests[cur].NameText;
        Questobj.GetComponent<QuestScript>().Short = reedQuest.quests[cur].ShortText;
        Questobj.GetComponent<QuestScript>().Long = reedQuest.quests[cur].LongText;
        Questobj.GetComponent<QuestScript>().NumberOfTask = reedQuest.quests[cur].numberofkvest;
        Questobj.GetComponent<QuestScript>().AddTasks = new string[reedQuest.quests[cur].Parameters.Length];
        Questobj.GetComponent<QuestScript>().Number = new int[reedQuest.quests[cur].Parameters.Length];
        Questobj.GetComponent<QuestScript>().BaseNumber = new int[reedQuest.quests[cur].Parameters.Length];
        Questobj.GetComponent<QuestScript>().Done = new bool[reedQuest.quests[cur].Parameters.Length];
        for (int i = 0; i < reedQuest.quests[cur].Parameters.Length; i++)
        {
            Questobj.GetComponent<QuestScript>().AddTasks[i] = reedQuest.quests[cur].Parameters[i].text;
            Questobj.GetComponent<QuestScript>().Number[i] = reedQuest.quests[cur].Parameters[i].kolvo;
            if (PlayerPrefs.HasKey("Yes"))
            {
                Questobj.GetComponent<QuestScript>().BaseNumber[i] = PlayerPrefs.GetInt("QuestSpawn:" + cur + i);
            }
            else
            {
                Questobj.GetComponent<QuestScript>().BaseNumber[i] = 0;
            }
            Questobj.GetComponent<QuestScript>().Done[i] = false;
        }
        Questobj.transform.GetChild(2).GetComponent<TextMeshProUGUI>().color = Color.white;
        for (int i = 0; i < Father.childCount; i++)
        {
            if (Father.GetChild(i).GetComponent<QuestScript>().Active == true && Father.GetChild(i).GetComponent<QuestScript>().BaseOrCringe == false)
            {
                HaveAvtive = true;
            }
        }
        if (HaveAvtive == false)
        {
            Questobj.GetComponent<QuestScript>().Active = true;
        }
        Instantiate(Questobj, Questobj.transform.position, Questobj.transform.rotation, Father);
    }

    public int MaxParam()
    {
        int buf;
        for (int i = 0; i < reedQuest.quests.Length; i ++)
        {
            buf = reedQuest.quests[i].Parameters.Length;
            if (buf > max)
            {
                max = buf;
            }
        }
        return max;
    }

    public void Proverka(Transform chozen)
    {
        for (int i = 0; i < chozen.GetComponent<QuestScript>().AddTasks.Length; i++)
        {
            if (chozen.GetComponent<QuestScript>().Number[i] > 0)
            {
                if (chozen.GetComponent<QuestScript>().Number[i] <= chozen.GetComponent<QuestScript>().BaseNumber[i])
                {
                    chozen.GetComponent<QuestScript>().Done[i] = true;
                }
            }
            else
            {
                if (chozen.GetComponent<QuestScript>().BaseNumber[i] >= 1)
                {
                    chozen.GetComponent<QuestScript>().Done[i] = true;
                }
            }
        }
        ProverkaAll(chozen);
    }

    public void ProverkaAll(Transform chozen)
    {
        bool buf = false;
        for (int i = 0; i < chozen.GetComponent<QuestScript>().Done.Length; i++)
        {
            if (chozen.GetComponent<QuestScript>().Done[i] == false)
            {
                buf = true;
            }
        }
        if (buf == false)
        {
            chozen.GetComponent<QuestScript>().AllDone = true;
            Destroy(chozen.gameObject);
        }
    }

    public void TestInt(int NumQuest, int QuestPoint)
    { 
        for (int i = 0; i < Father.childCount; i++)
        {
            if (Father.GetChild(i).GetComponent<QuestScript>().NumberOfTask == NumQuest)
            {
                Father.GetChild(i).GetComponent<QuestScript>().BaseNumber[QuestPoint] += 1;
                Proverka(Father.GetChild(i));
            }
        }
    }
    public void TestBool()
    {
        for (int i = 0; i < Father.GetChild(0).GetComponent<QuestScript>().Done.Length; i++)
        {
            Father.GetChild(0).GetComponent<QuestScript>().Done[i] = true;
        }
    }


    public void EnFal()
    {
        ChoseText.text = "Выбрано";
        ChoseText.color = Color.gray;
        Chose.enabled = false;
    }

    public void LoadQuest()
    {
        reedQuest = null;
        reedQuest = ReedQuest.Load(textAsset[0]);
    }
}
