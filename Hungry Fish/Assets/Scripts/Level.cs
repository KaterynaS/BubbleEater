using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private string levelName;

    //something visual - like background color
    //light color?

    private int targetNumber;
    //bubbles to generate, for now min and max numbers on bubbles
    private int[] bubblesRange;

    public Level(string level, int targetNum, int[] bubblesInRange)
    {
        levelName = level;
        targetNumber = targetNum;
        bubblesRange = bubblesInRange;
    }

    public string getLevelName()
    {
        return levelName;
    }

    public int getFishTargetNumber()
    {
        return targetNumber;
    }

    public int[] getBubblesRange()
    {
        return bubblesRange;
    }


}
