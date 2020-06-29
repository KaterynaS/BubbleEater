using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    GameState gameState;


    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.GetInstance();
        setLevel(gameState.getCurrentLevel());
    }

    void OnEnable()
    {
        //chosenLevel = PlayerPrefs.GetInt("currentLevel");

        //setLevel(chosenLevel);
        //Debug.Log("LevelManager: " + "OnEnable: chosenLevel = " + chosenLevel);
    }

    public void playNextLevel()
    {
        //choose from array of levels
        gameState.nextLevel();

        Debug.Log("LevelManager: " + "playNextLevel pressed, (count) current lvl " + gameState.getCurrentLevel());

        SceneManager.LoadScene("Game");

        //setLevel(chosenLevel);
        //sendLevelNumberToLevelManager(chosenLevel);
        //SceneManager.LoadScene("Level1");
    }


    private void setLevel(int levelNumber)
    {
        Level currentLevel = LevelsDescription.getLevelDescription(levelNumber);

        Debug.Log("LevelManager: " + "setLevel,  levelNumber = " + levelNumber);

        //apply level values to scene
        //fish number
        int fishNum = currentLevel.getFishTargetNumber();
        fish fishScript = GameObject.FindGameObjectWithTag("fish").GetComponent<fish>();
        fishScript.setFishNumber(fishNum);

        Debug.Log("LevelManager: " + "setLevel,  fishNum = " + fishNum);

        //level name
        string levelName = "" + currentLevel.getLevelName();
        GameObject.FindGameObjectWithTag("LevelName").GetComponentInChildren<TMP_Text>().SetText(levelName);


        Debug.Log("LevelManager: " + "levelName: " + levelName);

    }

}
