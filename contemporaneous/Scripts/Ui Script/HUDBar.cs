using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDBar : MonoBehaviour
{

    public Slider slider;
    
    public Image fill;
    
    public void SetMaxValue(int health)
    {
        slider.maxValue = health;
        slider.value = health;   
    }

    public void SetValue(int health)
    {
        slider.value = health;  
    }

}
