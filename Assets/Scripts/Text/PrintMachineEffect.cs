using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintMachineEffect : MonoBehaviour
{
    public static PrintMachineEffect abc = null;
    void Start()
    {
        if (abc == null)
            abc = this;
    }

    public IEnumerator printMachineEffect(Text textUI, string text, Button IntroButton)
    {
        //IntroButton.enabled = false;
        float time = 0.01f;

        for (int i = 0; i < text.Length; i++)
        {
            time = 0.01f;
            textUI.text += text[i];

            if (text[i] == '.')
                time = 0.5f;
            if (text[i] == ',')
                time = 0.5f;
            yield return new WaitForSeconds(time);
        }

        //IntroButton.enabled = true;
    }
}
