using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsDescription : MonoBehaviour
{
    private List<Level> levelsList;

    void Start()
    {
        levelsList = new List <Level>();

        Level levelOne = new Level("Level One", 2, new int[] { 1, 1 });
        levelsList.Add(levelOne);


        Level levelTwo = new Level("Level Two", 3, new int[] { 1, 2 });
        levelsList.Add(levelOne);


        Level levelThree = new Level("Level Three", 4, new int[] { 1, 3 });
        levelsList.Add(levelOne);


        Level levelFour = new Level("Level Four", 4, new int[] { 0, 3 });
        levelsList.Add(levelOne);

        int a = levelsList.Count;
        Debug.Log("LevelsDescription: " + "levelsList.Count = " + a);
    }

    public Level getLevelDescription(int a)
    {
        return levelsList[a];
    }



}
