using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstanceDialogue : MonoBehaviour
{
    public static InstanceDialogue instance = null;

    public TextAsset[] assets;
    private int currentAsset;
    public int[] Proverka;
    public GameObject Quest;
    private Dialogue dialogue;
    public GameObject[] Char;
    private int currentNode;
    private bool firstStart = true;
    public bool dialogueEnded = false;
    public TextMeshProUGUI IntroText;
    public GameObject IntrotextObj;
    public Button NextButton;
    public Button NextButton2;
    public Button BackButton;
    public GameObject NewQuestPanel;

    public Button[] AnswerButAll;
    public TextMeshProUGUI[] AnswerText;
    public GameObject[] AnswerAll;
    public GameObject[] AllButton;

    public GameObject[] AnsObj;

    [Header("Toggle")]
    public GameObject FatherToggle;
    public GameObject[] TogglesAsObj;
    public Toggle[] Toggles;

    private double chast;
    private int kolvo;
    private int ostatok;
    private bool moreorless;
    private int Butoon;
    //private string[] repeat;
    //private int chetchik;
    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (PlayerPrefs.HasKey("chet") == false)
        {
            Proverka = new int[assets.Length];
            for (int i = 0; i < Proverka.Length; i++)
            {
                Proverka[i] = 0;
            }
        }
        else
        {
            AssignProgDial();
        }
    }
    
    public void LoadAsset()
    {
        dialogue = null;
        dialogue = Dialogue.Load(assets[currentAsset]);
    }

    public void StartScene(int chose)
    {
        Quest.transform.GetComponent<SpawnQuest>().LoadQuest();
        currentNode = 0;
        currentAsset = chose;
        //chetchik = 0;
        LoadAsset();
        NextIntro();
        //Char.SetActive(true);
    }
    public void NextIntro()
    {
        if (Proverka[currentAsset] == 1)
        {
            End(currentAsset);
        }
        
        DialEndProverka(currentAsset);
        if (dialogueEnded == true)
        {
            dialogueEnded = false;
            firstStart = true;
            return;
        }
        Bool.Blok = true;
        MapInistilation.PlayerLocAgent.ResetPath();
        Disactive();
        if (firstStart)
        {
            for (int i = 0; i < AnswerButAll.Length; i++)
            {
                AnswerButAll[i].onClick.AddListener(Who);
                AnswerButAll[i].onClick.AddListener(NextIntro);
            }
            NextButton.onClick.AddListener(NextIntro);
            NextButton2.onClick.AddListener(NextIntro);
            IntrotextObj.SetActive(true);
            //BackButton.onClick.AddListener(backIntroNode);
            firstStart = false;
            for(int i = 0; i < TogglesAsObj.Length; i++)
            {
                Toggles[i].onValueChanged.AddListener(TogClick);
            }
        }
        for (int i = 0; i < AnswerText.Length; i++)
        {
            AnswerText[i].color = Color.white;
        }
        if (dialogue.nodes[currentNode].answers == null)
        {
            NoAnswer();
        }
        else
        {
            YesAnswer();
        }
    }
    


    public void NoAnswer()
    {
        AllButton[4].SetActive(true);
        //AllButton[5].SetActive(true);
        NextButton2.enabled = true;
        IntroText.text = dialogue.nodes[currentNode].Npctext;
        Char[dialogue.nodes[currentNode].Charnow].SetActive(true);
        if (dialogue.nodes[currentNode].ActQuest != 1000)
        {
            Quest.transform.GetComponent<SpawnQuest>().Spavnobj(dialogue.nodes[currentNode].ActQuest);
            StartCoroutine(FiveSeckPanelQuest());
        }
        if (dialogue.nodes[currentNode].NumQuest != 1000)
        {
            Quest.transform.GetComponent<SpawnQuest>().TestInt(dialogue.nodes[currentNode].NumQuest, dialogue.nodes[currentNode].PosOfQuest);
        }
        currentNode++;
    }


    public void YesAnswer()
    {
        if (dialogue.nodes[currentNode].answers.Length <= 4)
        {
            LessThanFour();
            moreorless = false;
        }
        else
        {
            MoreThanFour();
            moreorless = true;
        }
         
    }

    public void Who()
    {

        int buffer = 0;
        bool toj = false;
        if (moreorless == true)
        {
            for (int j = 0; j < TogglesAsObj.Length; j++)
            {
                if (TogglesAsObj[j].activeInHierarchy == true)
                {
                    if (Toggles[j].GetComponent<Toggle>().isOn == true)
                    {
                        if (toj == false)
                        {
                            buffer = 4 * j;
                            toj = true;
                        }
                        for (int i = 0; i < AnswerButAll.Length; i++)
                        {
                            if (AnswerButAll[i].isActiveAndEnabled == true)
                            {
                                if (AnswerButAll[i].GetComponent<WhoClick>().Iclick == true)
                                {
                                    currentNode = dialogue.nodes[currentNode].answers[buffer].nextNode;
                                    AnswerButAll[i].GetComponent<WhoClick>().Iclick = false;
                                    /*
                                    if (dialogue.nodes[currentNode].answers[buffer].ActQuest != 1000)
                                    {
                                        Quest.transform.GetComponent<SpawnQuest>().Spavnobj(dialogue.nodes[currentNode].answers[buffer].ActQuest);
                                        StartCoroutine(FiveSeckPanelQuest());
                                    }
                                    if (dialogue.nodes[currentNode].answers[buffer].NumQuest != 1000)
                                    {
                                        Quest.transform.GetComponent<SpawnQuest>().TestInt(dialogue.nodes[currentNode].answers[buffer].NumQuest, dialogue.nodes[currentNode].answers[buffer].PosOfQuest);
                                    }
                                    */
                                }
                                buffer++;
                            }
                        }
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < AnswerButAll.Length; i++)
            {
                if (AnswerButAll[i].isActiveAndEnabled == true)
                {
                    if (AnswerButAll[i].GetComponent<WhoClick>().Iclick == true)
                    {
                        currentNode = dialogue.nodes[currentNode].answers[buffer].nextNode;
                        AnswerButAll[i].GetComponent<WhoClick>().Iclick = false;
                        /*
                        if (dialogue.nodes[currentNode].answers[buffer].ActQuestA != 1000)
                        {
                            Quest.transform.GetComponent<SpawnQuest>().Spavnobj(dialogue.nodes[currentNode].answers[buffer].ActQuestA);
                            StartCoroutine(FiveSeckPanelQuest());
                        }
                        if (dialogue.nodes[currentNode].answers[buffer].NumQuestA != 1000)
                        {
                            Quest.transform.GetComponent<SpawnQuest>().TestInt(dialogue.nodes[currentNode].answers[buffer].NumQuestA, dialogue.nodes[currentNode].answers[buffer].PosOfQuestA);
                        }
                        */
                    }
                    buffer++;
                }
            }
        }
        if (currentNode == 1000)
        {
            dialogueEnded = true;
        }
    }
    public void DialEndProverka(int cur)
    {
        if (dialogueEnded == true | currentNode == dialogue.nodes.Length)
        {
            End(cur);
        }
    }
    
    public void End(int cur)
    {
        for (int i = 0; i < AllButton.Length; i++)
        {
            AnswerButAll[i].onClick.RemoveAllListeners();
            NextButton.onClick.RemoveAllListeners();
            NextButton2.onClick.RemoveAllListeners();
            AllButton[i].SetActive(false);
        }
        IntrotextObj.SetActive(false);
        dialogueEnded = true;
        for (int i = 0; i < Char.Length; i++)
        {
            Char[i].SetActive(false);
        }
        for (int i = 0; i < TogglesAsObj.Length; i++)
        {
            Toggles[i].onValueChanged.RemoveAllListeners();
            TogglesAsObj[i].SetActive(false);
        }
        FatherToggle.SetActive(false);
        if (dialogue.more == 0)
        {
            Proverka[cur] = 1;
        }
        Bool.Blok = false;
    }

    public void Disactive()
    {
        for (int i = 0; i < AllButton.Length; i++)
        {
            AllButton[i].SetActive(false);
        }
        for (int i = 0; i < Char.Length; i++)
        {
            Char[i].SetActive(false);
        }
        NextButton2.enabled = false;
        for (int i = 0; i < TogglesAsObj.Length; i++)
        {
            TogglesAsObj[i].SetActive(false);
        }
        FatherToggle.SetActive(false);
    }

    public void MoreThanFour()
    {
        int But = 0;
        IntroText.text = dialogue.nodes[currentNode].Npctext;
        Char[dialogue.nodes[currentNode].Charnow].SetActive(true);
        chast = dialogue.nodes[currentNode].answers.Length / 4.0;
        kolvo = dialogue.nodes[currentNode].answers.Length / 4;
        ostatok = dialogue.nodes[currentNode].answers.Length - 4 * kolvo;
        if (chast > 1 && chast <= 2)
        {
            FatherToggle.SetActive(true);
            TogglesAsObj[0].SetActive(true);
            TogglesAsObj[1].SetActive(true);
            AnsObj[3].SetActive(true);
            Toggles[0].isOn = true;
            for (int i = 0; i < AnswerButAll.Length; i++)
            {
                if (AnswerButAll[i].isActiveAndEnabled == true)
                {
                    AnswerText[i].text = dialogue.nodes[currentNode].answers[But].text;
                    But++;
                }
            }
        }
        else if (chast > 2 && chast <= 3)
        {
            FatherToggle.SetActive(true);
            TogglesAsObj[0].SetActive(true);
            TogglesAsObj[1].SetActive(true);
            TogglesAsObj[2].SetActive(true);
            AnsObj[3].SetActive(true);
            Toggles[0].isOn = true;
            for (int i = 0; i < AnswerButAll.Length; i++)
            {
                if (AnswerButAll[i].isActiveAndEnabled == true)
                {
                    AnswerText[i].text = dialogue.nodes[currentNode].answers[But].text;
                    But++;
                }
            }
        }
    }
    
    public void LessThanFour()
    {
        AnsObj[dialogue.nodes[currentNode].answers.Length - 1].SetActive(true);
        IntroText.text = dialogue.nodes[currentNode].Npctext;
        Char[dialogue.nodes[currentNode].Charnow].SetActive(true);
        int But = 0;
        for (int i = 0; i < AnswerButAll.Length; i++)
        {
            if (AnswerButAll[i].isActiveAndEnabled == true)
            {
                AnswerText[i].text = dialogue.nodes[currentNode].answers[But].text;
                But++;
            }
        }
    }
    public void TogClick(bool active)
    {
        for (int i = 0; i < AnsObj.Length; i++)
        {
            AnsObj[i].SetActive(false);
        }
        Butoon = 0;
        for (int i = 0; i < TogglesAsObj.Length; i++)
        {
            if (TogglesAsObj[i].activeInHierarchy == true) {
                if (Toggles[i].GetComponent<Toggle>().isOn == true)
                {
                    if (dialogue.nodes[currentNode].answers.Length - 4 * (i + 1) >= 0)
                    {
                        AnsObj[3].SetActive(true);
                        Butoon = 4 * i;
                        for (int j = 0; j < AnswerButAll.Length; j++)
                        {
                            if (AnswerButAll[j].isActiveAndEnabled == true)
                            {
                                AnswerText[j].text = dialogue.nodes[currentNode].answers[Butoon].text;
                                Butoon++;
                            }
                        }
                    }
                    else
                    {
                        AnsObj[ostatok - 1].SetActive(true);
                        Butoon = 4*i;
                        for (int j = 0; j < AnswerButAll.Length; j++)
                        {
                            if (AnswerButAll[j].isActiveAndEnabled == true)
                            {
                                AnswerText[j].text = dialogue.nodes[currentNode].answers[Butoon].text;
                                Butoon++;
                            }
                        }
                    }
                }
            }
        }
    }
    public void SaveProgDial()
    {
        for (int i = 0; i < Proverka.Length; i++)
        {
            PlayerPrefs.SetInt("ProverkaQuest" + i, Proverka[i]);
            Debug.Log(PlayerPrefs.GetInt("ProverkaQuest" + i));
        }
        PlayerPrefs.SetInt("chet", Proverka.Length);
        Debug.Log(PlayerPrefs.GetInt("chet"));
        PlayerPrefs.Save();
    }

    public void AssignProgDial()
    {
        Proverka = new int[assets.Length];
        for (int i = 0; i < PlayerPrefs.GetInt("chet"); i++)
        {
            Proverka[i]=PlayerPrefs.GetInt("ProverkaQuest" + i);
        }
    }

    IEnumerator FiveSeckPanelQuest()
    {
        NewQuestPanel.SetActive(true);
        yield return new WaitForSeconds(1.7f);
        NewQuestPanel.SetActive(false);
    }
}
