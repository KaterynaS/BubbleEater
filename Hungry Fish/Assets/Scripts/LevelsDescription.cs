using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelsDescription
{
    private static List<Level> levelsList = new List<Level>();

    

    public static Level getLevelDescription(int a)
    {
        Debug.Log("LevelsDescription: " + "getLevelDescription, how many levels: " + getLevelsListLength());

        if (levelsList.Count <= 0) { createLevelsList(); }

        int b = levelsList.Count;
        return levelsList[a];
    }


    public static int getLevelsListLength()
    {
        int llLength = 0;

        llLength = levelsList.Count;

        return llLength;
    }

    public static void createLevelsList()
    {
        LevelBubble[] levelOneBubbles = new LevelBubble[] { new LevelBubble(1, 30), new LevelBubble(0, 5) };
        Level levelOne = new Level("Level One", 2, new int[] { 0, 1 }, levelOneBubbles);
        levelsList.Add(levelOne);


        Level levelTwo = new Level("Level Two", 3, new int[] { 1, 2 },
                                new LevelBubble[] { new LevelBubble(1, 20), new LevelBubble(2, 20) });
        levelsList.Add(levelTwo);


        Level levelThree = new Level("Level Three", 4, new int[] { 1, 3 },
                                new LevelBubble[] { new LevelBubble(1, 30), new LevelBubble(2, 30), new LevelBubble(3, 30) });
        levelsList.Add(levelThree);


        Level levelFour = new Level("Level Four", 4, new int[] { 0, 3 },
                                new LevelBubble[] { new LevelBubble(0, 5), new LevelBubble(1, 15), new LevelBubble(2, 50), new LevelBubble(3, 30) });
        levelsList.Add(levelFour);

        Level levelFive = new Level("Level Five", 5, new int[] { 0, 3 },
                            new LevelBubble[] {new LevelBubble(2, 5), new LevelBubble(3, 5) });
        levelsList.Add(levelFive);

        Level levelSix = new Level("Level Six", 5, new int[] { 0, 3 },
                            new LevelBubble[] { new LevelBubble(1, 5), new LevelBubble(4, 5) });
        levelsList.Add(levelSix);

        int a = levelsList.Count;
        Debug.Log("LevelsDescription: " + "levelsList.Count = " + a);
    }

}
