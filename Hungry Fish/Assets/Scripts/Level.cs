using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    private string levelName;

    //something visual - like background color
    //light color?

    private int targetNumber;
    //bubbles to generate, for now min and max numbers on bubbles
    private int[] bubblesRange;
    private LevelBubble[] levelBubbles;

    public Level(string level, int targetNum, int[] bubblesInRange, LevelBubble[] levelBubblesArray)
    {
        levelName = level;
        targetNumber = targetNum;
        bubblesRange = bubblesInRange;
        levelBubbles = levelBubblesArray;
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

    public LevelBubble[] getLevelBubbles()
    {
        return levelBubbles;
    }


}

