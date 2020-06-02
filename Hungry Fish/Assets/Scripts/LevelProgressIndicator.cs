using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressIndicator : MonoBehaviour
{

    public Slider bubblesEatenSlider;

    public void setBubblesPerCurrentLevel(int bubblesPerCurrentLevel)
    {
        bubblesEatenSlider.maxValue = bubblesPerCurrentLevel;
        bubblesEatenSlider.minValue = 0;
        bubblesEatenSlider.value = 0;

    }

    public void setBubblesEatenSlider(int bubblesEaten)
    {
        //Debug.Log("set bubbles eaten = " + bubblesEaten);
        bubblesEatenSlider.value = bubblesEaten;
    }
}
