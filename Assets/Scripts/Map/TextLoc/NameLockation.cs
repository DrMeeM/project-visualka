using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameLockation : MonoBehaviour
{
    private ReedNameLoc ReadName;
    public TextAsset TextLoc;
    public GameObject LocPanel;

    [Header("Ёлементы дл€ изменени€")]
    public Sprite[] LocImage;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Disrc;
    public SpriteRenderer Sprite;

    public void LoadAsset()
    {
        ReadName = null;
        ReadName = ReedNameLoc.Load(TextLoc);
    }

    private void Start()
    {
        LoadAsset();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            SetText(0);
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            SetText(1);
        }
    }

    public void SetText(int NumberLoc)
    {
        Name.text = ReadName.lockes[NumberLoc].name;
        Disrc.text = ReadName.lockes[NumberLoc].discr;
        Sprite.sprite = LocImage[NumberLoc];
    }
}
