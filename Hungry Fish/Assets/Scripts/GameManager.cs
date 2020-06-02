using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public void openLevelMap()
    {
        SceneManager.LoadScene("LevelMap");
        Debug.Log("GameManager: " + "open level map");
    }

    public void playNextLevel()
    {
        //choose from array of levels


        Debug.Log("GameManager: " + "playNextLevel pressed");
    }

    public void playLevelOne()
    {
        SceneManager.LoadScene("Level1");
        Debug.Log("GameManager: " + "open level 1");

        setLevel(1);
    }

    public void playLevelTwo()
    {

        SceneManager.LoadScene("Level2");
        Debug.Log("GameManager: " + "open level 2");
    }

    public void playLevelThree()
    {
        SceneManager.LoadScene("Level3");
        Debug.Log("GameManager: " + "open level 3");
    }

    public void playLevelFour()
    {

        SceneManager.LoadScene("Level4");
        Debug.Log("GameManager: " + "open level 4");
    }

    private void setLevel(int levelNumber)
    {
        Debug.Log("GameManager: " + "setLevel");

        //get level description
        LevelsDescription levelsDescription = new LevelsDescription();
        Level currentLevel = levelsDescription.getLevelDescription(levelNumber);

        //apply level values to scene
        //fish number
        int fishNum = currentLevel.getFishTargetNumber();

        fish fishScript = GameObject.FindGameObjectWithTag("fish").GetComponent<fish>();
        fishScript.setFishNumber(fishNum);


        //level name
        string levelName = "Level: " + currentLevel.getLevelName();
        GameObject.FindGameObjectWithTag("LevelName").GetComponentInChildren<TMP_Text>().SetText(levelName);

        //bubbles range
        int[] bubRange = currentLevel.getBubblesRange();
        int minBub = bubRange[0];
        int maxBub = bubRange[1];
        Spawner spawner = new Spawner();
        spawner.setMinNumberOnBubble(minBub);
        spawner.setMaxNumberOnBubble(maxBub);

        Debug.Log("GameManager: " + "levelName: " + levelName);
        Debug.Log("GameManager: " + "fishNum: " + fishNum);
        Debug.Log("GameManager: " + "BubblesRange: " + minBub + " .. " + maxBub);

    }


}
