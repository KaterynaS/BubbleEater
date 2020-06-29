using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GameState
{
    private int currentLevel;
    private string previousScene;

    private bool isSound;

    //constructor
    private GameState() { }


    private static GameState _instance;


    public static GameState GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameState();
        }
        return _instance;
    }

    public void turnSoundOn()
    {
        isSound = true;
    }

    public void turnSoundOff()
    {
        isSound = false;
    }

    public bool isSoundOn()
    {
        return isSound;
    }

    public void setPreviousScene(string sceneName)
    {
        previousScene = sceneName;
    }

    public string getPreviousScene()
    {
        return previousScene;
    }

    // Finally, any singleton should define some business logic, which can
    // be executed on its instance.
    public void setCurrentLevel(int lvl)
    {
        currentLevel = lvl;
    }

    public int getCurrentLevel()
    {
        return currentLevel;
    }

    public void nextLevel()
    {
        currentLevel++;

        if (currentLevel == LevelsDescription.getLevelsListLength())
        {
            currentLevel = 0;
        }

    }


}
