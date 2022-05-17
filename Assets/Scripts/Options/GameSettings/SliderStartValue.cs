using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderStartValue : MonoBehaviour
{
    public Slider slider;
    private void Start()
    {
        GameObject StSlisd = GameObject.Find("aliluia");
        slider.value = StSlisd.GetComponent<SoundValContComp>().volume;
    }
}
