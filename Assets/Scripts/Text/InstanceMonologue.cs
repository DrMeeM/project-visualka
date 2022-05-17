using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InstanceMonologue : MonoBehaviour
{
    public static InstanceMonologue instance = null;

    public TextAsset[] assets;
    private int currentAsset;
    private int currentNode;

    private TestMonologue TestMonologue;

    private bool firstStart = true;

    public TextMeshProUGUI IntroText;
    public Button NextButton;
    public Button NextButton2;
    public Button BackButton;

    public GameObject[] objectsforsetfalse;

    public GameObject TEST;
    //public TextMeshPro AAAAAAAAA;
    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        currentAsset = 0;
        currentNode = -1;
    }

    public void LoadAsset()
    {
        currentNode = -1;
        TestMonologue = null;
        TestMonologue = TestMonologue.Load(assets[currentAsset]);
    }

    public void startScene()
    {
        
        if (firstStart)
        {
            NextButton.onClick.AddListener(nextIntroNode);
            NextButton2.onClick.AddListener(nextIntroNode);
            BackButton.onClick.AddListener(backIntroNode);
            firstStart = false;
            
        }
        LoadAsset();
        //showImportScene();
        nextIntroNode();
    }

    public void nextIntroNode()
    {
        if (currentNode == TestMonologue.nodes.Length - 1)
        {
            NextButton.onClick.RemoveListener(nextIntroNode);
            NextButton2.onClick.RemoveListener(nextIntroNode);
            BackButton.onClick.RemoveListener(backIntroNode);
            for (int i = 0; i < objectsforsetfalse.Length; i++)
            {
                objectsforsetfalse[i].SetActive(false);
            }
            //InstanceDialogue.instance.StartScene();
            //TEST.GetComponent<InstanceDialogue>().StartScene();
            return;
        }
        //IntroText.text = "";
        currentNode++;
        IntroText.text = TestMonologue.nodes[currentNode].Npctext;
        //StartCoroutine(PrintMachineEffect.abc.printMachineEffect(IntroText, TestMonologue.nodes[currentNode].Npctext, NextButton));
    }

    public void backIntroNode() 
    {
        if (currentNode > 0)
        {
            currentNode--;
            IntroText.text = TestMonologue.nodes[currentNode].Npctext;
            
        }
    }
}
