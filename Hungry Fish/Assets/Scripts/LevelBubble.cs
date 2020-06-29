using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBubble
{

    private int bubbleNumber;

    private int bubbleProbability;


    public LevelBubble(int bubNum, int bubProbab)
    {
        bubbleNumber = bubNum;
        bubbleProbability = bubProbab;
    }


    public int getBubbleNumber()
    {
        return bubbleNumber;
    }

    public int getBubbleProbability()
    {
        return bubbleProbability;
    }

}
